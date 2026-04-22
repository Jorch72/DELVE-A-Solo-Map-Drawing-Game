using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods{
    public static class StringExtensionMethods{
        public static string ReplaceFirst(this string text, string search, string replace){
            int pos = text.IndexOf(search);
            if(pos < 0) return text;
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        public static string ReplaceFirstAt(this string text, string search, string replace, int start){
            int pos = text.IndexOf(search, start);
            if(pos < 0) return text;
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
