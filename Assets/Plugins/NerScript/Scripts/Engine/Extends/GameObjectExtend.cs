using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Object = UnityEngine.Object;

namespace NerScript
{
    /// <summary>
    /// 拡張メソッド
    /// </summary>
    public static class GameObjectExtend
    {

        #region コンポーネント

        #region Has
        /// <summary>
        /// 指定されたコンポーネントがアタッチされているかどうか
        /// </summary>
        public static bool HasComponent<T>(this GameObject self) where T : Component
        {
            return self.GetComponent<T>();
        }
        public static bool HasComponent(this GameObject self, Type type)
        {
            return self.GetComponent(type);
        }
        #endregion

        #region Remove
        /// <summary>
        /// コンポーネントを削除
        /// </summary>
        public static GameObject RemoveComponent<T>(this GameObject self)
            where T : Component
        {
            T component = self.GetComponent<T>();
            if (component) Object.Destroy(component);
            return self;
        }
        public static GameObject RemoveComponent<T1, T2>(this GameObject self)
            where T1 : Component where T2 : Component
        {
            self.RemoveComponent<T1>();
            self.RemoveComponent<T2>();
            return self;
        }
        public static GameObject RemoveComponent<T1, T2, T3>(this GameObject self)
            where T1 : Component where T2 : Component where T3 : Component
        {
            self.RemoveComponent<T1, T2>();
            self.RemoveComponent<T3>();
            return self;
        }
        public static GameObject RemoveComponent<T1, T2, T3, T4>(this GameObject self)
            where T1 : Component where T2 : Component where T3 : Component where T4 : Component
        {
            self.RemoveComponent<T1, T2, T3>();
            self.RemoveComponent<T4>();
            return self;
        }
        #endregion

        #region Add
        /// <summary>
        /// コンポーネントの追加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GameObject AddComponentG<T>(this GameObject self) where T : Component
        {
            self.AddComponent<T>();
            return self;
        }
        public static GameObject AddComponentG<T1, T2>(this GameObject self) where T1 : Component where T2 : Component
        {
            self.AddComponent<T1>();
            self.AddComponent<T2>();
            return self;
        }
        /// <summary>
        /// コンポーネントが入ってなかったら入れる。
        /// 入っていたら何もしない
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GameObject AddComponentGIfNotHave<T>(this GameObject self) where T : Component
        {
            if (!self.HasComponent<T>()) self.AddComponent<T>();
            return self;
        }
        /// <summary>
        /// 指定したコンポーネントが入ってなかったら追加して返す
        /// 既に入っていたら入っている物を取得して返す
        /// </summary>
        /// <returns></returns>
        public static T GetorAddComponent<T>(this GameObject self) where T : Component
        {
            if (self.HasComponent<T>())
            {
                return self.GetComponent<T>();
            }
            else
            {
                return self.AddComponent<T>();
            }
        }
        #endregion

        #region Enebled
        /// <summary>
        /// コンポーネントの非有効化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GameObject DisableComponent<T>(this GameObject self) where T : Behaviour
        {
            if (self.HasComponent<T>())
                self.GetComponent<T>().enabled = false;
            return self;
        }
        /// <summary>
        /// コンポーネントの有効化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GameObject EnableComponent<T>(this GameObject self) where T : Behaviour
        {
            if (self.HasComponent<T>())
                self.GetComponent<T>().enabled = true;
            return self;
        }
        #endregion

        #region Get

        public static Rigidbody GetRigidBody(this GameObject self) { return self.GetComponent<Rigidbody>(); }
        public static Rigidbody2D GetRigidBody2D(this GameObject self) { return self.GetComponent<Rigidbody2D>(); }
        public static Collider GetCollider(this GameObject self) { return self.GetComponent<Collider>(); }
        public static Collider2D GetCollider2D(this GameObject self) { return self.GetComponent<Collider2D>(); }

        #endregion

        #endregion

        /// <summary>
        /// 破棄
        /// </summary>
        public static GameObject Destroy(this GameObject self)
        {
            Object.Destroy(self);
            return self;
        }
        public static GameObject Destroy(this GameObject self, float time)
        {
            Object.Destroy(self, time);
            return self;
        }
        /// <summary>
        /// DontDestroyOnLoadにする
        /// </summary>
        public static GameObject DontDestroyOnLoad(this GameObject self)
        {
            Object.DontDestroyOnLoad(self);
            return self;
        }

        #region Tag
        /// <summary>
        /// タグの設定
        /// </summary>
        /// <param name="self"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static GameObject SetTag(this GameObject self, string tag)
        {
            self.tag = tag;
            return self;
        }
        /// <summary>
        /// タグのチェック
        /// </summary>
        /// <param name="self"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public static bool CheckTag(this GameObject self, params string[] tags)
        {
            foreach (var t in tags)
            {
                if (self.tag == t)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 親子関係
        /// <summary>
        /// 子供を追加
        /// </summary>
        /// <param name="self"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static GameObject AddChild(this GameObject self, GameObject child)
        {
            self.AddChild(child.transform);
            return self;
        }
        public static GameObject AddChild(this GameObject self, Transform child)
        {
            self.transform.AddChild(child);
            return self;
        }
        /// <summary>
        /// 親を設定
        /// </summary>
        /// <param name="self"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static GameObject SetParent(this GameObject self, GameObject parent)
        {
            parent.AddChild(self);
            return self;
        }
        public static GameObject SetParent(this GameObject self, Transform parent)
        {
            parent.AddChild(self);
            return self;
        }
        /// <summary>
        /// 親の設定を無効
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GameObject SetParent(this GameObject self)
        {
            self.transform.SetParent();
            return self;
        }
        /// <summary>
        /// 子供のオブジェクト取得
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GameObject GetChild(this GameObject self, int index = 0)
        {
            return self.transform.GetChild(index).gameObject;
        }
        /// <summary>
        /// 子供のオブジェクトをすべて取得
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<GameObject> GetChildren(this GameObject self)
        {
            return self.transform.GetChildrenG().ToList();
        }
        /// <summary>
        /// 条件に一致した子供だけ取得
        /// </summary>
        /// <param name="self"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static List<GameObject> GetChildren(this GameObject self, Predicate<GameObject> match)
        {
            List<GameObject> objs = self.GetChildren();
            objs.RemoveAll(g => !match.Invoke(g));

            return objs;
        }
        /// <summary>
        /// 親を取得
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Transform GetParent(this GameObject self)
        {
            return self.transform.parent;
        }
        public static GameObject GetParentG(this GameObject self)
        {
            return self.transform.parent.gameObject;
        }
        #endregion

        #region Enebled
        /// <summary>
        /// オブジェクトの非有効化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GameObject UnActivate(this GameObject self)
        {
            self.SetActive(false);
            return self;
        }
        /// <summary>
        /// 全オブジェクトの非有効化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<GameObject> UnActivate(this List<GameObject> objs)
        {
            foreach (var g in objs)
            {
                g.UnActivate();
            }
            return objs;
        }
        /// <summary>
        /// オブジェクトの有効化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static GameObject Activate(this GameObject self)
        {
            self.SetActive(true);
            return self;
        }
        /// <summary>
        /// 全オブジェクトの有効化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<GameObject> Activate(this List<GameObject> objs)
        {
            foreach (var g in objs)
            {
                g.Activate();
            }
            return objs;
        }
        #endregion

        #region GetClosest
        /// <summary>
        /// 一番近いオブジェクトを取得
        /// </summary>
        /// <returns></returns>
        public static GameObject GetClosestObjectInList2D(this GameObject self, List<GameObject> objs)
        {
            Transform close = self.transform.GetClosestObjectInList2D(objs);
            if (close == null) return null;
            return close.gameObject;
        }
        public static GameObject GetClosestObjectInList2D(this GameObject self, List<Transform> objs)
        {
            Transform close = self.transform.GetClosestObjectInList2D(objs);
            if (close == null) return null;
            return close.gameObject;
        }
        public static GameObject GetClosestObjectInList(this GameObject self, List<GameObject> objs)
        {
            Transform close = self.transform.GetClosestObjectInList(objs);
            if (close == null) return null;
            return close.gameObject;
        }
        public static GameObject GetClosestObjectInList(this GameObject self, List<Transform> objs)
        {
            Transform close = self.transform.GetClosestObjectInList(objs);
            if (close == null) return null;
            return close.gameObject;
        }
        #endregion


    }
}