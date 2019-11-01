using System;
using System.Collections.Generic;
using System.Linq;

namespace NerScript
{
    public static class MathLib
    {
        #region Contains
        public static bool Contains(this int self, int min, int max) => min <= self && self <= max;
        public static bool Contains(this float self, float min, float max) => min <= self && self <= max;
        #endregion

        #region Clamp

        public static int Clamp(this ref int self, int min, int max)
        {
            if (self < min) self = min;
            else if (max < self) self = max;
            return self;
        }
        public static int ClampMin(this ref int self, int min) { if (self < min) self = min; return self; }
        public static int ClampMax(this ref int self, int max) { if (max < self) self = max; return self; }

        public static float Clamp(this ref float self, float min, float max)
        {
            if (self < min) self = min;
            else if (max < self) self = max;
            return self;
        }
        public static float ClampMin(this ref float self, float min) { if (self < min) self = min; return self; }
        public static float ClampMax(this ref float self, float max) { if (max < self) self = max; return self; }


        #endregion
    }
}
