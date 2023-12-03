using Fox.Fio;
using Fox.Kernel;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.UIElements;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    [StructLayout(LayoutKind.Sequential, Size = 0x30)]
    public unsafe struct FoxDataNode
    {
        public FoxDataString Name;
        public uint Flags;
        public int DataOffset;
        public uint DataSize;
        public int ParentNodeOffset;
        public int ChildNodeOffset;
        public int PreviousNodeOffset;
        public int NextNodeOffset;
        public int ParametersOffset;

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

        public FoxDataParameter* GetParameters() => ParametersOffset == 0 ? null : (FoxDataParameter*)((byte*)GetSelfPointer() + ParametersOffset);

        public FoxDataParameter* FindParameter(StrCode32 name)
        {
            for (FoxDataParameter* param = GetParameters(); param != null; param = param->GetNext())
            {
                if (param->Name.Hash == name)
                    return param;
            }

            return null;
        }

        public FoxDataParameter* FindParameter(String name)
        {
            for (FoxDataParameter* param = GetParameters(); param != null; param = param->GetNext())
            {
                if (param->Name.ReadStringFromRelativeOffset() == name)
                    return param;
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
                    return child->FindNode(name);
                }
            }

            return null;
        }
    }
}