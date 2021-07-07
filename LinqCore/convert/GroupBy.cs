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
        new   Person
        {
            Name = "P2", Age = 17,Gender = "Female", Type = "A"
        }
      };

      //（1）单字段分组
      //var groups = personList.GroupBy(p => p.Gender);
      //（1-1）多字段分组
      //var groups = personList.GroupBy(p => new { p.Gender, p.Type });

      //（2）使用相等比较器类
      //var groups = personList.GroupBy(p => p, new PersonEqualityComparer());

      //（3）定制化分组结果集
      //var groups = personList.GroupBy(p => p.Gender, p => p.Name);
      //var groups = personList.GroupBy(p => new { p.Gender, p.Type }, p => p.Name);

      //（4）返回自定义的类型
      //string GetPersonInfo(string gender, IEnumerable<Person> persons)
      //{
      //  string result = $"{gender}:\t";
      //  foreach (var p in persons)
      //  {
      //    result += $"{p.Name},{p.Age}\t";
      //  }
      //  return result;
      //}
      //var results = personList.GroupBy(p => p.Gender, (g, ps) => GetPersonInfo(g, ps));

      //（5）---（2）使用相等比较器类 +（3）定制化分组结果集
      //var groups = personList.GroupBy(p => p, p => new { p.Age, p.Gender }, new PersonEqualityComparer());

      //（6）---（2）使用相等比较器类 +（4）返回自定义的类型
      //string GetPersonInfo(Person person, IEnumerable<Person> persons)
      //{
      //  string result = $"{person.ToString()}:\t";
      //  foreach (var p in persons)
      //  {
      //    result += $"{p.Age},{p.Gender}\t";
      //  }
      //  return result;
      //}
      //var results = personList.GroupBy(p => p, (p, ps) => GetPersonInfo(p, ps), new PersonEqualityComparer());

      //（7）---（3）定制化分组结果集 +（4）返回自定义的类型
      //string GetPersonInfo(string gender, IEnumerable<string> names)
      //{
      //  string result = $"{gender}:\t";
      //  foreach (var name in names)
      //  {
      //    result += $"{name}\t";
      //  }
      //  return result;
      //}
      //var results = personList.GroupBy(p => p.Gender, (p => p.Name), (g, ns) => GetPersonInfo(g, ns));

      //（8）---（2）使用相等比较器类 +（3）定制化分组结果集 +（4）返回自定义的类型
      var results = personList.GroupBy(p => p, (p => new { p.Age, p.Gender }),
                (p, ns) =>
                {
                  string result = $"{p.ToString()}:\t";
                  foreach (var n in ns)
                  {
                    result += $"{n.Age},{p.Gender}\t";
                  }
                  return result;
                }, new PersonEqualityComparer());

      //foreach (var group in groups)
      //{
      //  Console.WriteLine(group.Key);
      //  foreach (var person in group)
      //  {
      //    //Console.WriteLine($"\t{person.Name},{person.Age}");

      //    //（3）定制化分组结果集
      //    //Console.WriteLine($"\t{person}");

      //    //（5）---（2）使用相等比较器类 +（3）定制化分组结果集
      //    Console.WriteLine($"\t{person.Age},{person.Gender}");
      //  }
      //}

      //返回自定义的类型
      foreach (var result in results)
      {
        Console.WriteLine(result);
      }
      Console.WriteLine();
      //Console.WriteLine(JsonConvert.SerializeObject(groups, Formatting.Indented));
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

  class PersonEqualityComparer : IEqualityComparer<Person>
  {
    public bool Equals(Person x, Person y) => x.Name == y.Name;
    public int GetHashCode(Person obj) => obj.Name.GetHashCode();
  }
}
