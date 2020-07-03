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
			Cell* firstCell;
			Cell* unknown;
			Cell* nextCell;
			T value;
		};

		void* vfptr;
		uint unknown;
		uint count;
		uint capacity;
		Cell** cells;
		Cell firstCell;
	};
}