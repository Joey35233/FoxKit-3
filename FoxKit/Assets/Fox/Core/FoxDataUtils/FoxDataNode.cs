using Fox.Fio;
using Fox;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.UIElements;

namespace Fox.Core
{
    [StructLayout(LayoutKind.Sequential, Size = SelfSize)]
    public unsafe struct FoxDataNode
    {
        public const int SelfSize = 0x30;
        
        public FoxDataString Name;
        public uint Flags;
        public int DataOffset;
        public uint DataSize;
        public int ParentNodeOffset;
        public int ChildNodeOffset;
        public int PreviousNodeOffset;
        public int NextNodeOffset;
        public int Attributes;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FoxDataNode* GetSelfPointer()
        {
            fixed (FoxDataNode* selfPtr = &this)
            {
                return selfPtr;
            }
        }

        public byte* GetData() => DataOffset == 0 ? null : (byte*)GetSelfPointer() + DataOffset;

        public FoxDataNode* GetParent() => ParentNodeOffset == 0 ? null : (FoxDataNode*)((byte*)GetSelfPointer() + ParentNodeOffset);

        public FoxDataNode* GetChildren() => ChildNodeOffset == 0 ? null : (FoxDataNode*)((byte*)GetSelfPointer() + ChildNodeOffset);

        public FoxDataNode* GetPrevious() => PreviousNodeOffset == 0 ? null : (FoxDataNode*)((byte*)GetSelfPointer() + PreviousNodeOffset);

        public FoxDataNode* GetNext() => NextNodeOffset == 0 ? null : (FoxDataNode*)((byte*)GetSelfPointer() + NextNodeOffset);

        public FoxDataNodeAttribute* GetAttributes() => Attributes == 0 ? null : (FoxDataNodeAttribute*)((byte*)GetSelfPointer() + Attributes);

        public FoxDataNodeAttribute* FindAttribute(StrCode32 name)
        {
            for (FoxDataNodeAttribute* attribute = GetAttributes(); attribute != null; attribute = attribute->GetNext())
            {
                if (attribute->Name.Hash == name)
                    return attribute;
            }

            return null;
        }

        public FoxDataNodeAttribute* FindAttribute(string name)
        {
            for (FoxDataNodeAttribute* attribute = GetAttributes(); attribute != null; attribute = attribute->GetNext())
            {
                if (attribute->Name.ReadStringFromRelativeOffset() == name)
                    return attribute;
            }

            return null;
        }

        public FoxDataNode* FindNode(StrCode32 name)
        {
            for (FoxDataNode* node = GetSelfPointer(); node != null; node = node->GetNext())
            {
                if (node->Name.Hash == name)
                    return node;

                FoxDataNode* child = node->GetChildren();
                if (child is not null)
                {
                    FoxDataNode* childSearchResult = child->FindNode(name);
                    if (childSearchResult is not null)
                        return childSearchResult;
                }
            }

            return null;
        }

        public FoxDataNode* FindNode(string name)
        {
            for (FoxDataNode* node = GetSelfPointer(); node != null; node = node->GetNext())
            {
                if (node->Name.Hash == new StrCode32(name))
                    return node;

                FoxDataNode* child = node->GetChildren();
                if (child is not null)
                {
                    FoxDataNode* childSearchResult = child->FindNode(name);
                    if (childSearchResult is not null)
                        return childSearchResult;
                }
            }

            return null;
        }
    }
}