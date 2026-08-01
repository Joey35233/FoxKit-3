import xml.etree.ElementTree as ET
import json

tree = ET.parse(r'C:/Users/joey3/Downloads/Gz_edb_win64.xml')
root = tree.getroot()

# Build type stride map
type_strides = {}
for t in root.iter('type'):
    name = t.find('name')
    stride = t.find('stride')
    if name is not None and stride is not None:
        type_strides[name.text] = int(stride.text)

# Fixed sizes for dynamic containers (per user spec)
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
        ptrtype = prop.findtext('ptrtype')
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
    return {'name': name, 'super': super_name, 'version': version,
            'classid': classid, 'properties': properties}

# Parse all entities
entities = {}
for entity in root.iter('entity'):
    name = entity.findtext('name')
    if name:
        entities[name] = parse_entity(entity)

# Print parent class info
parents_needed = {
    'GraphxSpatialGraphDataNode','GraphxSpatialGraphDataEdge',
    'GraphxPathData','GraphxPath','DataElement','ComponentSet'
}
print('=== Parent classes ===')
for name in sorted(parents_needed):
    if name in entities:
        e = entities[name]
        print(f'{name} classid={e["classid"]} version={e["version"]} super={e["super"]}')
        for p in e['properties']:
            print(f'  {p["name"]} type={p["type"]} container={p["container"]} arraysize={p["arraySize"]} offset={p["offset"]} size={p["size"]}')
    else:
        print(f'{name} NOT FOUND in XML')
print()

# Print GsRoute* classids
print('=== GsRoute classids ===')
for name in sorted(n for n in entities if n.startswith('GsRoute')):
    e = entities[name]
    print(f'{name}: classid={e["classid"]} version={e["version"]} super={e["super"]}')
