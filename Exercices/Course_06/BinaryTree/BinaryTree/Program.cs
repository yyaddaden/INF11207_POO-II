using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Node 
    {
        public Node(int value) 
        {
            this.value = value;
        }

        public int value;
        public Node lNode = null;
        public Node rNode = null;

        public static void infix(Node node)
        { 
            if(node != null)
            {
                infix(node.lNode);
                Console.WriteLine(node.value);
                infix(node.rNode);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* premier niveau (initialisation) */
            Node arbre = new Node(12);

            /* second niveau */
            arbre.lNode = new Node(9);
            arbre.rNode = new Node(14);

            /* troisième niveau */
            arbre.lNode.lNode = new Node(8);
            arbre.lNode.rNode = new Node(10);

            arbre.rNode.lNode = new Node(13);
            arbre.rNode.rNode = new Node(16);

            /* affichage des valeurs par parcours infix */
            Node.infix(arbre);

            Console.ReadKey();
        }
    }
}
