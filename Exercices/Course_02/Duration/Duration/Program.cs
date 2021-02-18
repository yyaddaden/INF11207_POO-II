using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duration
{
    class Program
    {
        static void Main(string[] args)
        {
            Durée durée1 = new Durée(3, 20, 10);
            Durée durée2 = new Durée(23, 34, 25);

            /* soustraction */
            (durée1 - durée2).Afficher();

            /* conversion en secondes */
            Console.WriteLine($"{(int)durée1} secondes");

            /* test d'égalité */
            Console.WriteLine($"{durée1 != durée2}");

            Console.ReadKey();
        }
    }
}
