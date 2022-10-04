namespace Console_Playground
{
    /// =>=>=>=>=>=>=>=>=>=>=>=>=>=>=>=>=
    /// SEE NumIslands.cs - same problem
    /// =>=>=>=>=>=>=>=>=>=>=>=>=>=>=>=>=
    public class Clouds
    {

        private int cloudsFound = 0;
        private int[][] sky;
        int[] vectorY = new int[4] { 0, 0, 1, -1 };
        int[] vectorX = new int[4] { 1, -1, 0, 0 };



        public int CountClouds(int[][] _sky)
        {
            //traverse the 'sky'
            //at 0
            // continue along vectors until we find 1
            //at 1


            sky = _sky;

            findCloud(0, 0, false);

            return cloudsFound;
        }

        private void findCloud(int startX, int startY, bool fromCloud)
        {
            int skyValue = sky[startY][startX];
            bool foundCloud = skyValue == 1;
            bool hasVisited = skyValue == -1;

            //mark sky as visited
            sky[startY][startX] = -1;

            //cloud found
            if (foundCloud)
            {
                if (!fromCloud)
                {
                    cloudsFound++;
                }
            }

            if (!hasVisited)
            {
                for (int j = 0; j < 4; j++)
                {
                    int dX = startX + vectorX[j];
                    int dY = startY + vectorY[j];
                    //check to make sure not out of bounds
                    if (dY < sky.Length && dX < sky[0].Length && dY >= 0 && dX >= 0)
                    {
                        findCloud(dX, dY, foundCloud);
                    }
                }
            }

        }
    }
}
