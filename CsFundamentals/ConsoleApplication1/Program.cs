using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Xml.Serialization;

namespace ConsoleApplication1
{

    public class MyClass
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlElement]
        public int Age { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var s = File.Create("MyClass.xml"))
            {
                var x = new XmlSerializer(typeof(MyClass));
                x.Serialize(s, new MyClass { Name = "Gordon", Age = 33 });
            }
            using (var s = File.Open("MyClass.xml", FileMode.Open))
            {
                var x = new XmlSerializer(typeof(MyClass));
                var m = x.Deserialize(s) as MyClass;
                Console.WriteLine($"Name {m.Name} Age {m.Age}");

                Console.ReadLine();
            }
        }
    }
}
