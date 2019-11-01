using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NerScript
{
    /// <summary>
    /// 拡張メソッド
    /// </summary>
    public static class UnityExtend
    {

        /// <summary>
        /// もしnullだったらobjからコンポーネントを取得して返す、
        /// nullでないならそのまま
        /// </summary>
        public static T IfNullGet<T>(this T comp, GameObject obj) where T : Component
        {
            if (comp == null)
            {
                comp = obj.GetComponent<T>();
            }
            return comp;
        }
        /// <summary>
        /// もしnullだったらtrからコンポーネントを取得して返す、
        /// nullでないならそのまま
        /// </summary>
        public static T IfNullGet<T>(this T comp, Transform tr) where T : Component
        {
            return comp.IfNullGet(tr.gameObject);
        }
    }
}

public static class UnityExtension
{
    public enum LogID
    {
        Hide = -1,
        Normal = 0,
        DestroyMsg = 1,
        Init = 2,
    }


    public static void LogShow(this object obj, int id = 0, string addStr = "")
    {
        if (id == -1) return;

        if (addStr == "")
        {
            Debug.Log(obj);
        }
        else
        {
            //Debug.Log("<color=#000000>" + obj + "</color>" + addStr);
            Debug.Log(obj + addStr);
        }
    }
    public static void LogShow(this object obj, LogID id, string addStr = "")
    {
        obj.LogShow((int)id, addStr);
    }

    public static T DebugLog<T>(this T obj)
    {
        obj.LogShow();
        return obj;
    }
}