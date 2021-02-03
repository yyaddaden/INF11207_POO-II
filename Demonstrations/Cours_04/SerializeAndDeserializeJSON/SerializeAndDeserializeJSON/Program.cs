using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* added dependencies */
using Newtonsoft.Json;
using System.IO;

namespace SerializeAndDeserializeJSON
{
    /* entity declaration */
    class Person
    {
        public string lastname;
        public string firstname;
        public string job;
        public int age;

        public Person() { }

        public Person(string lastname, string firstname, string job, int age)
        {
            this.lastname = lastname;
            this.firstname = firstname;
            this.job = job;
            this.age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* object creation */
            Person person_1 = new Person("Bouchard", "Albert", "Professor", 35);

            /* serialization and display */
            string person_1_serialized = JsonConvert.SerializeObject(person_1);
            Console.WriteLine(person_1_serialized);

            /* deserialization and display */
            Person person_1_deserialized = JsonConvert.DeserializeObject<Person>(person_1_serialized);
            Console.WriteLine(
                $"lastename -> {person_1_deserialized.lastname}, " +
                $"firstname -> {person_1_deserialized.firstname}, " +
                $"job -> {person_1_deserialized.job}, " +
                $"age -> {person_1_deserialized.age}"
            );

            /* save in .json file */
            File.WriteAllText("user_info.json", JsonConvert.SerializeObject(person_1, Formatting.Indented));

            /* read from .json file */
            Person person_1_read_deserialized = JsonConvert.DeserializeObject<Person>(File.ReadAllText("user_info.json"));
            Console.WriteLine(
                $"lastename -> {person_1_read_deserialized.lastname}, " +
                $"firstname -> {person_1_read_deserialized.firstname}, " +
                $"job -> {person_1_read_deserialized.job}, " +
                $"age -> {person_1_read_deserialized.age}"
            );

            /* example list of object */
            List<Person> list_persons = new List<Person>();
            Person person_2 = new Person("Desjardins", "Antoine", "Student", 20);
            list_persons.Add(person_1);
            list_persons.Add(person_2);

            File.WriteAllText("users_info.json", JsonConvert.SerializeObject(list_persons, Formatting.Indented));

            List<Person> list_persons_read_deserialized = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText("users_info.json"));
            Console.WriteLine(
                $"lastename -> {list_persons_read_deserialized[1].lastname}, " +
                $"firstname -> {list_persons_read_deserialized[1].firstname}, " +
                $"job -> {list_persons_read_deserialized[1].job}, " +
                $"age -> {list_persons_read_deserialized[1].age}"
            );

            Console.ReadKey();
        }
    }
}
