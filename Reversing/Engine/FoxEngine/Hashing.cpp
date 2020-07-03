#include "Hashing.h"

namespace fox
{
	StringId StrCode(const char* str, uint length)
	{
		const ulong seed0 = 0x9ae16a3b2f90404f;
		ulong seed1 = (ulong)(length > 0 ? (str[0] << 16) + length : 0);
		return CityHash::CityHash64WithSeeds(str, length + 1, seed0, seed1) & 0xFFFFFFFFFFFF;
	}

	StringId32 StrCode32(const char* str, uint length)
	{
		return (StringId32)StrCode(str, length);
	}

	StringId PathFileNameCode(const char* str, uint length)
	{
		ulong mask = 0x0000000000000000;

		// Test if str starts with "/Assets/"
		if (*(ulong*)str == 0x2f7374657373412f)
		{
			// Trim "/Assets"
			str += 7;
			length -= 7;

			// Test if str starts with "/tpptest"
			if (*(ulong*)str == 0x747365747070742f)
				mask = 0x0004000000000000;
		}
		else
		{
			mask = 0x0004000000000000;
		}

		// Trim '/'
		str += 1;
		length -= 1;

		const ulong seed0 = 0x9ae16a3b2f90404f;
		ulong seed1 = 0;
		for (int i = length - 1, j = 0; i >= 0 && j < sizeof(ulong); i--, j++)
			seed1 |= (ulong)str[i] << (j * 8);

		ulong hash = CityHash::CityHash64WithSeeds(str, length, seed0, seed1) & 0x3FFFFFFFFFFFF;
		return hash | mask;
	}

	StringId32 PathFileNameCode32(const char* str, uint length)
	{
		return (StringId32)PathFileNameCode(str, length);
	}

	StringId PathFileNameAndExtCode(const char* str, uint length)
	{
		const char* ext = strchr(str, '.');
		uint extLength = length - (ext - str);

		return PathFileNameAndExtCode(str, length, ext, extLength);
	}

	StringId PathFileNameAndExtCode(const char* str, uint length, const char* ext, uint extLength)
	{
		return ((PathFileNameCode(ext, extLength) & 0x1FFF) << 51) | PathFileNameCode(str, length);
	}
}