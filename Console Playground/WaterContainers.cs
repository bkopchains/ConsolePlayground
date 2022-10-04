namespace Console_Playground
{
    internal class WaterContainers
    {
        private int[] height;
        private int maxVolume = 0;
        private int lineA = 0;
        private int lineB = 0;
        private int end = 0;

        public int MaxArea(int[] height)
        {
            this.height = height;
            lineB = height.Length - 1;
            end = height.Length - 1;

            while (lineB > lineA)
            {
                updateMax();
                if (height[lineA] >= height[lineB])
                {
                    lineB--;
                }
                else
                {
                    lineA++;
                }
            }

            return maxVolume;
        }

        private void updateMax()
        {
            int volume = Math.Min(height[lineA], height[lineB]) * (lineB - lineA);
            maxVolume = Math.Max(volume, maxVolume);
        }

        ////Greedy algo
        //public int MaxArea(int[] height)
        //{
        //    //maximize container volume (area)
        //    int end = height.Length - 1;
        //    for (int lineA = 0; lineA < end; lineA++)
        //    {
        //        for (int lineB = lineA + 1; lineB <= end; lineB++)
        //        {
        //            //volume = min(lineA,lineB) * distance between the lines
        //            updateMax();
        //        }
        //    }
        //    return maxVolume;
        //}


    }
}
