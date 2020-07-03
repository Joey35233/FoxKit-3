#include "String.h"
#include <malloc.h>

namespace fox
{
	fox::String::String()
	{
		data = (StringData*)malloc(sizeof(StringData));
		data->c_str = "";
		data->length = 0;
		data->hash = StrCode(data->c_str, data->length);
	}

	fox::String::String(const char* c_str)
	{
		data = (StringData*)malloc(sizeof(StringData));
		data->c_str = c_str;
		data->length = strlen(c_str);
		data->hash = StrCode(data->c_str, data->length);
	}

	fox::String::String(String const& other)
	{
		data = (StringData*)malloc(sizeof(StringData));
		data->c_str = other.data->c_str;
		data->length = other.data->length;
		data->hash = other.data->hash;
	}

	fox::String::~String()
	{
		free(data);
	}

	const char* fox::String::CString() const
	{
		return data->c_str;
	}

	StringId fox::String::GetHash() const
	{
		return data->hash;
	}

	uint fox::String::GetLength() const
	{
		return data->length;
	}

	bool fox::String::IsEmpty() const
	{
		return data->length > 0 ? false : true;
	}

	bool fox::String::operator!=(String const& other) const
	{
		return other.data->hash != data->hash;
	}

	bool fox::String::operator==(String const& other) const
	{
		return other.data->hash == data->hash;
	}

	fox::String::operator StringId() const
	{
		return data->hash;
	}

	const String& fox::String::operator=(String const& other)
	{
		other.data->c_str = data->c_str;
		other.data->length = data->length;
		other.data->hash = data->hash;

		return other;
	}
}