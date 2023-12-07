using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    public class StringMultiply
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";

            Dictionary<char, int> nums = new Dictionary<char, int>();
            nums.Add('0', 0);
            nums.Add('1', 1);
            nums.Add('2', 2);
            nums.Add('3', 3);
            nums.Add('4', 4);
            nums.Add('5', 5);
            nums.Add('6', 6);
            nums.Add('7', 7);
            nums.Add('8', 8);
            nums.Add('9', 9);

            //long multiplication yay

            string output = "";

            List<string> toAdd = new List<string>();
            int magnitude = 0;
            for (int i = num1.Length; i >= 0; i--)
            {
                string numString = new String('0', magnitude);
                int carry = 0;
                for (int j = num2.Length; j >= 0; j--)
                {
                    string multiplication = "" + (nums[num1[i]] * nums[num2[j]]) + carry;
                    carry = nums[multiplication[0]];
                    numString = multiplication[1] + numString;
                }
                char[] strArray = numString.ToCharArray();
                Array.Reverse(strArray);
                toAdd.Add(new string(strArray));
                magnitude++;
            }
            for (int i = 0; i < toAdd.Max(x => x.Length); i++)
            {
                string numString = "";
                int carry = 0;
                for (int j = 0; j < toAdd.Count; j++)
                {
                    string current = toAdd[j];
                    if(current.Length > i)
                    {
                        string result = "" + current[i];
                    } 
                }
                toAdd.Add(numString);
                magnitude++;
            }

            return output;
        }
    }
}
