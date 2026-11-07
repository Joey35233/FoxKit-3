# Repository Guidelines

## Project Structure & Module Organization

`FoxKit/` is the Unity project. Under `FoxKit/Assets/`, `Fox/` contains engine types, file readers/writers, and editor integrations; `Tpp/` contains game-specific types; and `FoxKit/` contains menus, settings, and dictionaries. Modules use `Fox.*` and `Tpp.*` assembly definitions. `Gizmos/` holds editor icons, `Lib/` holds third-party code, and `Game/` holds ignored local game assets. Existing NUnit tests live in `Fox/Kernel/Test/Kernel.cs`.

`Tools/TppClassGeneration/` contains Python generators, JSON definitions, and templates. `Tools/TppClassVisualization/` contains a .NET class-graph utility. Unity configuration lives in `FoxKit/ProjectSettings/` and `FoxKit/Packages/`.

## Build, Test, and Development Commands

Use Unity **6000.0.47f1**, as recorded in `ProjectVersion.txt`. Open `FoxKit/` through Unity Hub, allow package resolution and compilation, then configure local asset paths through **FoxKit > Settings**. Exercise import/export workflows through the **FoxKit** menu.

From the repository root, with `UNITY_EDITOR` set to the Unity executable:

```sh
"$UNITY_EDITOR" -projectPath "$PWD/FoxKit"
"$UNITY_EDITOR" -batchmode -projectPath "$PWD/FoxKit" -runTests -testPlatform EditMode -testResults /tmp/foxkit-tests.xml -logFile /tmp/foxkit-tests.log
dotnet build Tools/TppClassVisualization/TppClassVisualization.csproj
```

These open the editor, run EditMode tests, and build the visualization utility, respectively. The utility requires .NET 10. There is no repository-wide build script.

## Coding Style & Naming Conventions

Match neighboring C# code: four-space indentation, braces on separate lines, PascalCase types and methods, and camelCase locals. Preserve existing engine property names and namespace/module boundaries. No repository-wide formatter or lint command is configured.

Prefer handwritten partial classes for behavior changes. For generated declarations, update the JSON/templates under `Tools/TppClassGeneration/`; review relative output paths before running its Python/Jinja2 scripts. Preserve Unity `.meta` files and include them with new or moved assets. Avoid unrelated vendor changes.

## Testing Guidelines

Use Unity Test Framework/NUnit via **Window > General > Test Runner**, or the command above. Follow descriptive method names such as `BasicPathCodeTests`. Add regression checks for changed hashing or serialization behavior; manually verify affected import/export workflows. No coverage threshold is configured.

## Commit & Pull Request Guidelines

History uses short descriptive subjects such as `Fixed DynamicProperty implementations`; no strict prefix convention is evident. Keep commits focused. PRs should explain behavior changes, link relevant issues, record validation and Unity version, and include screenshots for editor UI changes. Exclude local game data, caches, logs, and personal IDE settings.
