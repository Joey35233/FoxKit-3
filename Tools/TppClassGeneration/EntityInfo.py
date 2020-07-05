class EntityInfo:
    """Entity class metadata."""

    def __init__(self, name, namespace, parent, category, version, id, properties, definitions):
        """Creates a new EntityInfo.

        Args:
                name (str): Name of the class.
                namespace (str): The class's namespace.
                parent (str): Name of the superclass, or None if the class is a root class.
                category (str): The class's category, or None if there is no category.
                category (int): The class's version.
                id (int): The class's id.
                properties (dict): The class's static properties.
                definitions (dict): Dictionary of all EntityInfos.

        """
        self.name = name
        self.namespace = namespace
        self.parent = parent
        self.category = category
        self.version = version
        self.id = id
        self.properties = properties
        self.definitions = definitions

    def is_root(self):
        """Gets if this is a root class.
        
        Returns:
                True if it is a root class, else false.

        """
        return self.parent is None

    def is_entity(self):
        """Gets if this is an Entity class.
        
        Returns:
                True if it is an Entity class, else false.

        """
        if self.name == "Entity":
            return True
        if not self.parent:
            return False
        return self.definitions[self.parent].is_entity()

    def get_category_string(self):
        """Gets the formatted category string.
        
        Returns:
                The formatted category string.

        """
        if self.category:
            return f'"{self.category}"'
        else:
            return "null"

    def get_parent_string(self):
        """Gets the formatted parent string.
        
        Returns:
                The formatted parent string.

        """
        parent_namespace = self.definitions[self.parent].namespace
        return f'{parent_namespace}.{self.parent}'

    def get_parent_entity_info_string(self):
        """Gets the formatted parent EntityInfo string.
        
        Returns:
                The formatted parent EntityInfo string.

        """
        if self.is_root():
            return "null"
        else:
            return "base.GetClassEntityInfo()"

    def get_non_collection_properties(self):
        """Gets the non-collection properties.
        
        Returns:
                A dict of the type's non-collection properties.

        """
        return filter(lambda property : not self.properties[property].is_collection_property(), self.properties)

    def get_array_properties(self):
        """Gets the array properties.
        
        Returns:
                A dict of the type's array properties.

        """
        return filter(lambda property : self.properties[property].is_array_property(), self.properties)

    def get_string_map_properties(self):
        """Gets the StringMap properties.
        
        Returns:
                A dict of the type's StringMap properties.

        """
        return filter(lambda property : self.properties[property].container == "StringMap", self.properties)