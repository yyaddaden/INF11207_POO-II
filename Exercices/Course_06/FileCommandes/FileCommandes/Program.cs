using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommandes
{
    class Program
    {
        class Commande
        {
            private Dictionary<string, float> list_prix = new Dictionary<string, float>() { 
                { "Neapolitan Pizza", 10 }, 
                { "Sicilian Pizza", 12 }, 
                { "California Pizza", 15 } 
            };
            private Dictionary<int, string> list_statut = new Dictionary<int, string>(){
                { 1, "En attente" },
                { 2, "Annulée" },
                { 3, "Traitée" },
            };

            public Commande(string code, string type)
            {
                this.code = code;
                this.type = type;
                this.statut = "En attente";
                this.prix = list_prix[type];
            }

            private string code;
            private string type;
            private float prix;
            public string statut;

            public void ChangerStatut(int statut_code)
            {
                this.statut = list_statut[statut_code];
            }

            public void Affichage()
            {
                Console.WriteLine($"{this.code} | {this.type} | {this.prix} CAD | {statut}");
            }
        }

        static void Main(string[] args)
        {
            Queue<Commande> commandes = new Queue<Commande>();

            /* remplissage */
            commandes.Enqueue(new Commande("X001", "Sicilian Pizza"));
            commandes.Enqueue(new Commande("X002", "California Pizza"));
            commandes.Enqueue(new Commande("X003", "Sicilian Pizza"));
            commandes.Enqueue(new Commande("X004", "Neapolitan Pizza"));

            Console.WriteLine($"Il y {commandes.Count()} commandes dans la file.");

            /* accès au premier élément de la file avec dequeue() */
            Commande commande = commandes.Dequeue();
            commande.ChangerStatut(2);
            commande.Affichage();
            Console.WriteLine($"Il y {commandes.Count()} commandes dans la file.");

            /* accès au premier élément de la pile avec pop() */
            commande = commandes.Peek();
            commande.ChangerStatut(3);
            commande.Affichage();
            Console.WriteLine($"Il y {commandes.Count()} commandes dans la file.");

            Console.ReadKey();
        }
    }
}
