using System;

namespace Fox.Kernel
{
    public static class TagUtils
    {
        private static int GetSetBitCount(uint i)
        {
            i -= (i >> 1) & 0x55555555;
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (int)((((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24);
        }

        private static int GetSetBitCount(ulong i) => GetSetBitCount((uint)i) + GetSetBitCount((uint)(i >> 32));

        public static void AddEnumTags<T>(DynamicArray<String> array, uint tags)
        {
            int bitCount = GetSetBitCount(tags);

            var tagsArray = new DynamicArray<String>(bitCount);

            uint mask = 1;
            for (int i = 0; i < bitCount; mask <<= 1)
            {
                uint tag = tags & mask;
                if (tag != 0)
                {
                    if (Enum.IsDefined(typeof(T), tag))
                        tagsArray.Add(new String(Enum.GetName(typeof(T), tag)));
                    else
                        tagsArray.Add(new String(tag.ToString()));

                    i++;
                }
            }
        }

        public static void AddEnumTags<T>(DynamicArray<String> array, ulong tags)
        {
            int bitCount = GetSetBitCount(tags);

            var tagsArray = new DynamicArray<String>(bitCount);

            ulong mask = 1;
            for (int i = 0; i < bitCount; mask <<= 1)
            {
                ulong tag = tags & mask;
                if (tag != 0)
                {
                    if (Enum.IsDefined(typeof(T), tag))
                        tagsArray.Add(new String(Enum.GetName(typeof(T), tag)));
                    else
                        tagsArray.Add(new String(tag.ToString()));

                    i++;
                }
            }
        }
    }
}