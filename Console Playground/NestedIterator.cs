using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{

    // This is the interface that allows for creating nested lists.
    // You should not implement it, or speculate about its implementation
    public interface INestedInteger
    {
        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();
        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();
        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }

    public class NestedInteger: INestedInteger
    {
        private int? integer = null;
        private IList<NestedInteger> list = null;
        public NestedInteger(int value, IList<NestedInteger> listValue)
        {
            int? integer = value;
            list = listValue;
        }

        public bool IsInteger()
        {
            return integer != null;
        }
        public int GetInteger()
        {
            return integer != null ? integer.Value : 0;
        }
        public IList<NestedInteger> GetList()
        {
            return list;
        } 
    }

    //https://learn.microsoft.com/en-us/dotnet/csharp/iterators
    //https://leetcode.com/problems/flatten-nested-list-iterator
    public class NestedIterator
    {

        private Queue<int> nextInts;

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            nextInts = new Queue<int>();
            foreach (int i in FlattenList(nestedList))
            {
                nextInts.Enqueue(i);
            }
        }

        private IEnumerable<int> FlattenList(IList<NestedInteger> nestedList)
        {
            foreach (NestedInteger n in nestedList)
            {
                if (n.IsInteger())
                {
                    yield return n.GetInteger();
                }
                else
                {
                    foreach (int i in FlattenList(n.GetList()))
                    {
                        yield return i;
                    }
                }
            }
        }

        public bool HasNext()
        {
            return nextInts.Count > 0;
        }

        public int Next()
        {
            return nextInts.Dequeue();
        }
    }
}
