using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachFox
{
    static class Template
    {
        public static string FillTemplate(string template, Dictionary<string, string> dictionary)
        {
            const string whitespace = " ";
            var arr = template.Split(whitespace.ToCharArray());
            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case "TABLE":
                        {
                            InsertTable(ref arr, ref i, dictionary);
                            break;
                        }
                    default:
                        continue;

                }
            }
            return string.Join(whitespace, arr); ;
        }

        private static void InsertTable(ref string[] arr, ref int index, Dictionary<string, string> dictionary)
        {
            if (IsValidate(arr, index + 1) == false)
            {
                arr[index] = "";
                return;
            }
            string key = arr[index + 1];
            arr[index + 1] = "\n";
            string value = dictionary[key];
            if (value == null)
            {
                arr[index] = "";
                return;
            }
            arr[index] = value;
            index++;
        }

        private static bool IsValidate(string[] arr, int index)
        {
            return arr.ElementAtOrDefault(index) != null;
        }
    }
}
