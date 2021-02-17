using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndWriteCSV
{
    class Program
    {
        static void TestCustomCSV()
        {
            /* data */
            string[] CustomCSV_header = new string[] { "Nom", "Prénom", "Age", "Cycle", "Spécialité", "Université" };
            string[,] CustomCSV_data = new string[,] {
                { "Bouchard", "Annette", "30", "3eme", "Administration", "UQAR" },
                { "Tremblay", "Antoine", "20", "1er", "Informatique", "UQAC" }
            };

            /* export */
            string log = (CustomCSV.SaveCSV(CustomCSV_header, CustomCSV_data, "CustomCSV_data.csv") ? "réussie" : "échouée");
            Console.WriteLine($"La sauvegarde est {log}");

            /* import */
            Dictionary<string, List<string>> dataLoad = CustomCSV.LoadCSV("CustomCSV_data.csv");

            log = (dataLoad != null ? "réussie" : "échouée");
            Console.WriteLine($"L'importation est {log}");

            foreach (KeyValuePair<string, List<string>> item in dataLoad)
            {
                Console.Write($"{item.Key} : ");

                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (i != item.Value.Count - 1)
                        Console.Write($"{item.Value[i]}, ");
                    else
                        Console.Write($"{item.Value[i]}\n");
                }
            }
        }

        static void TestLibCSV()
        {
            /* data */
            List<Étudiant> LibCSV_data = new List<Étudiant>
            {
                new Étudiant { Nom = "Bouchard", Prénom = "Annette", Age = 30, Cycle = "3eme", Spécialité = "Administration", Université = "UQAR" },
                new Étudiant { Nom = "Tremblay", Prénom = "Antoine", Age = 20, Cycle = "1er", Spécialité = "Informatique", Université = "UQAC" },
            };

            /* export */
            LibCSV.SaveCSV(LibCSV_data, "LibCSV_data.csv");

            /* import */
            List<Étudiant> dataLoad = LibCSV.LoadCSV("LibCSV_data.csv");

            foreach (Étudiant item in dataLoad)
            {
                item.Afficher();
            }
        }

        static void Main(string[] args)
        {
            TestCustomCSV();
            TestLibCSV();
            Console.ReadKey();
        }
    }
}
