using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Palindrome
    {
        public static string OriginalDigits(string s)
        {
            string[][] numbers = new string[][]{
                new string[] {"zero", "0"},
                new string[] {"two", "2"},
                new string[] {"four", "4"},
                new string[] {"six", "6"},
                new string[] {"eight", "8"},
                new string[] {"three", "3"},
                new string[] {"five", "5"},
                new string[] {"seven", "7"},
                new string[] {"nine", "9"},
                new string[] {"one", "1"}
                //in order based on letter frequency
            };
            string working = s;
            string output = "";

            for (int i = 0; i < numbers.Length; i++)
            {
                char[] letters = numbers[i][0].ToCharArray();
                bool numberFound = true;
                while (numberFound) {
                    StringBuilder temp = new StringBuilder(working);
                    foreach (char c in letters)
                    {
                        int charAt = temp.ToString().IndexOf(c);
                        if (charAt > -1)
                        {
                            temp.Remove(charAt, 1);
                        } else
                        {
                            numberFound = false;
                            break;
                        }
                    }
                    if (numberFound)
                    {
                        working = temp.ToString();
                        output += numbers[i][1];
                    }
                }
            }

            char[] outChars = output.ToCharArray();
            Array.Sort(outChars);
            return new String(outChars);
        }
    

        public static string BreakPalindrome(string palindrome)
        {
            // gzbazbg ==> azbazbg 
            // asdfdsa ==> aadfdsa
            // a ==> ""
            //aa ==> "ab"
            //bb ==> "ab"
            //aba ==> "abb"
            string output = palindrome;
            char[] arr = palindrome.ToCharArray();
            bool noneFound = true;
            if (palindrome.Length > 1)
            {
                int halfwayIdx = (int)Math.Ceiling(palindrome.Length / 2.0) - 1;
                int idx = 0;
                if (palindrome.Length % 2 > 0)
                {
                    //remove 1 from the halfway point so we ignore the center value of odd-length palindromes  
                    halfwayIdx--;
                }
                while (idx <= halfwayIdx)
                {
                    if (palindrome[idx] != 'a')
                    {
                        StringBuilder sb = new StringBuilder(output);
                        sb[idx] = 'a';
                        output = sb.ToString();
                        noneFound = false;
                        break;
                    }
                    idx++;
                }
                if (noneFound)
                {
                    //should only really hit this case if it's all 'a's?
                    StringBuilder sb = new StringBuilder(output);
                    sb[palindrome.Length - 1] = 'b';
                    output = sb.ToString();
                }
            }
            return output == palindrome ? "" : output;
        }

        /// <summary>
        /// is this an anagram of a palindrome?
        /// </summary>
        /// <param name="s">string to be checked</param>
        /// <returns></returns>
        public static bool IsPalindromeish(string s)
        {
            HashSet<char> letterDict = new HashSet<char>() { 'a' };
            char[] chars = s.ToCharArray();
            foreach(char c in chars)
            {
                if (letterDict.Contains(c)) { 
                    letterDict.Remove(c);
                } else
                {
                    letterDict.Add(c);
                }
            }
            return letterDict.Count <= 1;
        }

        int output = 0;
        public int PseudoPalindromicPaths(TreeNode root)
        {
            Dictionary<int,int> startPath = new Dictionary<int,int>();
            TraversePath(root, startPath);
            return output;
        }
        private void TraversePath(TreeNode c, Dictionary<int,int> path)
        {
            if (c == null) return;

            if (path.ContainsKey(c.val))
            {
                path.Remove(c.val);
            }
            else
            {
                path.Add(c.val,0);
            }

            if (c.left == null && c.right == null && path.Count <= 1)
            {
                output++;
            }
            TraversePath(c.left, new Dictionary<int,int>(path));
            TraversePath(c.right, new Dictionary<int,int>(path));
        }
    }
}
