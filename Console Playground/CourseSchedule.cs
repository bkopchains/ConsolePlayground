using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    public class CourseSchedule
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        List<int> TSort;
        Dictionary<int, int> InDegree;
        Dictionary<int, IList<int>> AdjList;
        Queue<int> IDZero;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            InDegree = new Dictionary<int, int>();
            AdjList = new Dictionary<int, IList<int>>();
            IDZero = new Queue<int>();
            TSort = new List<int>();

            foreach (int[] pair in prerequisites)
            {
                int course = pair[0];
                int prereq = pair[1];
                
                if (!AdjList.ContainsKey(prereq))
                {
                    AdjList.Add(prereq, new List<int>());
                }
                AdjList[prereq].Add(course);
            }

            foreach(KeyValuePair<int, IList<int>> kvp in AdjList)
            {
                int course = kvp.Key;
                IList<int> prereqs = kvp.Value;
                if (!InDegree.ContainsKey(course))
                {
                    InDegree.Add(course, 0);
                }
                foreach (int prereq in prereqs)
                {
                    if (InDegree.ContainsKey(prereq))
                    {
                        InDegree[prereq] += 1;
                    }
                    else
                    {
                        InDegree.Add(prereq, 1);
                    }
                }
            }

            foreach(KeyValuePair<int,int> vertex in InDegree)
            {
                if(vertex.Value == 0)
                {
                    IDZero.Enqueue(vertex.Key);
                }
            }

            int visitedCount = 0;
            while(IDZero.Count > 0)
            {
                int current = IDZero.Dequeue();
                TSort.Add(current);
                visitedCount++;

                //has edges
                if (AdjList.ContainsKey(current))
                {
                    foreach(int edge in AdjList[current])
                    {
                        if (InDegree[edge] > 0)
                        {
                            InDegree[edge]--;
                            if(InDegree[edge] == 0)
                            {
                                IDZero.Enqueue(edge);
                            }
                        }
                    }
                }
            }

            return visitedCount != InDegree.Count();
        }
    }
}
