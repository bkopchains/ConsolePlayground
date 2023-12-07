namespace Console_Playground
{
    internal class ReorderLogFiles
    {

        public string[] Reorder(string[] logs)
        {
            List<string> Letters = new List<string>();
            List<string> Digits = new List<string>();

            foreach (string log in logs)
            {
                string firstVal = firstValue(log);
                if (int.TryParse(firstVal, out _))
                {
                    Digits.Add(log);
                }
                else
                {
                    Letters.Add(log);
                }
            }

            Letters.Sort((a, b) => trimId(a).CompareTo(trimId(b)));
            return Letters.Concat(Digits).ToArray();
        }

        private string trimId(string input)
        {
            return input.Split(' ', 2)[1];
        }

        private string firstValue(string input)
        {
            char test;
            return input.Split(' ', 3)[1];
        }


    }
}
