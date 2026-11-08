class PropertyInfo:
	"""Entity property metadata."""

	def __init__(self, name, data_type, offset, array_size, container, ptr_type, enum_type, export_flag, entity_name, definitions, access_modifier, accessor_setter=False, accessor_write_modifier=None):
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
		valid_modifiers = {"public", "internal", "protected", "private", "protected internal", "private protected"}
		if access_modifier not in valid_modifiers:
			raise ValueError(f"{entity_name}.{name}: invalid accessModifier {access_modifier!r}")
		if accessor_write_modifier is not None and accessor_write_modifier not in valid_modifiers:
			raise ValueError(f"{entity_name}.{name}: invalid accessorWriteModifier")
		self.access_modifier = access_modifier
		self.accessor_setter = accessor_setter
		self.accessor_write_modifier = accessor_write_modifier or access_modifier

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
			"String" : "string",
			"Path" : "Fox.Path",
			"EntityPtr" : "object",
			"Vector3" : "UnityEngine.Vector3",
			"Vector4" : "UnityEngine.Vector4",
			"Quat" : "UnityEngine.Quaternion",
			"Matrix3" : "Fox.Matrix3x3",
			"Matrix4" : "UnityEngine.Matrix4x4",
			"Color" : "UnityEngine.Color",
			"FilePtr" : "Fox.Core.FilePtr",
			"EntityHandle" : "Fox.Core.Entity",
			"EntityLink" : "Fox.Core.EntityLink",
			"WideVector3" : "Fox.WideVector3",
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
		if self.name == "string" or self.name == "object" or self.name == "params" or self.name == "event":
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
			result = f'{self.definitions[self.ptr_type].get_root_namespace()}.{self.definitions[self.ptr_type].get_namespace_without_prefix()}.{self.ptr_type}'
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
			return f'{value_type_string}[]'
		if self.container == "StringMap":
			return f'Fox.StringMap<{value_type_string}>'
		return f'List<{value_type_string}>'

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
		
		return not (self.container == "StaticArray" and self.array_size == 1)

	def get_default_value(self):
		"""Gets the property's default value.
		
		Returns:
				The property's default value.

		"""
		value_type_string = self.get_value_type_string()

		if self.container == "StaticArray":
			return f'new {value_type_string}[{self.array_size}]'
		if self.container == "StringMap":
			return f'new Fox.StringMap<{value_type_string}>()'
		return f'new List<{value_type_string}>()'

	def get_value_getter_type_string(self):
		"""Gets the PropertyType name string for this property's data type.
		
		Returns:
				The type name string.

		"""
		return self.get_value_data_type_strings[self.data_type]

	def get_value_extraction_string(self):
		"""Gets the string to use to extract a value from a boxed object.
		
		Returns:
				The value extraction string.

		"""

		return f'({self.get_value_type_string()})value'

	def is_hiding_existing(self):
		"""UnityEngine.MonoBehaviours redefine multiple properties used by Fox including `name`, `transform`, etc."""

		if self.name == "name" or self.name == "transform" or self.name == "light" or self.name == "tag" or self.name == "enabled":
			return True
		
		return False

	def get_entity_ptr_type_string(self):
		if self.ptr_type:
			ptr_definition = self.definitions[self.ptr_type]
			root_namespace = ptr_definition.get_root_namespace()
			ptr_namespace = ptr_definition.get_namespace_without_prefix()
			ptr_string = f'{root_namespace}.{ptr_namespace}.{self.ptr_type}'
			return f'typeof({ptr_string})'
		return "null"

	def get_export_flags_string(self):
		flags = {"r": "Readable", "w": "Writable", "R": "ReadableInEditor", "W": "WritableInEditor"}
		values = ["Fox.Core.PropertyInfo.PropertyExport." + flags[c] for c in self.export_flag if c != " "]
		return " | ".join(values) if values else "Fox.Core.PropertyInfo.PropertyExport.None"

	def get_property_info_instantiation_string(self):
		"""Gets the PropertyInfo instantiation string.
		
		Returns:
				The PropertyInfo instantiation string.

		"""

		enum_str = "null"
		if self.enum_type:
			enum_str = f'typeof({self.enum_type})'
		return f'classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("{self.name}", Fox.Core.PropertyInfo.PropertyType.{self.get_value_getter_type_string()}, {self.offset}, {self.array_size}, Fox.Core.PropertyInfo.ContainerType.{self.container}, {self.get_entity_ptr_type_string()}, {enum_str}, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.{"Accessor" if self.is_accessor_property() else "Field"}, {self.get_export_flags_string()}));'

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
