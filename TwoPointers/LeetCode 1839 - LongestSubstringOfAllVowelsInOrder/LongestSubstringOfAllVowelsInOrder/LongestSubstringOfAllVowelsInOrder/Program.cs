﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubstringOfAllVowelsInOrder
{
	class Program
	{
		static void Main(string[] args)
		{
			var word = "aeiouoaieuuoaeiiaoueueoiaiaeuoueaioeuaioiueoaaiueo";
			Console.WriteLine(LongestBeautifulSubstring(word));
		}
		public static int LongestBeautifulSubstring(string word)
		{
			var dict = new Dictionary<char, int>();
			int li = 0, hi = 0, res = 0;
			while (hi < word.Length)
			{
				if (dict.Count == 0 || word[hi - 1] >= dict.Where(x => x.Value != 0).Max(x => x.Key))
				{
					if (dict.Count == 5)
						res = Math.Max(res, hi - li);
					if (!dict.ContainsKey(word[hi]))
						dict[word[hi]] = 0;
					dict[word[hi++]]++;
				}
				else
				{
					dict[word[li]]--;
					if (dict[word[li]] == 0)
						dict.Remove(word[li]);
					li++;
				}
			}
			if (dict.Count == 5)
				res = Math.Max(res, hi - li);
			return res;
		}
	}
}
