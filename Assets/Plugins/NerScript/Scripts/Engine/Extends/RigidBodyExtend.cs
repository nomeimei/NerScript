using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NerScript
{
    /// <summary>
    /// 拡張メソッド
    /// </summary>
    public static class RigidBodyExtend
    {

        #region Freeze
        public static Rigidbody Freeze(this Rigidbody rb, RigidbodyConstraints rbc)
        {
            rb.constraints = rb.constraints | rbc;
            return rb;
        }
        public static Rigidbody FreezeAll(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezeAll);
            return rb;
        }
        public static Rigidbody FreezePosAll(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezePosition);
            return rb;
        }
        public static Rigidbody FreezeRotAll(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezeRotation);
            return rb;
        }
        public static Rigidbody FreezePosX(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezePositionX);
            return rb;
        }
        public static Rigidbody FreezePosY(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezePositionY);
            return rb;
        }
        public static Rigidbody FreezePosZ(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezePositionZ);
            return rb;
        }
        public static Rigidbody FreezeRotX(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezeRotationX);
            return rb;
        }
        public static Rigidbody FreezeRotY(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezeRotationY);
            return rb;
        }
        public static Rigidbody FreezeRotZ(this Rigidbody rb)
        {
            rb.Freeze(RigidbodyConstraints.FreezeRotationZ);
            return rb;
        }
        public static Rigidbody FreezeNone(this Rigidbody rb)
        {
            rb.constraints = RigidbodyConstraints.None;
            return rb;
        }
        #endregion
        #region UnFreeze
        public static Rigidbody UnFreeze(this Rigidbody rb, RigidbodyConstraints rbc)
        {
            string nowConstraints = freezeData[(int)rb.constraints / 2];
            string unFrzConstraints = freezeData[(int)rbc / 2];

            for (int i = 0; i < nowConstraints.Length; i++)
            {
                if (nowConstraints[i] == '1' && unFrzConstraints[i] == '1')
                {
                    nowConstraints = nowConstraints.ChangeCharAt(i, '0');
                }
            }

            rb.constraints = StrToConstraints(nowConstraints);
            return rb;
        }

        /// <summary>
        /// 文字列を制限に変更
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static RigidbodyConstraints StrToConstraints(string str)
        {
            int ret = 0;

            if (str[0] == '1') ret += 2;
            if (str[1] == '1') ret += 4;
            if (str[2] == '1') ret += 8;
            if (str[3] == '1') ret += 16;
            if (str[4] == '1') ret += 32;
            if (str[5] == '1') ret += 64;

            return (RigidbodyConstraints)ret;
        }


        public static Rigidbody UnFreezeAll(this Rigidbody rb)
        {
            rb.FreezeNone();
            return rb;
        }
        public static Rigidbody UnFreezePosition(this Rigidbody rb)
        {
            rb.UnFreeze(RigidbodyConstraints.FreezePosition);
            return rb;
        }
        public static Rigidbody UnFreezePosX(this Rigidbody rb)
        {
            rb.UnFreeze(RigidbodyConstraints.FreezePositionX);
            return rb;
        }
        public static Rigidbody UnFreezePosY(this Rigidbody rb)
        {
            rb.UnFreeze(RigidbodyConstraints.FreezePositionY);
            return rb;
        }
        public static Rigidbody UnFreezePosZ(this Rigidbody rb)
        {
            rb.UnFreeze(RigidbodyConstraints.FreezePositionZ);
            return rb;
        }
        public static Rigidbody UnFreezeRotation(this Rigidbody rb)
        {
            rb.UnFreeze(RigidbodyConstraints.FreezeRotation);
            return rb;
        }
        public static Rigidbody UnFreezeRotX(this Rigidbody rb)
        {
            rb.UnFreeze(RigidbodyConstraints.FreezeRotationX);
            return rb;
        }
        public static Rigidbody UnFreezeRotY(this Rigidbody rb)
        {
            rb.UnFreeze(RigidbodyConstraints.FreezeRotationY);
            return rb;
        }
        public static Rigidbody UnFreezeRotZ(this Rigidbody rb)
        {
            rb.UnFreeze(RigidbodyConstraints.FreezeRotationZ);
            return rb;
        }
        #endregion
        #region CheckFreeze

        /// <summary>
        /// フリーズの確認用
        /// </summary>
        private static List<string> freezeData = new List<string>()
        {
            "000000","100000", "010000", "110000", "001000", "101000", //0-10
            "011000", "111000", "000100", "100100", "010100", //12-20
            "110100", "001100", "101100", "011100", "111100", //22-30
            "000010", "100010", "010010", "110010", "001010", //32-40
            "101010", "011010", "111010", "000110", "100110", //42-50
            "010110", "110110", "001110", "101110", "011110", //52-60
            "111110", "000001", "100001", "010001", "110001", //62-70
            "001001", "101001", "011001", "111001", "000101", //72-80
            "100101", "010101", "110101", "001101", "101101", //82-90
            "011101", "111101", "000011", "100011", "010011", //92-100
            "110011", "001011", "101011", "011011", "111011", //102-110
            "000111", "100111", "010111", "110111", "001111", //112-120
            "101111", "011111", "111111",//122-126
        };

        public static bool CheckFreezeAll(this Rigidbody rb)
        {
            if ((int)rb.constraints == 126)
                return true;
            return false;
        }
        public static bool CheckFreezeNone(this Rigidbody rb)
        {
            if (rb.constraints == 0)
                return true;
            return false;
        }
        public static bool CheckFreezePosition(this Rigidbody rb)
        {
            if (freezeData[(int)rb.constraints / 2][0] == '1' &&
                freezeData[(int)rb.constraints / 2][1] == '1' &&
                freezeData[(int)rb.constraints / 2][2] == '1')
                return true;
            return false;
        }
        public static bool CheckFreezeRotation(this Rigidbody rb)
        {
            if (freezeData[(int)rb.constraints / 2][3] == '1' &&
                freezeData[(int)rb.constraints / 2][4] == '1' &&
                freezeData[(int)rb.constraints / 2][5] == '1')
                return true;
            return false;
        }
        public static bool CheckFreezePosX(this Rigidbody rb)
        {
            if (freezeData[(int)rb.constraints / 2][0] == '1')
                return true;
            return false;
        }
        public static bool CheckFreezePosY(this Rigidbody rb)
        {
            if (freezeData[(int)rb.constraints / 2][1] == '1')
                return true;
            return false;
        }
        public static bool CheckFreezePosZ(this Rigidbody rb)
        {
            if (freezeData[(int)rb.constraints / 2][2] == '1')
                return true;
            return false;
        }
        public static bool CheckFreezeRotX(this Rigidbody rb)
        {
            if (freezeData[(int)rb.constraints / 2][3] == '1')
                return true;
            return false;
        }
        public static bool CheckFreezeRotY(this Rigidbody rb)
        {
            if (freezeData[(int)rb.constraints / 2][4] == '1')
                return true;
            return false;
        }
        public static bool CheckFreezeRotZ(this Rigidbody rb)
        {
            if (freezeData[(int)rb.constraints / 2][5] == '1')
                return true;
            return false;
        }

        #endregion

        #region Velocity
        public static Rigidbody SetVelX(this Rigidbody rb, float x)
        {
            Vector3 velo = rb.velocity;
            rb.velocity = new Vector3(x, velo.y, velo.z);
            return rb;
        }
        public static Rigidbody SetVelY(this Rigidbody rb, float y)
        {
            Vector3 velo = rb.velocity;
            rb.velocity = new Vector3(velo.x, y, velo.z);
            return rb;
        }
        public static Rigidbody SetVelZ(this Rigidbody rb, float z)
        {
            Vector3 velo = rb.velocity;
            rb.velocity = new Vector3(velo.x, velo.y, z);
            return rb;
        }
        public static Rigidbody VelocityToZero(this Rigidbody rb)
        {
            rb.velocity = Vector3.zero;
            return rb;
        }
        #endregion




    }
}
