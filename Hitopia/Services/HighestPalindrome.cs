using System;
using System.Collections.Generic;

namespace mdoule.Services
{
    public class HighestPalindromeService
    {
        public string FindHighestPalindrome(string s, int k)
        {
            int n = s.Length;
            char[] chars = s.ToCharArray();
            bool[] modified = new bool[n];

            int changes = MakePalindrome(chars, modified, 0, n - 1);

            if (changes > k)
            {
                return "-1";
            }
            MaximizePalindrome(chars, modified, 0, n - 1, k - changes);

            return new string(chars);
        }

        private int MakePalindrome(char[] chars, bool[] modified, int left, int right)
        {
            if (left >= right) return 0;

            if (chars[left] != chars[right])
            {
                char maxChar = chars[left] > chars[right] ? chars[left] : chars[right];
                chars[left] = chars[right] = maxChar;
                modified[left] = modified[right] = true;
                return 1 + MakePalindrome(chars, modified, left + 1, right - 1);
            }
            return MakePalindrome(chars, modified, left + 1, right - 1);
        }

        private void MaximizePalindrome(char[] chars, bool[] modified, int left, int right, int remainingChanges)
        {
            if (left >= right || remainingChanges <= 0) return;

            if (chars[left] != '9')
            {
                if (modified[left] || modified[right])
                {
                    chars[left] = chars[right] = '9';
                    MaximizePalindrome(chars, modified, left + 1, right - 1, remainingChanges - 1);
                }
                else if (remainingChanges >= 2)
                {
                    chars[left] = chars[right] = '9';
                    MaximizePalindrome(chars, modified, left + 1, right - 1, remainingChanges - 2);
                }
                else
                {
                    MaximizePalindrome(chars, modified, left + 1, right - 1, remainingChanges);
                }
            }
            else
            {
                MaximizePalindrome(chars, modified, left + 1, right - 1, remainingChanges);
            }
        }
    }
}
