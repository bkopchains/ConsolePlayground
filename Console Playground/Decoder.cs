using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    public class Decoder
    {

        public string DecodeString(string s)
        {
            //check s length


            int repeatVal0 = 0;
            bool canConvert0 = int.TryParse(s.Substring(0, 1), out repeatVal0);


            if (canConvert0)
            {
                //hit number - check how large the number is
                int repeatVal1 = 0;
                bool canConvert1 = int.TryParse(s.Substring(0, 2), out repeatVal1);
                if (canConvert1)
                {
                    int repeatVal2 = 0;
                    bool canConvert2 = int.TryParse(s.Substring(0, 3), out repeatVal2);
                    if (canConvert2)
                    {
                        return string.Concat(Enumerable.Repeat(DecodeString(s.Substring(4)), repeatVal2));
                    }
                    else
                    {
                        return string.Concat(Enumerable.Repeat(DecodeString(s.Substring(3)), repeatVal1));
                    }
                }
                else
                {
                    return string.Concat(Enumerable.Repeat(DecodeString(s.Substring(2)), repeatVal0));
                }

            }
            else
            {
                int idx = 0;
                string output = "";
                while (idx < s.Length && s.Substring(idx, 1) != "]")
                {
                    bool hitNumber = int.TryParse(s.Substring(idx, 1), out _);
                    if (hitNumber)
                    {
                        //hit number
                        output += DecodeString(s.Substring(idx));
                        while (idx < s.Length && s.Substring(idx - 1, 1) != "]")
                        {
                            idx++;
                        }
                    }
                    else
                    {
                        //hit letter - add to running section
                        output += s.Substring(idx, 1);
                        idx++;
                    }

                }
                return output;
            }
        }
    }
}
