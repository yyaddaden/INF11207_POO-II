using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursivity
{
    class Program
    {
        /* a. Récursivité simple */

        /* Exemple I */
        static int puissance(int x, int n)
        {
            if (n == 0)
                return 1;
            else
            {
                return x * puissance(x, n - 1);
            }
        }

        /* Exemple II */
        static int somme(int n)
        {
            if (n == 1)
                return 1;
            else
                return n + somme(n - 1);
        }

        /* b. Récursivité multiple */

        /* Exemple I */
        static int combinaison(int n, int p)
        {
            if (n == 1 || p == n)
                return 1;
            else
            {
                return combinaison(n, p - 1) + combinaison(n - 1, p - 1);
            }

        }

        /* Exemple II */
        static int fibonacci(int n)
        {

            if (n < 2)
                return n;
            else
            {
                return fibonacci(n - 1) + fibonacci(n - 2);
            }
        }

        static void Main(string[] args)
        {
            /* a.I */
            int x = 5, n = 3;
            Console.WriteLine($"Le résultat de {x}^{n} = {puissance(x, n)}");

            /* a.II */
            Console.WriteLine(somme(5));

            /* b.I */
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{combinaison(j, i)} ");
                }
                Console.Write("\n");
            }

            /* b.II */
            Console.Write("0 1 ");
            for (int i = 2; i < 8; i++)
            {
                Console.Write($"{fibonacci(i)} ");
            }

            Console.ReadKey();
        }
    }
}
