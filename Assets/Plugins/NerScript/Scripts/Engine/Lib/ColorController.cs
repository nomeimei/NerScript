using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NerScript
{
    /// <summary>
    /// 拡張メソッド
    /// </summary>
    public static class ColorController
    {

        #region Set
        /// <summary>
        /// 色の設定
        /// 設定しない場合は-1
        /// </summary>
        public static Color SetColor(this Color c, float r, float g, float b, float a)
        {
            if (0 <= r)
            {
                c = new Color(r, c.g, c.b, c.a);
            }
            if (0 <= g)
            {
                c = new Color(c.r, g, c.b, c.a);
            }
            if (0 <= b)
            {
                c = new Color(c.r, c.g, b, c.a);
            }
            if (0 <= a)
            {
                c = new Color(c.r, c.g, c.b, a);
            }
            return c;
        }
        public static Color SetRed(this Color c, float r)
        {
            c = new Color(r, c.g, c.b, c.a);
            return c;
        }
        public static Color SetGreen(this Color c, float g)
        {
            c = new Color(c.r, c.g, c.b, c.a);
            return c;
        }
        public static Color SetBlue(this Color c, float b)
        {
            c = new Color(c.r, c.g, b, c.a);
            return c;
        }
        public static Color SetAlpha(this Color c, float a)
        {
            c = new Color(c.r, c.g, c.b, a);
            return c;
        }
        #endregion
        #region Add
        public static Color AddColor(this Color c, float r, float g, float b, float a)
        {
            c = c + new Color(r, g, b, a);
            return c;
        }
        public static Color AddRed(this Color c, float r)
        {
            c = new Color(c.r + r, c.g, c.b, c.a);
            return c;
        }
        public static Color AddGreen(this Color c, float g)
        {
            c = new Color(c.r, c.g + g, c.b, c.a);
            return c;
        }
        public static Color AddBlue(this Color c, float b)
        {
            c = new Color(c.r, c.g, c.b + b, c.a);
            return c;
        }
        public static Color AddAlpha(this Color c, float a)
        {
            c = new Color(c.r, c.g, c.b, c.a + a);
            return c;
        }
        #endregion
    }
}