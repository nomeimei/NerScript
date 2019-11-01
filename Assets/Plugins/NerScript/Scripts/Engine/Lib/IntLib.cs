using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NerScript
{
    public static class IntLib
    {
        public static string InsertComma(this int self, string comma = ",", int degit = 3)
        {
            string str = self.ToString();
            StringBuilder result = new StringBuilder();
            str = str.Reverse();
            for (int i = 0; i < str.Length; i++)
            {
                if (i != 0 && i % 3 == 0) result.Append(comma);
                result.Append(str[i]);
            }
            return result.ToString().Reverse();
        }

    }
}
