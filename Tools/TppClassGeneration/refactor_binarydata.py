import json

with open(r'C:\Users\joey3\Documents\GitHub\FoxKit-3\Tools\TppClassGeneration\FoxKitClassDefinitions_old.json', 'r') as f:
    data = json.load(f)

binary_data_prop = {
    "arraySize": 4,
    "container": "StaticArray",
    "enum": None,
    "exportFlag": "RW",
    "name": "binaryData",
    "offset": 76,
    "ptrType": None,
    "size": 16,
    "type": "uint32"
}

def is_only_binary_data(entry):
    return (
        entry['name'].startswith('TppRoute') and
        len(entry['properties']) == 1 and
        entry['properties'][0]['name'] == 'binaryData'
    )

result = []
removed = []

for entry in data:
    name = entry['name']

    if name in ('GsRouteDataNodeEvent', 'GsRouteDataEdgeEvent'):
        entry['properties'].append(binary_data_prop)
        result.append(entry)
    elif is_only_binary_data(entry):
        removed.append(name)
    else:
        result.append(entry)

with open(r'C:\Users\joey3\Documents\GitHub\FoxKit-3\Tools\TppClassGeneration\FoxKitClassDefinitions_old.json', 'w', newline='\n') as f:
    json.dump(result, f, indent=2)

print(f'Added binaryData to GsRouteDataNodeEvent and GsRouteDataEdgeEvent')
print(f'Removed {len(removed)} TppRoute* classes with only binaryData:')
for n in removed:
    print(f'  {n}')
print(f'Total entries: {len(result)}')