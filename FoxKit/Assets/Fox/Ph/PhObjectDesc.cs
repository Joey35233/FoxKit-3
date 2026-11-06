using System.Collections.Generic;

namespace Fox.Ph
{
    public partial class PhObjectDesc
    {
        public List<Fox.Core.Entity> Bodies => bodies;
        public List<int> BodyIndices => bodyIndices;
        public List<Fox.Ph.PhConstraintParam> Constraints => constraints;
    }
}
