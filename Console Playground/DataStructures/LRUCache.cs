namespace Console_Playground.DataStructures
{
    public class LRUCache
    {
        public class DLLNode
        {
            public int Key;
            public int Value;
            public DLLNode Prev;
            public DLLNode Next;
        }

        //don't touch these, just to hold on to start/end
        DLLNode head;
        DLLNode tail;

        Dictionary<int, DLLNode> cache;
        int capacity;
        int size;

        public LRUCache(int capacity)
        {
            cache = new Dictionary<int, DLLNode>();
            head = new DLLNode();
            tail = new DLLNode();
            head.Key = -1;
            head.Value = -1;
            head.Prev = null;
            head.Next = tail;

            tail.Key = -1;
            tail.Value = -1;
            tail.Prev = head;
            tail.Next = null;

            this.capacity = capacity;
            size = 0;
        }

        //moves key to front of list
        public void MoveUp(DLLNode current)
        {
            Remove(current);
            Insert(current);
        }

        public int Get(int key)
        {
            //get from dict
            DLLNode output;
            bool found = cache.TryGetValue(key, out output);
            //if exists
            if (found)
            {
                //move key to front of list
                MoveUp(output);
                //return value
                return output.Value;
            }
            //else 
            return -1;
        }

        public void Remove(DLLNode removed)
        {
            removed.Prev.Next = removed.Next;
            removed.Next.Prev = removed.Prev;
        }

        //evicts the last item, returns its key
        public int Evict()
        {
            DLLNode last = tail.Prev;
            Remove(last);
            return last.Key;
        }

        //adds key to front of list
        public void Insert(DLLNode inserted)
        {
            inserted.Prev = head;
            inserted.Next = head.Next;

            head.Next.Prev = inserted;
            head.Next = inserted;
        }

        public void Put(int key, int value)
        {
            //get from dict
            DLLNode node;
            bool found = cache.TryGetValue(key, out node);
            //if exists
            if (!found)
            {
                DLLNode newNode = new DLLNode()
                {
                    Key = key,
                    Value = value
                };

                cache.Add(key, newNode);
                Insert(newNode);

                size++;

                if (size > capacity)
                {
                    int removedKey = Evict();
                    cache.Remove(removedKey);
                    size--;
                }
            }
            else
            {
                node.Value = value;
                MoveUp(node);
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
