from jinja2 import Template
import json
from pathlib import Path

exec(open("EntityInfo.py").read())
exec(open("PropertyInfo.py").read())
exec(open("EnumInfo.py").read())

# Config
class_template_path = "ClassTemplate.txt"
definitions_path = "TppClassDefinitions.json"

enum_template_path = "EnumsTemplate.txt"
enums_path = "TppEnums.json"

entity_factory_template_path = "EntityFactoryTemplate.txt"

def load_definitions (path):
    result = {}
    with open(path) as json_file:
        data = json.load(json_file)
        for entry in data:
            properties = {}
            for property in entry["properties"]:
                properties[property["name"]] = PropertyInfo(property["name"], property["type"], property["offset"], property["arraySize"], property["container"], property["ptrType"], property["enum"], property["exportFlag"], entry["name"], result)
            result[entry["name"]] = EntityInfo(entry["name"], entry["namespace"], entry["parent"], entry["category"], entry["version"], entry["id"], properties, result)

    return result

def load_enum_definitions (path):
    result = []
    with open(path) as json_file:
        data = json.load(json_file)
        for entry in data:
            values = []
            for value in entry["values"]:
                values.append(EnumValue(value["name"], value["value"]))
            result.append(EnumInfo(entry["name"], entry["type"], entry["underlying_type"], values))

    return result

def generate_classes ():    
    template_file = open(class_template_path, "r")
    template = Template(template_file.read())
    definitions = load_definitions(definitions_path)

    for class_name in definitions:
        # Generate class file
        result = template.render(info = definitions[class_name])

        # Output generated file
        root_namespace = get_root_namespace(definitions[class_name].namespace)
        trimmed_namespace = get_namespace_without_prefix(definitions[class_name].namespace)
        output_path = make_output_path(definitions[class_name].name, root_namespace, trimmed_namespace)
        Path(f'../{root_namespace}/{trimmed_namespace}/Generated').mkdir(parents=True, exist_ok=True)

        output_file = open(output_path,"w")
        output_file.write(result)
        output_file.close()

    ## Generate EntityFactory
    #entity_factory_template_file = open(entity_factory_template_path, "r")
    #entity_factory_template = Template(entity_factory_template_file.read())
    #result = entity_factory_template.render(info = definitions)

    #output_file = open(f'../EntityFactory.generated.cs', "w")
    #output_file.write(result)
    #output_file.close()

def generate_enums ():
    template_file = open(enum_template_path, "r")
    template = Template(template_file.read())
    definitions = load_enum_definitions(enums_path)        
    result = template.render(enums = definitions)
        
    # Output generated file
    output_file = open(f'../Enums.generated.cs', "w")
    output_file.write(result)
    output_file.close()

def get_root_namespace(namespace):
    if str.startswith(namespace, "Tpp"):
        return "Tpp"
    return "Fox"

def remove_prefix(text, prefix):
    return text[text.startswith(prefix) and len(prefix):]

def get_namespace_without_prefix(class_name):
    return remove_prefix(remove_prefix(class_name, "Tpp"), "Fox")

def make_output_path (type_name, type_root_namespace, type_namespace):
    """Create the output path for a generated class file.

    Args:
        type_name (str): Name of the class.
        type_namespace (str): The class's namespace.

    Returns:
        str: The output file path.

    """

    return f'../{type_root_namespace}/{type_namespace}/Generated/{type_name}.generated.cs'

generate_classes()
generate_enums()