using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PileDossier
{
    class Dossier 
    {
        public Dossier(string code, string requérant, string type)
        {
            this.code = code;
            this.requérant = requérant;
            this.type = type;
        }

        private string code;
        private string requérant;
        private string type;

        public void Affichage()
        {
            Console.WriteLine($"{this.code} | {this.requérant} | {this.type}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<Dossier> dossiers = new Stack<Dossier>();

            /* remplissage */
            dossiers.Push(new Dossier("X001", "Albert", "automobile"));
            dossiers.Push(new Dossier("X002", "Sophie", "santé"));
            dossiers.Push(new Dossier("X003", "Jordan", "automobile"));
            dossiers.Push(new Dossier("X004", "Émilie", "Domicile"));

            Console.WriteLine($"Il y {dossiers.Count()} dossiers dans la pile.");

            /* accès au premier élément de la pile avec pop() */
            Dossier dossier = dossiers.Pop();
            dossier.Affichage();
            Console.WriteLine($"Il y {dossiers.Count()} dossiers dans la pile.");

            /* accès au premier élément de la pile avec pop() */
            dossier = dossiers.Peek();
            dossier.Affichage();
            Console.WriteLine($"Il y {dossiers.Count()} dossiers dans la pile.");

            Console.ReadKey();
        }
    }
}
