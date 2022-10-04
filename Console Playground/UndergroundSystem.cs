using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    public class UndergroundSystem
    {

        //startStation: { endStation: [...avg times to reach] }
        Dictionary<string, Dictionary<string, List<int>>> routeTimes;
        Dictionary<int, Tuple<string, int>> customerLog;

        public UndergroundSystem()
        {
            routeTimes = new Dictionary<string, Dictionary<string, List<int>>>();
            customerLog = new Dictionary<int, Tuple<string, int>>();
        }

        public void CheckIn(int id, string stationName, int t)
        {
            if (!customerLog.ContainsKey(id))
            {
                customerLog.Add(id, new Tuple<string, int>(stationName, t));
            }
        }

        public void CheckOut(int id, string endStation, int t)
        {
            if (customerLog.ContainsKey(id))
            {
                Tuple<string, int> startStation;
                customerLog.Remove(id, out startStation);

                if (routeTimes.ContainsKey(startStation.Item1))
                {
                    routeTimes[startStation.Item1][endStation].Add(t - startStation.Item2);
                }
                else
                {
                    routeTimes[startStation.Item1] = new Dictionary<string, List<int>>{
                    { endStation, new List<int>{ t-startStation.Item2 } }
                };
                }
            }
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            //no need to check if it exists allegedly?
            return routeTimes[startStation][endStation].Average();
        }
    }

    /**
     * Your UndergroundSystem object will be instantiated and called as such:
     * UndergroundSystem obj = new UndergroundSystem();
     * obj.CheckIn(id,stationName,t);
     * obj.CheckOut(id,stationName,t);
     * double param_3 = obj.GetAverageTime(startStation,endStation);
     */

    //first thought - graph
    //second thought - nested dictionaries

    public class RandomizedSet
    {
        //val, idx
        Dictionary<int, int> valMap;
        List<int> valList;

        public RandomizedSet()
        {
            valMap = new Dictionary<int, int>();
            valList = new List<int>();
        }

        public bool Insert(int val)
        {
            if (!valMap.ContainsKey(val))
            {
                valMap.Add(val, valList.Count);
                valList.Add(val);
                return true;
            }
            return false;
        }

        public bool Remove(int val)
        {
            if (valMap.ContainsKey(val))
            {
                int removeIdx = valMap[val];
                int last = valList.Last();
                
                valList.RemoveAt(valList.Count-1);
                valList[removeIdx] = last;

                valMap.Remove(val);
                valMap[last] = removeIdx;

                return true;
            }
            return false;
        }

        public int GetRandom()
        {
            Random rand = new Random();
            return valList[rand.Next(valList.Count)];
        }
    }
}
