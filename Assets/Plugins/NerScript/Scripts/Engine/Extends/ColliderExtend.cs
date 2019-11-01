using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NerScript
{
    public static class ColliderExtend
    {
        #region Bounds
        #region 3D
        public static Vector3 MaxPas(this Collider col) { return col.bounds.max; }
        public static float MaxX(this Collider col) { return MaxPas(col).x; }
        public static float MaxY(this Collider col) { return MaxPas(col).y; }
        public static float MaxZ(this Collider col) { return MaxPas(col).z; }
        public static Vector3 MinPas(this Collider col) { return col.bounds.min; }
        public static float MinX(this Collider col) { return MinPas(col).x; }
        public static float MinY(this Collider col) { return MinPas(col).y; }
        public static float MinZ(this Collider col) { return MinPas(col).z; }
        public static Vector3 Center(this Collider col) { return col.bounds.center; }
        #endregion
        #region 2D
        public static Vector2 MaxPas(this Collider2D col) { return col.bounds.max; }
        public static float MaxX(this Collider2D col) { return MaxPas(col).x; }
        public static float MaxY(this Collider2D col) { return MaxPas(col).y; }
        public static Vector2 MinPas(this Collider2D col) { return col.bounds.min; }
        public static float MinX(this Collider2D col) { return MinPas(col).x; }
        public static float MinY(this Collider2D col) { return MinPas(col).y; }
        public static Vector3 Center(this Collider2D col) { return col.bounds.center; }
        public static Vector2 RightUp(this Collider2D col) { return col.MaxPas(); }
        public static Vector2 RightDown(this Collider2D col) { return new Vector2(col.MaxPas().x, col.MinPas().y); }
        public static Vector2 LeftDown(this Collider2D col) { return col.MinPas(); }
        public static Vector2 LeftUp(this Collider2D col) { return new Vector2(col.MinPas().x, col.MaxPas().y); }
        #endregion
        #endregion
    }
}
