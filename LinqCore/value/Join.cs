using System;
using System.Linq;
using Newtonsoft.Json;

namespace LinqCore.value
{
    class Join
    {
        public static void Exec()
        {
            Person[] persons = new Person[] {
                 new Person{ CityID = 1, Name = "ABC" },
                 new Person{ CityID = 1, Name = "EFG" },
                 new Person{ CityID = 2, Name = "HIJ" },
                 new Person{ CityID = 3, Name = "KLM" },
                 new Person{ CityID = 3, Name = "NOP" },
                 new Person{ CityID = 4, Name = "QRS" },
                 new Person{ CityID = 5, Name = "TUV" }
            };
            City[] cities = new City[]
            {
                 new City{ ID = 1,Name = "Guangzhou" },
                 new City{ ID = 2,Name = "Shenzhen" },
                 new City{ ID = 3,Name = "Beijing" },
                 new City{ ID = 4,Name = "Shanghai" }
            };

            var result = persons.Join(cities, p => p.CityID, c => c.ID, (p, c) => new { ID = c.ID, PersonName = p.Name, CityName = c.Name });
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }

    class Person
    {
        public int CityID { set; get; }
        public string Name { set; get; }
    }

    class City
    {
        public int ID { set; get; }
        public string Name { set; get; }
    }
}
