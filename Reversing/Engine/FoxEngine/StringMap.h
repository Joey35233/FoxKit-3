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
		uint unknown;
		uint count;
		uint capacity;
		Cell** cells;
		Cell* smUnknown0;
		Cell* smUnknown1;
		uint test; // StringMap is 48 bytes. Missing 4 otherwise, but this specific variable order actually means the struct won't comply with alignment rules (cells, smUnknown0, and smUnknown1) cross alignment boundaries.
	};
}