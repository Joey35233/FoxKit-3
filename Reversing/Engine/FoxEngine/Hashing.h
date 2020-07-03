#pragma once
#include <cstring>
#include "Types.h"
#include "city.h"
#include "String.h"

namespace fox
{
	using StringId = ulong;
	using StringId32 = uint;

    StringId StrCode(const char* str, uint length);

    StringId32 StrCode32(const char* str, uint length);

    StringId PathFileNameCode(const char* str, uint length);

    StringId32 PathFileNameCode32(const char* str, uint length);

    StringId PathFileNameAndExtCode(const char* str, uint length);
    StringId PathFileNameAndExtCode(const char* str, uint length, const char* ext, uint extLength);
}