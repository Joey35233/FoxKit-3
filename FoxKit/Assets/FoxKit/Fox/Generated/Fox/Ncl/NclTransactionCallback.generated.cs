//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using CsSystem = System;
using Fox;

namespace Fox.Ncl
{
    public partial class NclTransactionCallback 
    {
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public virtual Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static NclTransactionCallback()
        {
            classInfo = new Fox.EntityInfo("NclTransactionCallback", null, 0, null, 0);
			
        }

        // Constructor
		
        
        public virtual void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
    }
}