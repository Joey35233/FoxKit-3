const fs = require('fs');
const path = require('path');

const deps = JSON.parse(fs.readFileSync(path.join(__dirname, 'ModuleDependencies.json'), 'utf8'));
const expected = fs.readFileSync(path.join(__dirname, 'ModuleInitOrder.txt'), 'utf8')
  .split(/\r?\n/).filter(Boolean);

// Use the *direct* dependencies only (mirrors DependencyBitSet after flattening in the real
// game via Module::AddDependencyModule, but here we approximate the fixed-point/flatten phase
// by pre-flattening direct deps into full transitive closure, same info as "expandedDependencies").
function flatten(name, memo) {
  if (memo.has(name)) return memo.get(name);
  const direct = deps[name].dependencies;
  const result = new Set();
  memo.set(name, result); // guard against cycles while computing
  for (const d of direct) {
    result.add(d);
    for (const t of flatten(d, memo)) result.add(t);
  }
  return result;
}

function runSimulation(seedOrder, tieBreak) {
  const memo = new Map();
  const flattened = {};
  for (const name of seedOrder) flattened[name] = flatten(name, memo);

  let pending = seedOrder.slice();
  const placed = new Set();
  const order = [];

  while (pending.length > 0) {
    // sort ascending by count of dependencies not yet placed (mirrors CmpModuleDeps)
    const withCounts = pending.map(name => {
      let remaining = 0;
      for (const d of flattened[name]) if (!placed.has(d)) remaining++;
      return { name, remaining };
    });

    tieBreak(withCounts);

    // peel the leading run that has remaining === 0
    let i = 0;
    while (i < withCounts.length && withCounts[i].remaining === 0) i++;

    if (i === 0) {
      throw new Error('No progress possible - cycle or missing dependency: ' + pending.join(', '));
    }

    const readyThisRound = withCounts.slice(0, i).map(x => x.name);
    for (const name of readyThisRound) {
      order.push(name);
      placed.add(name);
    }
    pending = withCounts.slice(i).map(x => x.name);
  }

  return order;
}

function compare(label, order) {
  const ok = order.length === expected.length && order.every((v, i) => v === expected[i]);
  console.log(`\n=== ${label} ===`);
  console.log(ok ? 'EXACT MATCH' : 'MISMATCH');
  if (!ok) {
    for (let i = 0; i < Math.max(order.length, expected.length); i++) {
      if (order[i] !== expected[i]) {
        console.log(`  first diff at index ${i}: got=${order[i]} expected=${expected[i]}`);
        break;
      }
    }
    console.log('  got     :', order.join(', '));
    console.log('  expected:', expected.join(', '));
  }
  return ok;
}

const allNames = Object.keys(deps);
const alphabetical = allNames.slice().sort();

// True native module construction order, recovered from ModuleDependencies.txt: each module
// logs its "Module -> dependency" lines as a contiguous block at the moment it's constructed
// (AddDependencyModule is called from within the module's own registration), so the first time
// each module name appears as the left-hand column is that module's real construction order.
// FoxKernel never appears on the left (it has zero dependencies, so it never calls
// AddDependencyModule), so it's prepended manually - its exact position doesn't affect the
// simulation since it's always the unique first-ready module regardless of seed position.
const depLines = fs.readFileSync(path.join(__dirname, 'ModuleDependencies.txt'), 'utf8')
  .split(/\r?\n/).filter(Boolean)
  .map(line => line.split(' -> '));

const constructionOrder = ['FoxKernel'];
const seen = new Set(constructionOrder);
for (const [module] of depLines) {
  if (!seen.has(module)) { seen.add(module); constructionOrder.push(module); }
}
console.log('Recovered construction order:', constructionOrder.join(', '));
console.log('All modules accounted for:', constructionOrder.length === allNames.length,
  `(${constructionOrder.length} vs ${allNames.length})`);

compare('construction-order seed, stable sort (ties preserve seed order)', runSimulation(constructionOrder, (arr) => {
  arr.sort((a, b) => a.remaining - b.remaining);
}));

// Strategy 1: stable sort, ties broken by alphabetical order, seeded alphabetically
compare('alphabetical seed, stable sort (ties = alphabetical)', runSimulation(alphabetical, (arr) => {
  arr.sort((a, b) => a.remaining - b.remaining || a.name.localeCompare(b.name));
}));

// Strategy 2: stable sort, ties preserve seed/original relative order (Array.prototype.sort is stable in V8/Node)
compare('alphabetical seed, stable sort (ties preserve seed order)', runSimulation(alphabetical, (arr) => {
  arr.sort((a, b) => a.remaining - b.remaining);
}));

// Strategy 3: seed order = order modules appear as keys in ModuleInitOrder.txt itself is cheating;
// instead try seeding seed order using the order names are already given in ModuleInitOrder.txt
// but re-deriving strictly from dependency counts to see if grouping (rounds) match regardless of tie order.
function runRounds(seedOrder) {
  const memo = new Map();
  const flattened = {};
  for (const name of seedOrder) flattened[name] = flatten(name, memo);
  let pending = new Set(seedOrder);
  const placed = new Set();
  const rounds = [];
  while (pending.size > 0) {
    const ready = [...pending].filter(name => [...flattened[name]].every(d => placed.has(d)));
    if (ready.length === 0) throw new Error('stuck: ' + [...pending].join(','));
    rounds.push(ready.slice().sort());
    for (const r of ready) { placed.add(r); pending.delete(r); }
  }
  return rounds;
}

const rounds = runRounds(allNames);
console.log('\n=== Round grouping (order-independent) ===');
rounds.forEach((r, i) => console.log(`Round ${i}: ${r.join(', ')}`));

// Check expected order against round grouping: is each module's round index non-decreasing
// and does each round's expected-order subsequence equal a permutation of that round's set?
const roundIndexOf = {};
rounds.forEach((r, i) => r.forEach(name => { roundIndexOf[name] = i; }));
let monotonic = true;
let lastRound = -1;
for (const name of expected) {
  const r = roundIndexOf[name];
  if (r < lastRound) { monotonic = false; break; }
  lastRound = r;
}
console.log('\nExpected order is consistent with round grouping (non-decreasing round index):', monotonic);
