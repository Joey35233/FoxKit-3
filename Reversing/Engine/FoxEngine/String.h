#pragma once
#include "StringId.h"
#include "Hashing.h"

namespace fox
{
	struct StringData
	{
		const char* c_str;
		uint length;
		StringId hash;
	};

	struct String
	{
		String();
		String(const char* c_str);
		String(String const& other);

		~String();

		const char* CString() const;
		StringId GetHash() const;
		uint GetLength() const;

		bool IsEmpty() const;

		bool operator!=(String const& other) const;
		bool operator==(String const& other) const;
		operator StringId() const;

		const String& operator=(String const& other);

	private:
		StringData* data;
	};
}