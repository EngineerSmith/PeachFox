using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PeachFox
{
    static class Template
    {
        public static string FillTemplate(string template, Dictionary<string, string> dictionary)
        {
            var words = Regex.Split(template, @"(?=[ \r\n])");
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Trim();
                switch (word)
                {
                    case "TABLE":
                        InsertTable(ref words, ref i, dictionary); break;
                    default:
                        continue;
                }
            }
            return string.Join("", words);
        }

        private static void InsertTable(ref string[] arr, ref int index, Dictionary<string, string> dictionary)
        {
            if (IsValidate(arr, index + 1) == false)
            {
                arr[index] = "";
                return;
            }
            string key = arr[index + 1].Trim();
            arr[index + 1] = "";
            string value = dictionary[key];
            if (value == null)
            {
                arr[index] = "";
                return;
            }
            arr[index] = " " + value;
            index++;
        }

        private static bool IsValidate(string[] arr, int index)
        {
            return arr.ElementAtOrDefault(index) != null;
        }
    }
}
