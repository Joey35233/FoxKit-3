class PropertyInfo:
    """Entity property metadata."""

    def __init__(self, name, data_type, offset, array_size, container, ptr_type, enum_type, export_flag, entity_name, definitions):
        """Creates a new PropertyInfo.

        Args:
                name (str): Name of the property.
                data_type (str): The property's value type.
                offset (uint): The offset of the property's value in C++.
                array_size (str): Number of elements in the property.
                container (str): The class's value container type.
                ptr_type (str): For EntityPtr properties, the type of the Entity pointed to.
                enum_type (str): The enum type.
                export_flag (str): Readable/writable settings for the property.
                entity_name (str): Name of owning entity.
                definitions (dict): Dictionary of all EntityInfos.

        """
        self.name = name
        self.data_type = data_type
        self.offset = offset
        self.array_size = array_size
        self.container = container
        self.ptr_type = ptr_type
        self.enum_type = enum_type
        self.export_flag = export_flag
        self.entity_name = entity_name
        self.definitions = definitions

        self.data_type_strings = {
            "int8" : "sbyte",
            "uint8" : "byte",
            "int16" : "short",
            "uint16" : "ushort",
            "int32" : "int",
            "uint32" : "uint",
            "int64" : "long",
            "uint64" : "ulong",
            "float" : "float",
            "double" : "double",
            "bool" : "bool",
            "String" : "Fox.Kernel.String",
            "Path" : "Fox.Kernel.Path",
            "EntityPtr" : "Fox.Core.EntityPtr",
            "Vector3" : "UnityEngine.Vector3",
            "Vector4" : "UnityEngine.Vector4",
            "Quat" : "UnityEngine.Quaternion",
            "Matrix3" : "object",
            "Matrix4" : "UnityEngine.Matrix4x4",
            "Color" : "UnityEngine.Color",
            "FilePtr" : "Fox.Core.FilePtr",
            "EntityHandle" : "Fox.Core.Entity",
            "EntityLink" : "Fox.Core.EntityLink",
            "WideVector3" : "object",
            "PropertyInfo" : "object"
        }

        self.get_value_data_type_strings = {
            "int8" : "Int8",
            "uint8" : "UInt8",
            "int16" : "Int16",
            "uint16" : "UInt16",
            "int32" : "Int32",
            "uint32" : "UInt32",
            "int64" : "Int64",
            "uint64" : "UInt64",
            "float" : "Float",
            "double" : "Double",
            "bool" : "Bool",
            "String" : "String",
            "Path" : "Path",
            "EntityPtr" : "EntityPtr",
            "Vector3" : "Vector3",
            "Vector4" : "Vector4",
            "Quat" : "Quat",
            "Matrix3" : "Matrix3",
            "Matrix4" : "Matrix4",
            "Color" : "Color",
            "FilePtr" : "FilePtr",
            "EntityHandle" : "EntityHandle",
            "EntityLink" : "EntityLink",
            "WideVector3" : "WideVector3",
            "PropertyInfo" : "PropertyInfo"
        }

    def get_safe_name(self):
        """Gets a converted form of the property name that's safe to use as an identifier.
        
        Returns:
                The safe property name.

        """
        if self.name == "string" or self.name == "object" or self.name == "params":
            return f'@{self.name}'
        return self.name

    def get_value_type_string(self):
        """Gets the formatted string of the value type.
        
        Returns:
                The formatted string of the value type.

        """
        result = self.data_type_strings[self.data_type]

        if self.enum_type:
            result = f'{self.enum_type}'
        if self.data_type == "EntityPtr":
            result = f'{result}<{self.definitions[self.ptr_type].get_root_namespace()}.{self.definitions[self.ptr_type].get_namespace_without_prefix()}.{self.ptr_type}>'
        return result

    def get_property_full_type_string(self):
        """Gets the formatted string of the property's full type.
        
        Returns:
                The formatted string of the property's full type, including the container.

        """
        value_type_string = self.get_value_type_string();

        if self.container == "StaticArray":
            if self.array_size == 1:
                return value_type_string
            return f'Fox.Kernel.StaticArray<{value_type_string}>'
        if self.container == "StringMap":
            return f'Fox.Kernel.StringMap<{value_type_string}>'
        return f'Fox.Kernel.DynamicArray<{value_type_string}>'

    def has_setter(self):
        """Gets whether the property has a setter.
        
        Returns:
                True if the property has a setter, else false.

        """
        return self.container == "StaticArray" and self.array_size == 1

    def has_default_value(self):
        """Gets whether the property has an explicit default value.
        
        Returns:
                True if the property has an explicit default value, else false.

        """
        if self.data_type == "EntityPtr":
            return True

        return not (self.container == "StaticArray" and self.array_size == 1)

    def get_default_value(self):
        """Gets the property's default value.
        
        Returns:
                The property's default value.

        """
        value_type_string = self.get_value_type_string()

        if not self.is_collection_property() and self.data_type == "EntityPtr":
            return f'new {value_type_string}()'
        if self.container == "StaticArray":
            return f'new Fox.Kernel.StaticArray<{value_type_string}>({self.array_size})'
        if self.container == "StringMap":
            return f'new Fox.Kernel.StringMap<{value_type_string}>()'
        return f'new Fox.Kernel.DynamicArray<{value_type_string}>()'

    def get_value_getter_type_string(self):
        """Gets the type string to use with Value.GetValueAs...
        
        Returns:
                The type name string.

        """
        return self.get_value_data_type_strings[self.data_type]

    def get_value_extraction_string(self):
        """Gets the string to use to extract a value from Value.GetValueAs...
        
        Returns:
                The value extraction string.

        """

        cast_string = ""
        if self.enum_type:
            cast_string = f'({self.enum_type})'

        if self.data_type == "EntityPtr":
            ptr_definition = self.definitions[self.ptr_type]
            root_namespace = ptr_definition.get_root_namespace()
            ptr_namespace = ptr_definition.get_namespace_without_prefix()
            ptr_string = f'{root_namespace}.{ptr_namespace}.{self.ptr_type}'

            return f'value.GetValueAsEntityPtr<{ptr_string}>()'
        return f'{cast_string}value.GetValueAs{self.get_value_getter_type_string()}()'

    def get_readable_string(self):
        """Gets the property readability enum string.
        
        Returns:
                The readability enum string.

        """

        if self.export_flag[0] == 'R':
            return "Fox.Core.PropertyInfo.PropertyExport.EditorAndGame"
        elif self.export_flag[0] == 'r':
            return "Fox.Core.PropertyInfo.PropertyExport.EditorOnly"
        return "Fox.Core.PropertyInfo.PropertyExport.Never"

    def has_public_get(self):
        """Gets whether or not the property should be public and have a public getter.
        
        Returns:
                True if the property should be public and have a public getter.

        """
        
        if self.export_flag[0] == 'R' or self.export_flag[0] == 'r':
            return True
        return False

    def is_blacklisted(self):
        """UnityEngine.MonoBehaviours redefine multiple properties used by Fox including `name`, `transform`, etc."""
        if self.entity_name == "DataElement" or self.entity_name == "Data":
            return True
        
        if self.entity_name == "TransformData" and (self.name == "children" or self.name == "parent" or self.name == "transform"):
            return True
        
        if self.name == "name":
            return True
        
        return False

    def has_public_set(self):
        """Gets whether or not the property should have a public setter.
        
        Returns:
                True if the property should have a public setter.

        """
        
        if self.export_flag[1] == 'W' or self.export_flag[1] == 'w':
            return True
        return False

    def get_writable_string(self):
        """Gets the property writability enum string.
        
        Returns:
                The writability enum string.

        """

        if self.export_flag[1] == 'W':
            return "Fox.Core.PropertyInfo.PropertyExport.EditorAndGame"
        elif self.export_flag[1] == 'w':
            return "Fox.Core.PropertyInfo.PropertyExport.EditorOnly"
        return "Fox.Core.PropertyInfo.PropertyExport.Never"

    def get_entity_ptr_type_string(self):
        if self.ptr_type:
            ptr_definition = self.definitions[self.ptr_type]
            root_namespace = ptr_definition.get_root_namespace()
            ptr_namespace = ptr_definition.get_namespace_without_prefix()
            ptr_string = f'{root_namespace}.{ptr_namespace}.{self.ptr_type}'
            return f'typeof({ptr_string})'
        return "null"

    def get_property_info_instantiation_string(self):
        """Gets the PropertyInfo instantiation string.
        
        Returns:
                The PropertyInfo instantiation string.

        """

        enum_str = "null"
        if self.enum_type:
            enum_str = f'typeof({self.enum_type})'
        return f'classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("{self.name}"), Fox.Core.PropertyInfo.PropertyType.{self.get_value_getter_type_string()}, {self.offset}, {self.array_size}, Fox.Core.PropertyInfo.ContainerType.{self.container}, {self.get_readable_string()}, {self.get_writable_string()}, {self.get_entity_ptr_type_string()}, {enum_str}, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.{"Accessor" if self.is_accessor_property() else "Field"}));'

    def is_collection_property(self):
        """Gets whether or not the property is a collection property.
        
        Returns:
                True if the property represents an array or StringMap.

        """
        return self.container != "StaticArray" or self.array_size > 1

    def is_array_property(self):
        """Gets whether or not the property is an array property.
        
        Returns:
                True if the property represents an array or list.

        """
        return self.container != "StringMap" and (self.container != "StaticArray" or self.array_size > 1)

    def is_accessor_property(self):
        """Gets whether or not the property is an accessor (no storage, just getters and setter functions) property.
        
        Returns:
                True if the property is an acessor.

        """
        return (self.definitions[self.entity_name].parent is not None) and (self.offset == 0)