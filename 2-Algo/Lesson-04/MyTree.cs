using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_04
{
    public class MyTree : ITree
    {
        TreeNode root;

        public void AddItem(int value)
        {
            TreeNode tempNode;
            TreeNode node = new TreeNode();
            node.Value = value;

            if (root is null)
                root = node;
            else
            {
                tempNode = root;
                while (true)
                {
                    if (value <= tempNode.Value)
                    {
                        if (tempNode.LeftChild is null)
                        {
                            tempNode.LeftChild = node;
                            node.Parent = tempNode;
                            break;
                        }
                        tempNode = tempNode.LeftChild;
                    }
                    else
                    {
                        if (tempNode.RightChild is null)
                        {
                            tempNode.RightChild = node;
                            node.Parent = tempNode;
                            break;
                        }
                        tempNode = tempNode.RightChild;
                    }
                }
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            TreeNode node = root;
            while (node != null)
            {
                if (value == node.Value)
                    break;
                else if (value <= node.Value)
                    node = node.LeftChild;
                else
                    node = node.RightChild;
            }
            return node;
        }

        public TreeNode GetRoot()
        {
            return root;
        }

        public void PrintTree()
        {
            Console.Clear();

            NodeInfo[] nodes = TreeHelper.GetTreeInLine(this);

            foreach (NodeInfo node in nodes)
            {
                for (int i = 0; i < node.Depth; i++)
                {
                    Console.Write("    ");
                }
                Console.Write(node.Node.Value);
                Console.WriteLine();
            }
        }

        public void RemoveItem(int value)
        {
            TreeNode toDelete = GetNodeByValue(value);
            if (toDelete is null)
                return;
            TreeNode temp;
            TreeNode middle;

            if (root.Value <= value)
            {
                middle = toDelete.LeftChild;
                if (middle != null)
                {
                    temp = toDelete.LeftChild;
                    while (temp != null)
                    {
                        middle = temp;
                        temp = temp.RightChild;
                    }
                    if (middle.Parent != null && toDelete.Equals(middle.Parent))
                    {
                        middle.Parent = toDelete.Parent;
                        middle.RightChild = toDelete.RightChild;
                    }
                    if (middle.Parent != null && !toDelete.Equals(middle.Parent))
                    {
                        middle.Parent.RightChild = middle.LeftChild;
                        middle.Parent = toDelete.Parent;
                        middle.LeftChild = toDelete.LeftChild;
                        middle.RightChild = toDelete.RightChild;
                    }
                }
            }
            else
            {
                middle = toDelete.RightChild;
                if (middle != null)
                {
                    temp = toDelete.RightChild;
                    while (temp != null)
                    {
                        middle = temp;
                        temp = temp.LeftChild;
                    }
                    if (middle.Parent != null && toDelete.Equals(middle.Parent))
                    {
                        middle.Parent = toDelete.Parent;
                        middle.LeftChild = toDelete.LeftChild;
                    }
                    if (middle.Parent != null && !toDelete.Equals(middle.Parent))
                    {
                        middle.Parent.LeftChild = middle.RightChild;
                        middle.Parent = toDelete.Parent;
                        middle.LeftChild = toDelete.LeftChild;
                        middle.RightChild = toDelete.RightChild;
                    }
                }
            }

            if (toDelete.Parent != null)
            {
                if (toDelete.Equals(toDelete.Parent.LeftChild))
                    toDelete.Parent.LeftChild = middle;
                else if (toDelete.Equals(toDelete.Parent.RightChild))
                    toDelete.Parent.RightChild = middle;
            }
            else if (root.Equals(toDelete))
                root = middle;
 
            toDelete.LeftChild = null;
            toDelete.RightChild = null;
            toDelete.Parent = null;
        }
    }
}
