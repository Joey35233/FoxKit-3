﻿using Fox.Core;

namespace Fox.Sim
{
    public partial class SimInertialControl : Fox.Sim.SimControlElement
    {
        private SimInertialControlParam param => (controlParam.Get() as SimInertialControlParam);

        protected partial float Get_inertialCoefficient() => param.GetCoefficient();
        protected partial void Set_inertialCoefficient(float value) { param.SetCoefficient(value); }
    }
}