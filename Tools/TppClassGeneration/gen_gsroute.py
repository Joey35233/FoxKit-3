import xml.etree.ElementTree as ET
import json

tree = ET.parse(r'C:/Users/joey3/Downloads/Gz_edb_win64.xml')
root = tree.getroot()

# Build type stride map from XML typeinfo
type_strides = {}
for t in root.iter('type'):
    name = t.find('name')
    stride = t.find('stride')
    if name is not None and stride is not None:
        type_strides[name.text] = int(stride.text)

# Fixed sizes for dynamic containers per spec: DynamicArray=16
container_fixed = {'DynamicArray': 16, 'List': 16, 'StringMap': 16}

def parse_entity(entity):
    name = entity.findtext('name')
    super_name = entity.findtext('super')
    version = int(entity.findtext('version') or 0)
    classid = int(entity.findtext('classid') or 0)
    properties = []
    for prop in entity.iter('property'):
        pname = prop.findtext('name')
        if pname is None:
            continue
        ptype = prop.findtext('type')
        container = prop.findtext('container') or 'StaticArray'
        arraysize = int(prop.findtext('arraysize') or 1)
        offset = int(prop.findtext('offset') or 0)
        ptrtype = prop.findtext('ptrtype') or None
        exportflag = prop.findtext('exportflag') or 'rw'
        if container in container_fixed:
            size = container_fixed[container]
        else:
            stride = type_strides.get(ptype, 0)
            size = stride * arraysize
        properties.append({
            'name': pname, 'type': ptype, 'container': container,
            'arraySize': arraysize, 'offset': offset, 'size': size,
            'ptrType': ptrtype, 'exportFlag': exportflag,
        })
    return {
        'name': name, 'super': super_name, 'version': version,
        'classid': classid, 'properties': properties,
    }

# Parse all entities
entities = {}
for entity in root.iter('entity'):
    name = entity.findtext('name')
    if name:
        entities[name] = parse_entity(entity)

# Recursively get all (offset, name) keys across an entire ancestor chain
def get_all_prop_keys(class_name):
    if not class_name or class_name not in entities:
        return set()
    ent = entities[class_name]
    parent_keys = get_all_prop_keys(ent['super'])
    own_keys = {(p['offset'], p['name']) for p in ent['properties']}
    return parent_keys | own_keys

def get_own_props(class_name):
    ent = entities[class_name]
    parent_keys = get_all_prop_keys(ent['super'])
    return [p for p in ent['properties'] if (p['offset'], p['name']) not in parent_keys]

# Generate JSON for all GsRoute* classes in alphabetical order
result = []
for name in sorted(n for n in entities if n.startswith('GsRoute')):
    ent = entities[name]
    own = get_own_props(name)

    entry = {
        'category': None,
        'functions': [],
        'id': ent['classid'],
        'name': name,
        'namespace': None,
        'parent': ent['super'],
        'properties': [],
        'version': ent['version'],
    }

    for p in own:
        entry['properties'].append({
            'arraySize': p['arraySize'],
            'container': p['container'],
            'enum': None,
            'exportFlag': p['exportFlag'],
            'name': p['name'],
            'offset': p['offset'],
            'ptrType': p['ptrType'],
            'size': p['size'],
            'type': p['type'],
        })

    result.append(entry)

out_path = r'C:\Users\joey3\Documents\GitHub\FoxKit-3\Tools\TppClassGeneration\FoxKitClassDefinitions_new.json'
with open(out_path, 'w', newline='\n') as f:
    json.dump(result, f, indent=2)

print(f'Wrote {len(result)} classes to FoxKitClassDefinitions_new.json')
for entry in result:
    print(f'  {entry["name"]}: {len(entry["properties"])} own props, parent={entry["parent"]}, version={entry["version"]}')
