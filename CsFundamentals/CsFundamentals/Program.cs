using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace CsFundamentals
{
    [Serializable]
    public class MyClass
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = File.Create("MyClass.xml");
            var f = new SoapFormatter();
            var m = new MyClass { Name = "G", Age = 1 };


            f.Serialize(s, m);
            s.Close();
            var ss = File.Open("MyClass.xml", FileMode.Open);

            MyClass m1 = f.Deserialize(ss) as MyClass;
            ss.Dispose();
            Console.WriteLine($"Name {m1.Name} Age {m1.Age}");
            Console.ReadLine();

        }
    }
}
