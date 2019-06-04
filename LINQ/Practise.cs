using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ
{
    public static class Practice
    {

        public static string Disemvowel(string input)
        {
            return new string(input.Where(c => !"AEIOUY".Contains(char.ToUpper(c)))
                                   .ToArray());
        }

        public static string TwoToOne(string s1, string s2)
        {
            return new string(string.Concat(s1, s2)
                                    .Distinct()
                                    .OrderBy(c => c)
                                    .ToArray());
        }

        public static List<int> RemoveMinimum(List<int> numbers)
        {
            return numbers.Where((n, i) => i != numbers.IndexOf(numbers.Min()))
                          .ToList();
        }

        public static string CharacterError(string s)
        {
            return $"{s.Count(c => char.ToLower(c) > 'm')}/{s.Length}";
        }

        public static int[] ArrayDiff(int[] a, int[] b)
        {
            return a.Where(n => !b.Contains(n))
                    .ToArray();
        }

        public static bool IsIsogram(string str)
        {
            return (str.ToUpper().Distinct().Count() == str.Length);
        }

        public static string CreatePhoneNumber(int[] numbers)
        {
            return Regex.Replace(new string(numbers.Select(n => (char)(n + '0'))
                                                   .ToArray()),
                                @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
        }

        public static int FindParityOutlier(int[] integers)
        {
            return integers.GroupBy(n => n % 2)
                           .First(g => g.Count() == 1)
                           .Last();
        }

        public static string PigLatin(string str)
        {
            return string.Join(" ", str.Split(' ')
                                       .Where(word => word.All(c => char.ToLower(c) >= 'a' &&
                                                                    char.ToLower(c) <= 'z'))
                                       .Select(word => word.Substring(1) + word[0] + "ay"));
        }

        public static string ChangeWeight(string strng)
        {
            return string.Join(" ", strng.Split(' ')
                                         .OrderBy(word => word.Sum(chr => chr - '0'))
                                         .ThenBy(word => word));
        }

        public static int DontGiveMeFive(int start, int end)
        {
            return Enumerable.Range(start, end - start + 1)
                             .Count(n => !n.ToString().Contains("5"));
        }

        public static string DuplicateEncode(string word)
        {
            return new string(word.Select(chr =>
                                word.Count(chr2 => char.ToLower(chr) == char.ToLower(chr2)) == 1
                                ? '('
                                : ')').ToArray());
        }

        public static int OnesAndZeros(int[] binaryArray)
        {
            return Convert.ToInt32(new string(binaryArray.Select(b => b == 0 ? '0' : '1')
                                                         .ToArray()), 2);
        }

        public static int[] CountPositivesSumNegatives(int[] input)
        {
            return (input == null || input.Length == 0)
                    ? new int[] { }
                    : new int[] { input.Count(n => n > 0),
                                  input.Where(n => n < 0).Sum() };
        }
    }
}
