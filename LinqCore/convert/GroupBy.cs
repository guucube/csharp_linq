using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace LinqCore.convert
{
    class GroupBy
    {
        public static void Exec()
        {
            List<Person> personList = new List<Person>
            {
                new Person
                {
                    Name = "P1", Age = 18, Gender = "Male", Type = "A"
                },
                new Person
                {
                    Name = "P2", Age = 19, Gender = "Male", Type = "A"
                },
                new Person
                {
                    Name = "P2-2", Age = 30, Gender = "Male", Type = "B"
                },
                new Person
                {
                    Name = "P2", Age = 17,Gender = "Female", Type = "A"
                }
            };

            var groups = personList.GroupBy(p => p.Gender);
            //var groups = personList.GroupBy(p => new { p.Gender, p.Type });
            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach (var person in group)
                {
                    Console.WriteLine($"\t{person.Name},{person.Age}");
                }
            }
            Console.WriteLine();
            Console.WriteLine(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }
    }

    class Person
    {
        public string Type { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public string Gender { set; get; }
        public override string ToString() => Name;
    }
}
