using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground.DataStructures
{
    public class IntLinkedList
    {
        Node? Head = null;
        public class Node
        {
            public int Value;
            public Node? Next = null;

            public Node()
            {
                this.Value = 0;
            }

            public Node(int value)
            {
                this.Value = value;
            }

        }

        public void Sort()
        {
            Head = MergeSort(Head);
        }

        public void Push(int newValue)
        {
            Node newNode = new Node(newValue);
            newNode.Next = Head;
            Head = newNode;
        }

        public void Print()
        {
            string output = "";
            Node? headRef = Head;
            while (headRef != null)
            {
                output += headRef.Value + " ";
                headRef = headRef.Next;
            }
            Console.WriteLine(output);
        }

        private Node? MergeSort(Node? head)
        {
            //return if there's only one item in the list/list is empty
            if (head == null || head.Next == null)
            {
                return head;
            }
            // split the list in half (left & right)

            //middle is the end of the left list
            //middle.next is the start of the right list
            Node? middle = GetMiddle(head);
            Node? rightStart = middle.Next;

            //clear out the pointer at end of left list
            middle.Next = null;

            // recurse MergeSort on each half
            // aka keep splitting the list in half, merge them together in the right order on the way back up
            Node? left = MergeSort(head);
            Node? right = MergeSort(rightStart);

            // merge the halves back together after 
            Node? sorted = MergeHalves(left, right);
            return sorted;
        }

        private Node? MergeHalves(Node? left, Node? right)
        {
            Node? result = null;

            //return the rest of the other half if one is empty
            if(left == null)
            {
                return right;
            }
            if(right == null)
            {
                return left;
            }

            //plug in the lesser value, then continue comparing the remaining values
            if(left.Value <= right.Value)
            {
                result = left;
                result.Next = MergeHalves(left.Next, right);
            } else
            {
                result = right;
                result.Next = MergeHalves(left, right.Next);
            }

            return result;
        }

        private Node? GetMiddle(Node head)
        {
            if(head == null)
            {
                return head;
            }
            Node? fastCursor = head.Next;
            Node? cursor = head;

            //run two cursors across the list, second one moves by 2
            //fastCursor is null once it's hit the end - can then return cursor since it's half as far along
            while(fastCursor != null)
            {
                fastCursor = fastCursor.Next;
                if(fastCursor != null && cursor != null)
                {
                    cursor = cursor.Next;
                    fastCursor = fastCursor.Next;
                }
            }

            return cursor;
        }
    }

}
