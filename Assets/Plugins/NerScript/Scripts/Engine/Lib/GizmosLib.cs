using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Gizmos;

namespace NerScript
{
    //参考サイト
    // https://github.com/code-beans/GizmoExtensions


    /// <summary>
    /// 拡張メソッド
    /// </summary>
    public class GizmosLib
    {
        #region 3D
        /// <summary>
        /// キューブの描画
        /// </summary>
        /// <param name="center"></param>
        /// <param name="size"></param>
        /// <param name="rotation"></param>
        public static void DrawCube(Vector3 center, Vector3 size, Quaternion rotation = default(Quaternion))
        {
            var old = matrix;
            if (rotation.Equals(default(Quaternion)))
                rotation = Quaternion.identity;
            matrix = Matrix4x4.TRS(center, rotation, size);
            DrawWireCube(Vector3.zero, Vector3.one);
            matrix = old;
        }
        /// <summary>
        /// スフィアの描画
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="rotation"></param>
        public static void DrawSphere(Vector3 center, float radius, Quaternion rotation = default(Quaternion))
        {
            var old = matrix;
            if (rotation.Equals(default(Quaternion)))
                rotation = Quaternion.identity;
            matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
            DrawWireSphere(Vector3.zero, radius);
            matrix = old;
        }
        /// <summary>
        /// 円の描画
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="segments"></param>
        /// <param name="rotation"></param>
        public static void DrawCircle(Vector3 center, float radius, int segments = 20, Quaternion rotation = default(Quaternion))
        {
            DrawArc(center, radius, 360, segments, rotation);
        }
        /// <summary>
        /// アーチの描画？
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="angle"></param>
        /// <param name="segments"></param>
        /// <param name="rotation"></param>
        public static void DrawArc(Vector3 center, float radius, float angle, int segments = 20, Quaternion rotation = default(Quaternion))
        {

            var old = matrix;
            if (rotation.Equals(default(Quaternion)))
                rotation = Quaternion.identity;
            matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
            Vector3 from = Vector3.forward * radius;
            var step = Mathf.RoundToInt(angle / segments);
            for (int i = 0; i <= angle; i += step)
            {
                var to = new Vector3(radius * Mathf.Sin(i * Mathf.Deg2Rad), 0, radius * Mathf.Cos(i * Mathf.Deg2Rad));
                DrawLine(from, to);
                from = to;
            }

            matrix = old;
        }
        /// <summary>
        /// アーチの描画？
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="angle"></param>
        /// <param name="segments"></param>
        /// <param name="rotation"></param>
        /// <param name="centerOfRotation"></param>
        public static void DrawArc(Vector3 center, float radius, float angle, int segments, Quaternion rotation, Vector3 centerOfRotation)
        {

            var old = matrix;
            if (rotation.Equals(default(Quaternion)))
                rotation = Quaternion.identity;
            matrix = Matrix4x4.TRS(centerOfRotation, rotation, Vector3.one);
            var deltaTranslation = centerOfRotation - center;
            Vector3 from = deltaTranslation + Vector3.forward * radius;
            var step = Mathf.RoundToInt(angle / segments);
            for (int i = 0; i <= angle; i += step)
            {
                var to = new Vector3(radius * Mathf.Sin(i * Mathf.Deg2Rad), 0, radius * Mathf.Cos(i * Mathf.Deg2Rad)) + deltaTranslation;
                DrawLine(from, to);
                from = to;
            }

            matrix = old;
        }
        /// <summary>
        /// アーチの描画？
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="radius"></param>
        /// <param name="angle"></param>
        /// <param name="segments"></param>
        public static void DrawArc(Matrix4x4 matrix, float radius, float angle, int segments)
        {
            var old = matrix;
            UnityEngine.Gizmos.matrix = matrix;
            Vector3 from = Vector3.forward * radius;
            var step = Mathf.RoundToInt(angle / segments);
            for (int i = 0; i <= angle; i += step)
            {
                var to = new Vector3(radius * Mathf.Sin(i * Mathf.Deg2Rad), 0, radius * Mathf.Cos(i * Mathf.Deg2Rad));
                DrawLine(from, to);
                from = to;
            }

            matrix = old;
        }
        /// <summary>
        /// シリンダーの描画
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="rotation"></param>
        public static void DrawCylinder(Vector3 center, float radius, float height, Quaternion rotation = default(Quaternion))
        {
            var old = matrix;
            if (rotation.Equals(default(Quaternion)))
                rotation = Quaternion.identity;
            matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
            var half = height / 2;

            //draw the 4 outer lines
            DrawLine(Vector3.right * radius - Vector3.up * half, Vector3.right * radius + Vector3.up * half);
            DrawLine(-Vector3.right * radius - Vector3.up * half, -Vector3.right * radius + Vector3.up * half);
            DrawLine(Vector3.forward * radius - Vector3.up * half, Vector3.forward * radius + Vector3.up * half);
            DrawLine(-Vector3.forward * radius - Vector3.up * half, -Vector3.forward * radius + Vector3.up * half);

            //draw the 2 cricles with the center of rotation being the center of the cylinder, not the center of the circle itself
            DrawArc(center + Vector3.up * half, radius, 360, 20, rotation, center);
            DrawArc(center + Vector3.down * half, radius, 360, 20, rotation, center);
            matrix = old;
        }
        /// <summary>
        /// カプセルの描画
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="rotation"></param>
        public static void DrawCapsule(Vector3 center, float radius, float height, Quaternion rotation = default(Quaternion))
        {
            if (rotation.Equals(default(Quaternion)))
                rotation = Quaternion.identity;
            var old = matrix;
            matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
            var half = height / 2 - radius;

            //draw cylinder base
            DrawCylinder(center, radius, height - radius * 2, rotation);

            //draw upper cap
            //do some cool stuff with orthogonal matrices
            var mat = Matrix4x4.Translate(center + rotation * Vector3.up * half) * Matrix4x4.Rotate(rotation * Quaternion.AngleAxis(90, Vector3.forward));
            DrawArc(mat, radius, 180, 20);
            mat = Matrix4x4.Translate(center + rotation * Vector3.up * half) * Matrix4x4.Rotate(rotation * Quaternion.AngleAxis(90, Vector3.up) * Quaternion.AngleAxis(90, Vector3.forward));
            DrawArc(mat, radius, 180, 20);

            //draw lower cap
            mat = Matrix4x4.Translate(center + rotation * Vector3.down * half) * Matrix4x4.Rotate(rotation * Quaternion.AngleAxis(90, Vector3.up) * Quaternion.AngleAxis(-90, Vector3.forward));
            DrawArc(mat, radius, 180, 20);
            mat = Matrix4x4.Translate(center + rotation * Vector3.down * half) * Matrix4x4.Rotate(rotation * Quaternion.AngleAxis(-90, Vector3.forward));
            DrawArc(mat, radius, 180, 20);

            matrix = old;
        }

        #endregion

        #region 2D
        /// <summary>
        /// 矩形の描画
        /// </summary>
        /// <param name="center"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotation"></param>
        public static void DrawRect(Vector3 center, float width, float height, Quaternion rotation = default(Quaternion))
        {
            var old = matrix;
            if (rotation.Equals(default(Quaternion)))
                rotation = Quaternion.identity;
            matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
            DrawLines(
                new Vector3(width / 2, 0, height / 2),
                new Vector3(width / 2, 0, -height / 2),
                new Vector3(-width / 2, 0, -height / 2),
                new Vector3(-width / 2, 0, height / 2)
                );
            matrix = old;
        }
        /// <summary>
        /// 矩形の描画
        /// </summary>
        /// <param name="center"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotation"></param>
        public static void DrawRect(Vector3 center, Vector2 area, Quaternion rotation = default(Quaternion))
        {
            DrawRect(center, area.x, area.y, rotation);
        }
        /// <summary>
        /// 矩形の描画
        /// </summary>
        /// <param name="center"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotation"></param>
        public static void DrawRect(Rect rect)
        {
            DrawRect(rect.center, rect.width, rect.height);
        }
        /// <summary>
        /// 矢印の描画
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="arrowHeadLength"></param>
        /// <param name="arrowHeadAngle"></param>
        public static void DrawArrow(Vector3 from, Vector3 to, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
        {
            DrawLine(from, to);
            var direction = to - from;
            var right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            var left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            DrawLine(to, to + right * arrowHeadLength);
            DrawLine(to, to + left * arrowHeadLength);
        }

        #region DrawLineExtension
        /// <summary>
        /// 複数線の描画
        /// </summary>
        /// <param name="points"></param>
        public static void DrawLines(params Vector3[] points)
        {
            int last = points.Length - 1;
            for (int i = 0; i < last; i++)
            {
                DrawLine(points[i], points[i + 1]);
            }
            DrawLine(points[last], points[0]);
        }
        /// <summary>
        /// 線の終端に球の描画
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="radius"></param>
        public static void DrawLine_EndSphere(Vector3 from, Vector3 to, float radius = 0.1f)
        {
            DrawLine(from, to);
            DrawSphere(to, radius);
        }
        /// <summary>
        /// 線の始端に球の描画
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="radius"></param>
        public static void DrawLine_StartSphere(Vector3 from, Vector3 to, float radius = 0.1f)
        {
            DrawLine(from, to);
            DrawSphere(from, radius);
        }
        /// <summary>
        /// 線の両端に球の描画
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="radius"></param>
        public static void DrawLine_Sphere(Vector3 from, Vector3 to, float radius = 0.1f)
        {
            DrawLine(from, to);
            DrawSphere(from, radius);
            DrawSphere(to, radius);
        }
        #endregion

        #endregion


        public static ColoringScop Coloring(Color color) => new ColoringScop(color);


        public class ColoringScop : IDisposable
        {
            private Color old;
            public ColoringScop(Color _color)
            {
                old = color;
                color = _color;
            }

            public void Dispose()
            {
                color = old;
            }
        }
    }
}

