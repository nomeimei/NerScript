using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;
using static UnityEngine.Mathf;

namespace NerScript
{
    /// <summary>
    /// コンポーネントの拡張
    /// </summary>
    public static class ComponentExtend
    {


        #region Get
        public static Rigidbody GetRigidBody(this Component self) { return self.GetComponent<Rigidbody>(); }
        public static Rigidbody2D GetRigidBody2D(this Component self) { return self.GetComponent<Rigidbody2D>(); }
        public static Collider GetCollider(this Component self) { return self.GetComponent<Collider>(); }
        public static Collider2D GetCollider2D(this Component self) { return self.GetComponent<Collider2D>(); }

        #endregion


        #region 親子関係
        /// <summary>
        /// 親の取得
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Transform GetParent(this Component self) { return self.gameObject.GetParent(); }
        public static GameObject GetParentG(this Component self) { return self.gameObject.GetParentG(); }

        #endregion


    }
}
