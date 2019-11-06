using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesQuiz
{
    class Node<T>
    {

        public T data { get; set; }
        public Node<T> left { get; set; }
        public Node<T> right { get; set; }
        public Node(T data)
        {
            this.data = data;
        }
        public Node(T data, Node<T> left, Node<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }

    class BinaryTree<T>
    {
        public Node<T> root;
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Node<int> root = new Node<int>(5);
            AddToTree(root, 4);
            AddToTree(root, 8);
            AddToTree(root, 7);
            AddToTree(root, 12);
            AddToTree(root, 3);
            AddToTree(root, 4);
            AddToTree(root, 1);
            Console.WriteLine(SumOfNodes(root));
            Console.ReadLine();
        }

        public static Node<int> AddToTree(Node<int> root, int newData)
        {
            if (root == null)
            {
                Node<int> newNode = new Node<int>(newData);
                return newNode;
            }
            else if (newData < root.data)
            {
                root.left = AddToTree(root.left, newData);
            }
            else
            {
                root.right = AddToTree(root.right, newData);
            }
            return root;
        }

        public static int SumOfNodes(Node<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            return root.data + (SumOfNodes(root.left) + SumOfNodes(root.right));
        }

        public static bool IsCalculationTree(Node<int> root)
        {
            if (root == null)
            {
                return true;
            }
            if (root.left != null && root.left.data > root.data)
            {
                return false;
            }
            if (root.right != null && root.right.data < root.data)
            {
                return false;
            }
            if (!IsCalculationTree(root.left) || !IsCalculationTree(root.right))
            {
                return false;
            }
            return true;
        }

        public static int TraversalOfTree(Node<int> root)
        {
            if  (root == null)
            {
                TraversalOfTree(root.left);
                TraversalOfTree(root.right);
                Console.WriteLine(" {0} ", root.data);
            }
            return 0;
        }

    }
}
