// Sorting/tree/BinaryTree.cs
using Sorting.enemy;

namespace Sorting.tree
{
    public class BinaryTree
    {
        private class Node
        {
            public Enemy Data;
            public Node Left, Right;

            public Node(Enemy data)
            {
                Data = data;
                Left = Right = null;
            }
        }

        private Node root;

        public void Insert(Enemy data)
        {
            root = InsertRec(root, data);
        }

        private Node InsertRec(Node root, Enemy data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (string.Compare(data.Name, root.Data.Name) < 0)
                root.Left = InsertRec(root.Left, data);
            else
                root.Right = InsertRec(root.Right, data);

            return root;
        }

        public bool Search(string name)
        {
            return SearchRec(root, name);
        }

        private bool SearchRec(Node root, string name)
        {
            if (root == null) return false;

            int comparison = string.Compare(name, root.Data.Name);
            if (comparison == 0) return true;
            
            return comparison < 0 
                ? SearchRec(root.Left, name) 
                : SearchRec(root.Right, name);
        }
    }
}