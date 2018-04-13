using System;
using System.Collections.Generic;

namespace AnagramDetection
{
    public class Kata
    {
        public class CharacterDic
        {
            private Dictionary<char, int> _dic = new Dictionary<char, int>();

            public int this[char key]
            {
                get
                {
                    key = char.ToLower(key);
                    if (!_dic.ContainsKey(key))
                    {
                        _dic[key] = 0;
                    }
                    return _dic[key];
                }
                set
                {
                    key = char.ToLower(key);
                    _dic[key] = value;
                }
            }
        }

        public static bool IsAnagram(string test, string original)
        {
            if (test.Length != original.Length)
            {
                return false;
            }
            var dic = new CharacterDic();
            foreach (var character in original)
            {
                dic[character]++;
            }

            foreach (var character in test)
            {
                if (dic[character] == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
