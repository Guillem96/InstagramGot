using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot
{
    /// <summary>
    /// String class extension
    /// </summary>
    static class MyString
    {
        public static bool IsAllUpper(this string s)
        {
            foreach(var c in s)
            {
                if (Char.IsLetter(c) && !Char.IsUpper(c))
                    return false;
            }
            return true;
        }
    }
}
