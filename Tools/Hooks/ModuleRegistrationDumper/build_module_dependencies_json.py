"""Converts ModuleDependencies.txt (produced by the AddDependencyModule hook)
into ModuleDependencies.json: a dict of module name -> immediate and expanded
(transitive, direct + inherited) dependency lists.
"""
import json
import os

INPUT_PATH = os.path.join(os.path.dirname(__file__), "ModuleDependencies.txt")
OUTPUT_PATH = os.path.join(os.path.dirname(__file__), "ModuleDependencies.json")


def parse_immediate_dependencies(path):
    immediate = {}
    with open(path, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if not line:
                continue
            module, _, dependency = line.partition(" -> ")
            if not _:
                raise ValueError(f"Malformed line: {line!r}")

            immediate.setdefault(module, [])
            if dependency not in immediate[module]:
                immediate[module].append(dependency)
            immediate.setdefault(dependency, [])
    return immediate


def expand_dependencies(module, immediate, cache, in_progress):
    if module in cache:
        return cache[module]
    if module in in_progress:
        raise ValueError(f"Dependency cycle detected involving {module!r}")

    in_progress.add(module)
    expanded = set()
    for dependency in immediate[module]:
        expanded.add(dependency)
        expanded.update(expand_dependencies(dependency, immediate, cache, in_progress))
    in_progress.discard(module)

    cache[module] = expanded
    return expanded


def main():
    immediate = parse_immediate_dependencies(INPUT_PATH)

    cache = {}
    in_progress = set()
    result = {}
    for module in sorted(immediate):
        expanded = expand_dependencies(module, immediate, cache, in_progress)
        result[module] = {
            "dependencies": immediate[module],
            "expandedDependencies": sorted(expanded),
        }

    with open(OUTPUT_PATH, "w", encoding="utf-8") as f:
        json.dump(result, f, indent=2)
        f.write("\n")

    print(f"Wrote {len(result)} modules to {OUTPUT_PATH}")


if __name__ == "__main__":
    main()
