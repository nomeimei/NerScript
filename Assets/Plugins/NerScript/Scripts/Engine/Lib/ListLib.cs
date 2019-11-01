using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NerScript
{
    /// <summary>
    /// 拡張メソッド
    /// </summary>
    public static class ListLib
    {
        #region Count
        /// <summary>
        /// 指定の長さまでカット
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// 5の場合、01234になる
        /// <returns></returns>
        public static List<T> Cut<T>(this List<T> list, int count)
        {
            while (count < list.Count)
            {
                list.RemoveLast();
            }
            return list;
        }
        public static List<T> Cuted<T>(this List<T> list, int count)
        {
            List<T> newList = new List<T>(list);
            return newList.Cut(count);
        }
        /// <summary>
        /// 指定の長さまで埋める
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// 5の場合、01234になる
        /// <returns></returns>
        public static List<T> Fill<T>(this List<T> list, int count)
        {
            while (list.Count < count)
            {
                list.Add(default(T));
            }
            return list;
        }
        public static List<T> Filled<T>(this List<T> list, int count)
        {
            List<T> newList = new List<T>(list);
            return newList.Fill(count);
        }
        /// <summary>
        /// 指定の長さにする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// 5の場合、01234になる
        /// <returns></returns>
        public static List<T> SetCount<T>(this List<T> list, int count)
        {
            return list.Cut(count).Fill(count);
        }
        public static List<T> SetedCount<T>(this List<T> list, int count)
        {
            List<T> newList = new List<T>();
            return newList.Cut(count).Fill(count);
        }
        /// <summary>
        /// Index位置の要素を削除
        /// 負の値の場合後ろからの位置になる
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static List<T> RemoveAtI<T>(this List<T> list, int index)
        {
            if (index < 0) list.RemoveAt(list.Count + index);
            else list.RemoveAt(index);
            return list;
        }
        /// <summary>
        /// 要素の最後を削除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> RemoveLast<T>(this List<T> list)
        {
            list.RemoveAt(list.Count - 1);
            return list;
        }
        /// <summary>
        /// 最初の要素を削除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> RemoveFirst<T>(this List<T> list)
        {
            list.RemoveAt(0);
            return list;
        }
        /// <summary>
        /// nullの削除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> RemoveNull<T>(this List<T> list) where T : class
        {
            list.RemoveAll(i => i == null);
            return list;
        }
        /// <summary>
        /// nullの削除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> RemoveNullObject<T>(this List<T> list) where T : UnityEngine.Object
        {
            list.RemoveAll(i => i == null);
            return list;
        }
        /// <summary>
        /// 要素の追加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<T> AddItem<T>(this List<T> list, T item)
        {
            list.Add(item);
            return list;
        }
        /// <summary>
        /// 先頭に要素を追加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<T> AddFront<T>(this List<T> list, T item)
        {
            list.Insert(0, item);
            return list;
        }
        /// <summary>
        /// 重複しないように要素の追加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<T> AddNonOverlap<T>(this List<T> list, T item)
        {
            if (!list.Contains(item))
                list.Add(item);
            return list;
        }
        /// <summary>
        /// 追加されたリストを返す
        /// （実際には追加しない）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<T> Added<T>(this List<T> list, T item)
        {
            List<T> added = new List<T>(list);
            if (!added.Contains(item))
                added.Add(item);
            return added;
        }
        /// <summary>
        /// 追加されたリストを返す
        /// （実際には追加しない）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<T> Added<T>(this List<T> list, List<T> addList)
        {
            List<T> added = new List<T>(list);
            added.AddRange(addList);

            return added;
        }
        #endregion

        #region Get


        #endregion

        #region Check
        /// <summary>
        /// 中に一つでも要素が入っているか
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool HasItem<T>(this List<T> list)
        {
            return 0 < list.Count;
        }
        /// <summary>
        /// 例外的リストかどうか
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool CheckException<T>(this List<T> list)
        {
            if (list == null) return true;
            if (list.Count == 0) return true;
            return false;
        }
        /// <summary>
        /// nullだったらnewして返す
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> InstanceOrNew<T>(this List<T> list)
        {
            if (list == null) list = new List<T>();
            return list;
        }
        #endregion

        #region Shift

        public static T[] ShiftArray<T>(this T obj) => new T[] { obj };
        public static T[] ShiftArray<T>(this T obj, params T[] objs) => (new List<T> { obj }).Added(objs.ToList()).ToArray();
        public static List<T> ShiftList<T>(this T obj) => new List<T> { obj };
        public static List<T> ShiftList<T>(this T obj, params T[] objs) => (new List<T> { obj }).Added(objs.ToList());

        #endregion

        /// <summary>
        /// 真ん中の添字番号
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int GetMiddle<T>(this List<T> list)
        {
            return list.Count / 2;
        }

        /// <summary>
        /// 各要素がconditionsを満たす場合、actを実行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="conditions"></param>
        /// <param name="act"></param>
        /// <returns></returns>
        public static void ForEachIF<T>(this List<T> list, Predicate<T> conditions, Action<T> act)
        {
            foreach (var t in list)
            {
                if (conditions(t)) act(t);
            }
        }


    }
}