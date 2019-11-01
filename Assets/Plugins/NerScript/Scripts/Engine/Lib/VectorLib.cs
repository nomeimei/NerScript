using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Vector2;
using static UnityEngine.Vector3;
using static UnityEngine.Vector4;

namespace NerScript
{
    public static class VectorLib
    {
        #region Vector

        public static Vector2 ToVector2(this int i)=> new Vector2(i, 0);
        public static Vector2 ToVector2(this float f)=> new Vector2(f, 0);

        #endregion

        #region Vector2


        #region Seted
        /// <summary>
        /// セットされた物を返す
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector2 Seted(this Vector2 v, float? x, float? y)
        {
            return new Vector2(x ?? v.x, y ?? v.y);
        }
        public static Vector2 SetedX(this Vector2 v, float x) { v.x = x; return v; }
        public static Vector2 SetedY(this Vector2 v, float y) { v.y = y; return v; }
        #endregion

        #region Added
        /// <summary>
        /// アドされた物を返す
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector2 Added(this Vector2 v, float? x, float? y)
        {
            return new Vector2(x ?? v.x, y ?? v.y);
        }
        public static Vector2 AddedX(this Vector2 v, float x) { v.x += x; return v; }
        public static Vector2 AddedY(this Vector2 v, float y) { v.y += y; return v; }
        #endregion

        #region Clamp

        public static clampvec2 Clamp(this Vector2 v) => new clampvec2(v);
        public static Vector2 Clamp(this Vector2 v, Vector2 min, Vector2 max) => new clampvec2(v).Clamp(min, max);
        public struct clampvec2
        {
            private Vector2 v;
            public clampvec2(Vector2 vec) { v = vec; }
            public Vector2 Clamp(float minX, float minY, float maxX, float maxY)
            {
                if (v.x < minX) v.x = minX;
                if (v.y < minY) v.y = minY;
                if (maxX < v.x) v.x = maxX;
                if (maxY < v.y) v.y = maxY;
                return v;
            }
            public Vector2 Clamp(Vector2 min, Vector2 max) => Clamp(min.x, min.y, max.x, max.y);
            public Vector2 ClampMax(Vector2 max) => Clamp(v.x, v.y, max.x, max.y);
            public Vector2 ClampMax(float x, float y) => Clamp(v.x, v.y, x, y);
            public Vector2 ClampMin(Vector2 min) => Clamp(min.x, min.y, v.x, v.y);
            public Vector2 ClampMin(float x, float y) => Clamp(x, y, v.x, v.y);
            public Vector2 ClampX(float min, float max)
            {
                if (v.x < min) v.x = min;
                if (max < v.x) v.x = max;
                return v;
            }
            public Vector2 ClampY(float min, float max)
            {
                if (v.y < min) v.y = min;
                if (max < v.y) v.y = max;
                return v;
            }
            public Vector2 ClampMaxX(float max) { if (max < v.x) v.x = max; return v; }
            public Vector2 ClampMaxY(float max) { if (max < v.y) v.y = max; return v; }
            public Vector2 ClampMinX(float min) { if (v.x < min) v.x = min; return v; }
            public Vector2 ClampMinY(float min) { if (v.y < min) v.y = min; return v; }
        }

        #endregion

        #region DegRad

        public static float VectorToRad(this Vector2 thisVec) => Mathf.Atan2(thisVec.y, thisVec.x);
        public static float VectorToRad(float x, float y) => Mathf.Atan2(y, x);

        public static Vector2 RadToVector(this float thisFloat) => new Vector2(Mathf.Cos(thisFloat), Mathf.Sin(thisFloat));

        public static float VectorToDeg(this Vector2 thisVec) => Mathf.Atan2(thisVec.y, thisVec.x) * Mathf.Rad2Deg;
        public static float VectorToDeg(float x, float y) => Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        public static Vector2 DegToVector(this float thisFloat) => new Vector2(Mathf.Cos(thisFloat * Mathf.Deg2Rad), Mathf.Sin(thisFloat * Mathf.Deg2Rad));

        public static Vector2 RotateLerp(Vector2 start, float lotateDeg, float lerp)
        {
            float nowDeg = start.VectorToDeg() + (lotateDeg * lerp);
            return nowDeg.DegToVector();
        }

        public static Vector2 RotateLerp(Vector2 origin, Vector2 start, float lotateDeg, float lerp)
        {
            return RotateLerp(start - origin, lotateDeg, lerp) + origin;
        }


        #endregion

        #region Convert

        public static tovec3 ToVec3(this Vector2 v) => new tovec3(v);

        public struct tovec3
        {
            public Vector2 v;
            private const float v_0 = 0;
            public tovec3(Vector2 vector) { v = vector; }
            public Vector3 XXX => new Vector3(v.x, v.x, v.x);
            public Vector3 XXY => new Vector3(v.x, v.x, v.y);
            public Vector3 XYX => new Vector3(v.x, v.y, v.x);
            public Vector3 YXX => new Vector3(v.y, v.x, v.x);
            public Vector3 XYY => new Vector3(v.x, v.y, v.y);
            public Vector3 YXY => new Vector3(v.y, v.x, v.y);
            public Vector3 YYX => new Vector3(v.y, v.y, v.x);
            public Vector3 YYY => new Vector3(v.y, v.y, v.y);

            public Vector3 XXO => new Vector3(v.x, v.x, v_0);
            public Vector3 XOX => new Vector3(v.x, v_0, v.x);
            public Vector3 OXX => new Vector3(v_0, v.x, v.x);
            public Vector3 XOO => new Vector3(v.x, v_0, v_0);
            public Vector3 OXO => new Vector3(v_0, v.x, v_0);
            public Vector3 OOX => new Vector3(v_0, v_0, v.x);

            public Vector3 YYO => new Vector3(v.y, v.y, v_0);
            public Vector3 YOY => new Vector3(v.y, v_0, v.y);
            public Vector3 OYY => new Vector3(v_0, v.y, v.y);
            public Vector3 YOO => new Vector3(v.y, v_0, v_0);
            public Vector3 OYO => new Vector3(v_0, v.y, v_0);
            public Vector3 OOY => new Vector3(v_0, v_0, v.y);

            public Vector3 XYO => new Vector3(v.x, v.y, v_0);
            public Vector3 XOY => new Vector3(v.x, v_0, v.y);
            public Vector3 OXY => new Vector3(v_0, v.x, v.y);

            public Vector3 YXO => new Vector3(v.y, v.x, v_0);
            public Vector3 YOX => new Vector3(v.y, v_0, v.x);
            public Vector3 OYX => new Vector3(v_0, v.y, v.x);

            public Vector3 OOO => new Vector3(v_0, v_0, v_0);

        }

        #endregion

        #region Merge
        public static mergevec2 MergeVec2(this Vector2 v, Vector2 V = new Vector2()) => new mergevec2(v, V);

        public struct mergevec2
        {
            public Vector2 v;
            public Vector2 V;
            public mergevec2(Vector2 vec, Vector2 Vec) { v = vec; V = Vec; }

            public Vector2 this[string str]
            {
                get {
                    Vector2 result = Vector2.zero;
                    if (str.Length < 2) return result;
                    result.x = GetFloat(str[0]);
                    result.y = GetFloat(str[1]);
                    return result;
                }
            }

            private float GetFloat(char axis)
            {
                float res = 0;
                switch (axis)
                {
                    case 'x': res = v.x; break;
                    case 'y': res = v.y; break;
                    case 'X': res = V.x; break;
                    case 'Y': res = V.y; break;
                    default: res = 0; break;
                }
                return res;
            }

        }



        #endregion

        #endregion

        #region Vector3

        #region Seted
        /// <summary>
        /// セットされた物を返す
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 Seted(this Vector3 v, float? x, float? y, float? z)
        {
            return new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
        }
        public static Vector3 SetedX(this Vector3 v, float x) { v.x = x; return v; }
        public static Vector3 SetedY(this Vector3 v, float y) { v.y = y; return v; }
        public static Vector3 SetedZ(this Vector3 v, float z) { v.z = z; return v; }
        #endregion

        #region Added
        /// <summary>
        /// アドされた物を返す
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 Added(this Vector3 v, float? x, float? y, float? z)
        {
            return new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
        }
        public static Vector3 AddedX(this Vector3 v, float x) { v.x += x; return v; }
        public static Vector3 AddedY(this Vector3 v, float y) { v.y += y; return v; }
        public static Vector3 AddedZ(this Vector3 v, float z) { v.z += z; return v; }
        #endregion

        #region Clamp

        public static clampvec3 Clamp(this Vector3 v) => new clampvec3(v);
        public static Vector3 Clamp(this Vector3 v, Vector3 min, Vector3 max) => new clampvec3(v).Clamp(min, max);
        public struct clampvec3
        {
            private Vector3 v;
            public clampvec3(Vector3 vec) { v = vec; }
            public Vector3 Clamp(float minX, float minY, float minZ, float maxX, float maxY, float maxZ)
            {
                if (v.x < minX) v.x = minX;
                if (v.y < minY) v.y = minY;
                if (v.z < minZ) v.z = minZ;
                if (maxX < v.x) v.x = maxX;
                if (maxY < v.y) v.y = maxY;
                if (maxZ < v.z) v.z = maxZ;
                return v;
            }
            public Vector3 Clamp(Vector3 min, Vector3 max)
            {
                return Clamp(min.x, min.y, min.z, max.x, max.y, max.z);
            }
            public Vector3 ClampMax(Vector3 max)
            {
                return Clamp(v.x, v.y, v.z, max.x, max.y, max.z);
            }
            public Vector3 ClampMax(float x, float y, float z)
            {
                return Clamp(v.x, v.y, v.z, x, y, z);
            }
            public Vector3 ClampMin(Vector3 min)
            {
                return Clamp(min.x, min.y, min.z, v.x, v.y, v.z);
            }
            public Vector3 ClampMin(float x, float y, float z)
            {
                return Clamp(x, y, z, v.x, v.y, v.z);
            }
            public Vector3 ClampX(float min, float max)
            {
                if (v.x < min) v.x = min;
                if (max < v.x) v.x = max;
                return v;
            }
            public Vector3 ClampY(float min, float max)
            {
                if (v.y < min) v.y = min;
                if (max < v.y) v.y = max;
                return v;
            }
            public Vector3 ClampZ(float min, float max)
            {
                if (v.z < min) v.z = min;
                if (max < v.z) v.z = max;
                return v;
            }
            public Vector3 ClampMaxX(float max)
            {
                if (max < v.x) v.x = max;
                return v;
            }
            public Vector3 ClampMaxY(float max)
            {
                if (max < v.y) v.y = max;
                return v;
            }
            public Vector3 ClampMaxZ(float max)
            {
                if (max < v.z) v.z = max;
                return v;
            }
            public Vector3 ClampMinX(float min)
            {
                if (v.x < min) v.x = min;
                return v;
            }
            public Vector3 ClampMinY(float min)
            {
                if (v.y < min) v.y = min;
                return v;
            }
            public Vector3 ClampMinZ(float min)
            {
                if (v.z < min) v.z = min;
                return v;
            }
        }

        #endregion

        #region Convert

        public static tovec2 ToVec2(this Vector3 v) => new tovec2(v);

        public struct tovec2
        {
            public Vector3 v;
            private const float v_0 = 0;
            public tovec2(Vector3 vector) { v = vector; }
            public Vector2 XX => new Vector2(v.x, v.x);
            public Vector2 XY => new Vector2(v.x, v.y);
            public Vector2 XZ => new Vector2(v.x, v.z);
            public Vector2 YX => new Vector2(v.y, v.x);
            public Vector2 YY => new Vector2(v.y, v.y);
            public Vector2 YZ => new Vector2(v.y, v.z);
            public Vector2 ZX => new Vector2(v.z, v.x);
            public Vector2 ZY => new Vector2(v.z, v.y);
            public Vector2 ZZ => new Vector2(v.z, v.z);

            public Vector2 XO => new Vector2(v.x, v_0);
            public Vector2 YO => new Vector2(v.y, v_0);
            public Vector2 ZO => new Vector2(v.z, v_0);
            public Vector2 OX => new Vector2(v_0, v.x);
            public Vector2 OY => new Vector2(v_0, v.y);
            public Vector2 OZ => new Vector2(v_0, v.z);

            public Vector2 OO => new Vector2(v_0, v_0);

        }

        #endregion

        #region Sort 

        public static sortvec3 SortVec3(this Vector3 v) => new sortvec3(v);

        public struct sortvec3
        {
            public Vector3 v;
            public sortvec3(Vector3 vec) { v = vec; }

            public Vector3 XXX => new Vector3(v.x, v.x, v.x);

            public Vector3 XXY => new Vector3(v.x, v.x, v.y);
            public Vector3 XYX => new Vector3(v.x, v.y, v.x);
            public Vector3 YXX => new Vector3(v.y, v.x, v.x);
            public Vector3 XYY => new Vector3(v.x, v.y, v.y);
            public Vector3 YXY => new Vector3(v.y, v.x, v.y);
            public Vector3 YYX => new Vector3(v.y, v.y, v.x);
            public Vector3 YYY => new Vector3(v.y, v.y, v.y);

            public Vector3 XXZ => new Vector3(v.x, v.x, v.z);
            public Vector3 XZX => new Vector3(v.x, v.z, v.x);
            public Vector3 ZXX => new Vector3(v.z, v.x, v.x);
            public Vector3 XZZ => new Vector3(v.x, v.z, v.z);
            public Vector3 ZXZ => new Vector3(v.z, v.x, v.z);
            public Vector3 ZZX => new Vector3(v.z, v.z, v.x);
            public Vector3 ZZZ => new Vector3(v.z, v.z, v.z);

            public Vector3 YYZ => new Vector3(v.y, v.y, v.z);
            public Vector3 YZY => new Vector3(v.y, v.z, v.y);
            public Vector3 ZYY => new Vector3(v.z, v.y, v.y);
            public Vector3 YZZ => new Vector3(v.y, v.z, v.z);
            public Vector3 ZYZ => new Vector3(v.z, v.y, v.z);
            public Vector3 ZZY => new Vector3(v.z, v.z, v.y);

            public Vector3 XYZ => new Vector3(v.x, v.y, v.z);
            public Vector3 XZY => new Vector3(v.x, v.z, v.y);
            public Vector3 ZXY => new Vector3(v.z, v.x, v.y);
            public Vector3 YXZ => new Vector3(v.y, v.x, v.z);
            public Vector3 YZX => new Vector3(v.y, v.z, v.x);
            public Vector3 ZYX => new Vector3(v.z, v.y, v.x);

            public Vector3 XXO => new Vector3(v.x, v.x, 0);
            public Vector3 XOX => new Vector3(v.x, 0, v.x);
            public Vector3 OXX => new Vector3(0, v.x, v.x);
            public Vector3 XOO => new Vector3(v.x, 0, 0);
            public Vector3 OXO => new Vector3(0, v.x, 0);
            public Vector3 OOX => new Vector3(0, 0, v.x);

            public Vector3 YYO => new Vector3(v.y, v.y, 0);
            public Vector3 YOY => new Vector3(v.y, 0, v.y);
            public Vector3 OYY => new Vector3(0, v.y, v.y);
            public Vector3 YOO => new Vector3(v.y, 0, 0);
            public Vector3 OYO => new Vector3(0, v.y, 0);
            public Vector3 OOY => new Vector3(0, 0, v.y);

            public Vector3 ZZO => new Vector3(v.z, v.z, 0);
            public Vector3 ZOZ => new Vector3(v.z, 0, v.z);
            public Vector3 OZZ => new Vector3(0, v.z, v.z);
            public Vector3 ZOO => new Vector3(v.z, 0, 0);
            public Vector3 OZO => new Vector3(0, v.z, 0);
            public Vector3 OOZ => new Vector3(0, 0, v.z);


            public Vector3 XYO => new Vector3(v.x, v.y, 0);
            public Vector3 XOY => new Vector3(v.x, 0, v.y);
            public Vector3 OXY => new Vector3(0, v.x, v.y);
            public Vector3 YXO => new Vector3(v.x, v.y, 0);
            public Vector3 YOX => new Vector3(v.x, 0, v.y);
            public Vector3 OYX => new Vector3(0, v.x, v.y);

            public Vector3 XZO => new Vector3(v.x, v.z, 0);
            public Vector3 XOZ => new Vector3(v.x, 0, v.z);
            public Vector3 OXZ => new Vector3(0, v.x, v.z);
            public Vector3 ZXO => new Vector3(v.x, v.z, 0);
            public Vector3 ZOX => new Vector3(v.x, 0, v.z);
            public Vector3 OZX => new Vector3(0, v.x, v.z);

            public Vector3 YZO => new Vector3(v.y, v.z, 0);
            public Vector3 YOZ => new Vector3(v.y, 0, v.z);
            public Vector3 OYZ => new Vector3(0, v.y, v.z);
            public Vector3 ZYO => new Vector3(v.y, v.z, 0);
            public Vector3 ZOY => new Vector3(v.y, 0, v.z);
            public Vector3 OZY => new Vector3(0, v.y, v.z);


            public Vector3 OOO => new Vector3(0, 0, 0);
        }

        #endregion

        #region Merge
        public static mergevec3 MergeVec3(this Vector3 v, Vector3 V = new Vector3()) => new mergevec3(v, V);

        public struct mergevec3
        {
            public Vector3 v;
            public Vector3 V;
            public mergevec3(Vector3 vec, Vector3 Vec) { v = vec; V = Vec; }

            public Vector3 this[string str]
            {
                get {
                    Vector3 result = Vector3.zero;

                    if (str.Length < 3) return result;

                    result.x = GetFloat(str[0]);
                    result.y = GetFloat(str[1]);
                    result.z = GetFloat(str[2]);

                    return result;
                }
            }

            private float GetFloat(char axis)
            {
                float res = 0;
                switch (axis)
                {
                    case 'x': res = v.x; break;
                    case 'y': res = v.y; break;
                    case 'z': res = v.z; break;
                    case 'X': res = V.x; break;
                    case 'Y': res = V.y; break;
                    case 'Z': res = V.z; break;
                    default: res = 0; break;
                }
                return res;
            }

        }

        public enum VectorAxisMatch
        {
            OOO, OOX, OOY, OOZ, OXO, OXX, OXY, OXZ, OYO, OYX, OYY, OYZ, OZO, OZX, OZY, OZZ,
            XOO, XOX, XOY, XOZ, XXO, XXX, XXY, XXZ, XYO, XYX, XYY, XYZ, XZO, XZX, XZY, XZZ,
            YOO, YOX, YOY, YOZ, YXO, YXX, YXY, YXZ, YYO, YYX, YYY, YYZ, YZO, YZX, YZY, YZZ,
            ZOO, ZOX, ZOY, ZOZ, ZXO, ZXX, ZXY, ZXZ, ZYO, ZYX, ZYY, ZYZ, ZZO, ZZX, ZZY, ZZZ,
        }

        #endregion

        public static Vector3 Division(this Vector3 self, Vector3 over)
        {
            self.x /= over.x;
            self.y /= over.y;
            self.z /= over.z;
            return self;
        }

        public static float GetAxis(this Vector3 self, Axis axis)
        {
            if (axis == Axis.Z) return self.z;
            else if (axis == Axis.Y) return self.y;
            return self.x;
        }
        public static Vector3 SetedAxis(this Vector3 self, Axis axis, float value)
        {
            if (axis == Axis.X) self.x = value;
            else if (axis == Axis.Y) self.y = value;
            else if (axis == Axis.Z) self.z = value;
            return self;
        }
        public static Vector3 AddedAxis(this Vector3 self, Axis axis, float value)
        {
            if (axis == Axis.X) self.x += value;
            else if (axis == Axis.Y) self.y += value;
            else if (axis == Axis.Z) self.z += value;
            return self;
        }

        #endregion

        #region Move
        public static Vector2 ToVector(this Vector2 v, Vector2 to, float velocity) => MoveTowards(v, to, velocity);
        public static Vector3 ToVector(this Vector3 v, Vector3 to, float velocity) => MoveTowards(v, to, velocity);


        public static Vector2 ToZero(this Vector2 v, float velocity) => MoveTowards(v, Vector2.zero, velocity);
        public static Vector3 ToZero(this Vector3 v, float velocity) => MoveTowards(v, Vector3.zero, velocity);



        #endregion

    }
}
