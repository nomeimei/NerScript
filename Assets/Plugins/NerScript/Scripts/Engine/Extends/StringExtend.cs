using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;


namespace NerScript
{
    public static class StringExtend
    {
        #region Path
        /// <summary>
        /// 文字列を/で区切る
        /// </summary>
        /// <param name="str">区切る文字列</param>
        /// <param name="deleteSlash">スラッシュを消すかどうか</param>
        /// <returns></returns>
        public static List<string> Delimit(this string str, string s1 = "/", bool deleteSlash = true)
        {
            List<string> list = str.Split(new string[] { s1 }, StringSplitOptions.None).ToList(); //区切った文字を入れる
            if (!deleteSlash)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i != list.Count - 1)
                        list[i] += s1;
                }
            }
            return list;
        }

        /// <summary>
        /// 区切った番号の文字列を取得
        /// 負の数値で最後から数える
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetDelimitDepth(this string str, int num)
        {
            List<string> list = str.Delimit();
            try
            {
                if (0 <= num)
                {
                    return list[num];
                }
                else
                {
                    return list[list.Count + num];
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return "this is error message.(" + str + ")";
            }
        }

        /// <summary>
        /// 区切った番号より後ろの文字列を返す。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetDelimitDepths(this string str, int num)
        {
            string ret = "";

            string dep = str.GetDelimitDepth(num);

            int index = str.IndexOf(dep);

            string del = str.Remove(index);

            ret = str.Replace(del, "");

            return ret;
        }

        /// <summary>
        /// 受け取った深さにあるファイル名を取得
        /// </summary>
        /// asset/prefabs/s
        /// asset/MyFolder/asset/scripts/a
        /// asset/scripts/b
        /// asset/scripts/player/c
        /// scripts/e
        /// GetFileNameThisDepth(asset/scripts)
        /// return ↓
        /// asset/scripts/b
        /// asset/scripts/player/c
        /// <param name="paths"></param>
        /// <param name="depth"></param>
        public static List<string> GetFileNameThisDepth(this string[] paths, string depth)
        {
            List<string> files = new List<string>();
            foreach (var p in paths)
            {
                if (p.StartsWith(depth) && !files.Contains(p))
                {
                    files.Add(p);
                }
            }
            return files;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        // 修正中
        public static string GetNextFolder(string path, string depth)
        {
            return path.Remove(0, depth.Length + 1).Delimit().First();
        }

        /// <summary>
        /// 拡張子を外した文字列を返す
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string DeleteExtension(this string name)
        {

            if (name.Contains('.'))
            {
                int num = name.IndexOf(".");
                return name.Remove(num);
            }
            else
            {
                return name;
            }
        }
        /// <summary>
        /// ディレクトリのパスを返す
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetDirectoryPath(this string filePath)
        {
            if (filePath.Contains('/'))
            {
                int num = filePath.LastIndexOf("/");
                string fileName = filePath.Substring(num);
                if (fileName.Contains('.')) return filePath.Remove(num);
            }
            return filePath;
        }
        #endregion

        /// <summary>
        /// intに変換
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int Int(this string str)
        {
            int ret = -1;
            try
            {
                ret = int.Parse(str);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            return ret;
        }

        /// <summary>
        /// 指定箇所の置き換え
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        /// <param name="newChar"></param>
        /// <returns></returns>
        public static string ChangeCharAt(this string str, int index, char newChar)
        {
            return str.Remove(index, 1).Insert(index, newChar.ToString());
        }

        /// <summary>
        /// ,で連結
        /// </summary>
        /// <returns></returns>
        public static string ConnectCom(params string[] strs)
        {
            string str = "";
            for (int i = 0; i < str.Length; i++)
            {
                str += str[i] + ",";
            }
            return str;
        }
        /// <summary>
        /// ,で連結
        /// </summary>
        /// <returns></returns>
        public static string ConnectCom(this object s, params object[] strs)
        {
            string str = s + ",";
            for (int i = 0; i < strs.Length; i++)
            {
                str += strs[i].ToString();
                if (i != strs.Length - 1)
                    str += ",";
            }
            return str;
        }

        public static string Joined(this List<string> strs) { return string.Join("", strs); }
        public static string Reverse(this string str)
        {
            StringBuilder newStr = new StringBuilder();
            for (int i = str.Length - 1; 0 <= i; i--)
            {
                newStr.Append(str[i]);
            }
            return newStr.ToString();
        }


        #region Check

        public static bool IsSame(this string r, string l, bool detectSize = true)
        {
            if (detectSize)
            {
                r = r.ToLower();
                l = l.ToLower();
            }
            return r == l;
        }
        public static bool ContainsAlp(this string r, string l)
        {
            r = r.ToLower();
            l = l.ToLower();
            return r.Contains(l);
        }
        public static bool Serch(this string str, string filter)
        {
            str = str.ToLower();
            filter = filter.ToLower();

            foreach (var f in filter)
            {
                int index = str.IndexOf(f);
                if (index == -1) return false;
                str = str.Substring(index + 1);
            }
            return true;
        }

        #endregion
    }
}
