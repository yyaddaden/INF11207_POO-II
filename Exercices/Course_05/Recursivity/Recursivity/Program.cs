using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursivity
{
    class Program
    {
        /* Exercice I */
        static int PGCD(int n, int m)
        {
            if (n == m)
                return n;
            else if (n > m)
                return PGCD(n - m, m);
            else
                return PGCD(n, m - n);
        }

        /* Exercice II */
        static void Dec2Bin(int n)
        {
            if (n == 0)
                Console.Write("0");
            else if (n == 1)
                Console.Write("1");
            else
            {
                Dec2Bin(n / 2);
                Console.Write(n % 2);
            }
        }

        /* Exercice III */
        static int MaxTab(int[] tab, int n)
        {
            int m = -1;

            if (n == 1)
                return tab[0];
            else
                m = MaxTab(tab, n - 1);

            if (m > tab[n - 1])
                return m;
            else
                return tab[n - 1];
        }

        /* Exercice IV */
        static bool Palin(string mot)
        {
            if (mot.Length == 1)
                return true;
            else if (mot[0] == mot[mot.Length - 1])
                return Palin(mot.Substring(1, mot.Length - 2));
            else
                return false;
        }

        /* Exercice V */
        static int Pascal(int lin, int col)
        {
            if (col == 0 || col == lin)
                return 1;
            else
                return Pascal(lin - 1, col - 1) + Pascal(lin - 1, col);
        }

        static void Main(string[] args)
        {
            /* Exercice I */
            Console.WriteLine(PGCD(12, 36));

            /* Exercice II */
            Dec2Bin(9);

            /* Exercice III */
            int[] tab = new int[] { 4, 8, 10, 78, 6, 2 };
            Console.WriteLine(MaxTab(tab, tab.Length));

            /* Exercice IV */
            Console.WriteLine(Palin("ressasser"));

            /* Exercice V */
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($"{Pascal(i, j)} ");
                }
                Console.Write("1\n");
            }

            Console.ReadKey();
        }
    }
}