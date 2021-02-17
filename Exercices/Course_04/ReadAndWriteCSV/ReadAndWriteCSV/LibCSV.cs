using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace ReadAndWriteCSV
{
    public class Étudiant
    {
        [CsvHelper.Configuration.Attributes.Name("Nom")]
        public string Nom { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Prénom")]
        public string Prénom { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Cycle")]
        public string Cycle { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Spécialité")]
        public string Spécialité { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Université")]
        public string Université { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Age")]
        public int Age { get; set; }

        public void Afficher()
        {
            Console.WriteLine(
                $"Nom : {this.Nom} | " +
                $"Prénom : {this.Prénom} | " +
                $"Age : {this.Age} | " +
                $"Cycle : {this.Cycle} | " +
                $"Spécialité : {this.Spécialité} | " +
                $"Université : {this.Université}"
            );
        }
    }

    class LibCSV
    {
        static public void SaveCSV(List<Étudiant> data, string filename)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(data);
            }
        }

        static public List<Étudiant> LoadCSV(string filename)
        {
            List<Étudiant> data;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, config))
            {
                data = csv.GetRecords<Étudiant>().ToList();
            }

            return data;
        }
    }
}
