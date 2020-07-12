from jinja2 import Template
import json

execfile("EntityInfo.py")
execfile("PropertyInfo.py")
execfile("EnumInfo.py")

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
                properties[property["name"]] = PropertyInfo(property["name"], property["type"], property["offset"], property["arraySize"], property["container"], property["ptrType"], property["enum"], property["exportFlag"], result)
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
        output_file = open(make_output_path(definitions[class_name].name, definitions[class_name].namespace), "w")
        output_file.write(result)
        output_file.close()

    # Generate EntityFactory
    entity_factory_template_file = open(entity_factory_template_path, "r")
    entity_factory_template = Template(entity_factory_template_file.read())
    result = entity_factory_template.render(info = definitions)

    output_file = open(f'../Fox.FoxCore.Serialization/EntityFactory.generated.cs', "w")
    output_file.write(result)
    output_file.close()

def generate_enums ():
    template_file = open(enum_template_path, "r")
    template = Template(template_file.read())
    definitions = load_enum_definitions(enums_path)        
    result = template.render(enums = definitions)
        
    # Output generated file
    output_file = open(f'../Fox.FoxCore/Enums.generated.cs', "w")
    output_file.write(result)
    output_file.close()

def make_output_path (type_name, type_namespace):
    """Create the output path for a generated class file.

    Args:
        type_name (str): Name of the class.
        type_namespace (str): The class's namespace.

    Returns:
        str: The output file path.

    """

    return f'../Fox.{type_namespace}/{type_name}.generated.cs'

generate_classes()
generate_enums()