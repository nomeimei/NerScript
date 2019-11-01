using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Object = UnityEngine.Object;

namespace NerScript
{
    public static class RectLib
    {
        #region Add
        public static Rect AddPos(ref this Rect rect, Vector2 pos) { rect.x += pos.x; rect.y += pos.y; return rect; }
        public static Rect AddPos(ref this Rect rect, float x, float y) { rect.x += x; rect.y += y; return rect; }
        public static Rect AddPosX(ref this Rect rect, float x) { rect.x += x; return rect; }
        public static Rect AddPosY(ref this Rect rect, float y) { rect.y += y; return rect; }
        public static Rect AddSize(ref this Rect rect, Vector2 size) { rect.width += size.x; rect.height += size.y; return rect; }
        public static Rect AddSize(ref this Rect rect, float width, float height) { rect.width += width; rect.height += height; return rect; }
        public static Rect AddWidth(ref this Rect rect, float width) { rect.width += width; return rect; }
        public static Rect AddHeight(ref this Rect rect, float height) { rect.height += height; return rect; }
        public static Rect Add(ref this Rect rect, Rect other) { rect.AddPos(other.position); rect.AddSize(other.size); return rect; }
        #endregion

        #region Set
        public static Rect SetPos(ref this Rect rect, Vector2 pos) { rect.x = pos.x; rect.y = pos.y; return rect; }
        public static Rect SetPos(ref this Rect rect, float x, float y) { rect.x = x; rect.y = y; return rect; }
        public static Rect SetPosX(ref this Rect rect, float x) { rect.x = x; return rect; }
        public static Rect SetPosY(ref this Rect rect, float y) { rect.y = y; return rect; }
        public static Rect SetSize(ref this Rect rect, Vector2 size) { rect.width = size.x; rect.height = size.y; return rect; }
        public static Rect SetSize(ref this Rect rect, float width, float height) { rect.width = width; rect.height = height; return rect; }
        public static Rect SetWidth(ref this Rect rect, float width) { rect.width = width; return rect; }
        public static Rect SetHeight(ref this Rect rect, float height) { rect.height = height; return rect; }
        public static Rect Set(ref this Rect rect, Rect other) { rect.SetPos(other.position); rect.SetSize(other.size); return rect; }
        #endregion

        #region Added
        public static Rect AddedPos(this Rect rect, Vector2 pos) => rect.AddPos(pos);
        public static Rect AddedPos(this Rect rect, float x, float y) => rect.AddPos(x, y);
        public static Rect AddedPosX(this Rect rect, float x) => rect.AddPosX(x);
        public static Rect AddedPosY(this Rect rect, float y) => rect.AddPosY(y);
        public static Rect AddedSize(this Rect rect, Vector2 size) => rect.AddSize(size);
        public static Rect AddedSize(this Rect rect, float width, float height) => rect.AddSize(width, height);
        public static Rect AddedWidth(this Rect rect, float width) => rect.AddWidth(width);
        public static Rect AddedHeight(this Rect rect, float height) => rect.AddHeight(height);
        public static Rect Added(ref this Rect rect, Rect other) => rect.Add(other);
        #endregion

        #region Seted     
        public static Rect SetedPos(this Rect rect, Vector2 pos) => rect.SetPos(pos);
        public static Rect SetedPos(this Rect rect, float x, float y) => rect.SetPos(x, y);
        public static Rect SetedPosX(this Rect rect, float x) => rect.SetPosX(x);
        public static Rect SetedPosY(this Rect rect, float y) => rect.SetPosY(y);
        public static Rect SetedSize(this Rect rect, Vector2 size) => rect.SetSize(size);
        public static Rect SetedSize(this Rect rect, float width, float height) => rect.SetSize(width, height);
        public static Rect SetedWidth(this Rect rect, float width) => rect.SetWidth(width);
        public static Rect SetedHeight(this Rect rect, float height) => rect.SetHeight(height);
        public static Rect Seted(ref this Rect rect, Rect other) => rect.Set(other);
        #endregion

        #region Inversion
        public static Rect Inversion(ref this Rect rect)
        {
            rect.position = -rect.position;
            rect.size = -rect.size;
            return rect;
        }
        public static Rect Inverted(this Rect rect) => rect.Inversion();
        #endregion

        #region

        public static Vector2 GetCenterPos(this Rect rect) => rect.position + rect.size / 2;

        public static Rect GetAllInBox(List<Rect> rects)
        {
            Rect rect = new Rect();
            rect.min = new Vector2(rects.Min(r => r.min.x), rects.Min(r => r.min.y));
            rect.max = new Vector2(rects.Max(r => r.max.x), rects.Max(r => r.max.y));
            return rect;
        }

        #endregion

        public static Rect Scale(ref this Rect rect, float scale)
        {
            rect.x *= scale;
            rect.y *= scale;
            rect.width *= scale;
            rect.height *= scale;
            return rect;
        }
        public static Rect Scaled(this Rect rect, float scale) => rect.Scale(scale);
    }
}