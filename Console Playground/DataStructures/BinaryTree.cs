namespace Console_Playground.DataStructures
{
    public class TreeNode<T>
    {
        public T? val;
        public TreeNode<T>? left;
        public TreeNode<T>? right;
        public TreeNode(T? val, TreeNode<T>? left = null, TreeNode<T>? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class BinaryTree
    {
        //runs faster than FindLeaves, but is listed as more expensive? Does loop a bit more here
        public IList<IList<int>> FindLeaves_Expensive(TreeNode root)
        {
            IList<IList<int>> output = new List<IList<int>>();
            while (!isLeaf(root))
            {
                List<int> currentLeaves = new List<int>();
                trimLeaves(root, currentLeaves);
                output.Add(currentLeaves);
            }
            output.Add(new List<int> { root.val });
            return output;
        }
        private void trimLeaves(TreeNode current, IList<int> currentLeaves)
        {
            //get the leaves
            if (current.left != null)
            {
                if (isLeaf(current.left))
                {
                    currentLeaves.Add(current.left.val);
                    current.left = null;
                }
                else
                {
                    //recurse
                    trimLeaves(current.left, currentLeaves);
                }
            }
            if (current.right != null)
            {
                if (isLeaf(current.right))
                {
                    currentLeaves.Add(current.right.val);
                    current.right = null;
                }
                else
                {
                    //recurse
                    trimLeaves(current.right, currentLeaves);
                }
            }
        }
        private bool isLeaf(TreeNode node)
        {
            return node.left == null && node.right == null;
        }

        private IList<IList<int>> output;
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            output = new List<IList<int>>();
            getHeight(root);
            return output;
        }
        private int getHeight(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            int leftHeight = getHeight(root.left);
            int rightHeight = getHeight(root.right);

            //+1 to account for -1 when we hit the end
            int currentHeight = Math.Max(leftHeight, rightHeight) + 1;

            if (output.Count == currentHeight)
            {
                output.Add(new List<int>());
            }

            output[currentHeight].Add(root.val);

            return currentHeight;
        }


        //List<string> startPath;
        //List<string> endPath;
        //int startVal;
        //int endVal;
        //public string GetDirections(TreeNode root, int startValue, int destValue)
        //{
        //    startVal = startValue;
        //    endVal = destValue;
        //    //traverse the tree

        //    //indices in the paths match the depth in the tree
        //    startPath = new List<string>();
        //    endPath = new List<string>();
        //    TraverseStart(root, new List<string>());
        //    TraverseEnd(root, new List<string>());
        //    return string.Join(',', startPath) + " --- " + string.Join(',', endPath);
        //}
        //private void TraverseStart(TreeNode root, List<string> path)
        //{
        //    if (root != null && !startPath.Any())
        //    {
        //        List<string> pathL = path;
        //        List<string> pathR = path;
        //        if (root.val == startVal && !startPath.Any())
        //        {
        //            startPath = path;
        //        }
        //        TraverseStart(root.left, pathL);
        //        TraverseStart(root.right, pathR);
        //        path.Add(root.val.ToString());
        //    }
        //}
        //private void TraverseEnd(TreeNode root, List<string> path)
        //{
        //    if (root != null && !endPath.Any())
        //    {
        //        path.Add(root.val.ToString());
        //        List<string> pathL = path;
        //        List<string> pathR = path;
        //        if (root.val == endVal && !endPath.Any())
        //        {
        //            endPath = path;
        //        }
        //        TraverseEnd(root.left, pathL);
        //        TraverseEnd(root.right, pathR);
        //    }
        //}

        //private enum TreeStatus
        //{
        //    BothPending,
        //    LeftDone,
        //    BothDone
        //}
        //private Stack<Tuple<TreeNode, TreeStatus>> TreeStatusStack = new Stack<Tuple<TreeNode, TreeStatus>>();

        //public string GetDirections(TreeNode root, int startValue, int destValue)
        //{
        //    TreeStatusStack.Push(new Tuple<TreeNode, TreeStatus>(root, TreeStatus.BothPending));
        //    TreeStatusStack.
        //    bool foundOne = false;
        //    while (TreeStatusStack.Count > 0)
        //    {
        //        if (root.val == startValue || root.val == destValue)
        //        {
        //            if (foundOne)
        //            {

        //            } else
        //            {

        //            }
        //        }
        //        if (root.left != null)
        //        {
        //            Tuple<TreeNode, TreeStatus> last = TreeStatusStack.Pop();
        //            TreeStatusStack.Push(new Tuple<TreeNode, TreeStatus>(last.Item1, TreeStatus.LeftDone));
        //        }
        //        if (root.right != null)
        //        {
        //            Tuple<TreeNode, TreeStatus> last = TreeStatusStack.Pop();
        //            TreeStatusStack.Push(new Tuple<TreeNode, TreeStatus>(last.Item1, TreeStatus.BothDone));
        //        }
        //    }

        //}
    }

    public class MinHeap
    {
        public TreeNode<int> root;

        public MinHeap(IEnumerable<int> values)
        {
            root.val = values.FirstOrDefault();
        }

        public void Add(int value)
        {

        }
        private void Add(int value, TreeNode<int> pointer)
        {
            int currentValue = value;
            if(pointer.val > value)
            {

            }
        }
    }
}
