using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadAndWriteCSV
{
    class CustomCSV
    {
        static public bool SaveCSV(string[] header, string[,] data, string filename)
        {
            if (header.Length == data.GetLength(1))
            {
                using (StreamWriter sw = File.CreateText(filename))
                {
                    for (int i = 0; i < header.Length; i++)
                    {
                        if (i != header.Length - 1)
                            sw.Write($"{header[i]};");
                        else
                            sw.Write($"{header[i]}\n");
                    }

                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            if (j != data.GetLength(1) - 1)
                                sw.Write($"{data[i, j]};");
                            else
                                sw.Write($"{data[i, j]}\n");
                        }
                    }
                }
                return true;
            }
            else
                return false;
        }

        static public Dictionary<string, List<string>> LoadCSV(string filename)
        {
            Dictionary<string, List<string>> data = null;

            if (!File.Exists(filename))
            {
                Console.WriteLine("Erreur : Le fichier demandé n'existe pas !");
            }
            else
            {
                data = new Dictionary<string, List<string>>();
                string line;

                using (StreamReader sr = File.OpenText(filename))
                {
                    line = sr.ReadLine();

                    foreach (string item in line.Split(';'))
                    {
                        data.Add(item, new List<string>());
                    }

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        for (int i = 0; i < data.Count; i++)
                        {
                            data[data.Keys.ToList()[i]].Add(line.Split(';')[i]);
                        }
                    }
                }
            }

            return data;
        }
    }
}
