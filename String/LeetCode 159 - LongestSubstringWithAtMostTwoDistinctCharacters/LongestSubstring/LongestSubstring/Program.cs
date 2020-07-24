﻿//维护一个滑窗，用一个字典记录字母及其个数。使滑窗内最多只有两个不同的字母。
using System;
using System.Collections.Generic;

namespace LongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            //          012345678
            string s = "abcabcabc";
            Console.WriteLine(LengthOfLongestSubstringTwoDistinct(s));
        }
        static int LengthOfLongestSubstringTwoDistinct(string s)
        {
            int left = 0, right = 0, res = 0;
            if (s.Length == 0)
                return res;
            var dict = new Dictionary<char, int>();
            dict[s[left]] = 1;
            while (right < s.Length)
            {
                if (dict.Count <= 2)
                {
                    res = Math.Max(res, right - left + 1);
                    right++;
                    if(right >= s.Length) break;
                    if (!dict.ContainsKey(s[right]))
                        dict[s[right]] = 1;
                    else
                        dict[s[right]]++;
                }
                else
                {
                    dict[s[left]]--;
                    if (dict[s[left]] == 0)
                        dict.Remove(s[left]);
                    left++;
                }
            }
            return res;
        }
    }
}
