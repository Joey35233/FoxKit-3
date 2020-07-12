class EnumInfo:
    """Enum metadata."""

    def __init__(self, name, type, underlying_type, values):
        """Creates a new EntityInfo.

        Args:
                name (str): Name of the enum.
                type (str): Type of the enum. Should be either "flags" or "switch."
                underlying_type (str): Underlying integral type of the enum. If none, assumed to be "int."
                values (list): Values of the enum.

        """
        self.name = name
        self.type = type
        self.underlying_type = underlying_type
        self.values = values

class EnumValue:
    """Enum value metadata."""

    def __init__(self, name, value):
        """Creates a new EnumValue.

        Args:
                name (str): Name of the enum value.
                value (int): The represented value.

        """
        self.name = name
        self.value = value

    def get_safe_name(self):
        """Gets a formatted version of the name that's safe to use as a C# identifier.
        
        Returns:
                The safe name.

        """
        if '(' in self.name:            
            return self.name.split('(')[0]
        elif ':' in self.name:
            return self.name.split('::')[1]
        elif ' ' in self.name:
            return self.name.replace(' ', '_')
        return self.name