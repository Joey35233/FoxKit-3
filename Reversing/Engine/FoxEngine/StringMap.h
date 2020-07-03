#pragma once
#include "String.h"

namespace fox
{
	template<typename T>
	struct StringMap
	{
		void Insert(String const& key, T const& value)
		{
		}

		void ChangeHashSize(uint newSize)
		{

		}

		T operator[](fox::String const& string)
		{
			return T{};
		}

	private:

		struct Cell
		{
			String* key;
			Cell* cUnknown0;
			Cell* cUnknown1;
			Cell* cUnknown2;
			T value;
		};

		void* vfptr;
		uint unknown; // pading for 8-byte alignment?
		uint count;
		uint capacity;
		Cell** cells;
		Cell* smUnknown0;
		Cell* smUnknown1;
	};
}