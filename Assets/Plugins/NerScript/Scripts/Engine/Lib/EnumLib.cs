using System;
using System.Collections.Generic;
using System.Linq;

namespace NerScript
{
    public static class EnumLib
    {
        public static int Int(this Enum e) => Convert.ToInt32(e);

        public static string ToEnumName<T>(this int i) where T : Enum => ((T)((object)i)).ToString();

        public static T[] GetAllEnum<T>() where T : Enum => (T[])Enum.GetValues(typeof(T));
        public static T[] GetAllEnum<T>(this T e) where T : Enum => (T[])Enum.GetValues(typeof(T));
        public static string[] GetAllNames<T>() where T : Enum => GetAllEnum<T>().Select(e => e.ToString()).ToArray();
        public static string[] GetAllNames<T>(this T e) where T : Enum => GetAllEnum<T>().Select(en => en.ToString()).ToArray();
        public static T[] Positives<T>(this T[] enums) where T : Enum => enums.Where(e => 0 < e.Int()).ToArray();
        public static T[] Negatives<T>(this T[] enums) where T : Enum => enums.Where(e => e.Int() < 0).ToArray();


    }
}
