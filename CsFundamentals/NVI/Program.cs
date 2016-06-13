using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVI
{
    class MyClass : IDisposable
    {
        private bool disposed = false;

        protected virtual void M1()
        {
            Console.WriteLine("sssssssssss");

        }

        public void M2()
        {
            M1();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }

    class MyClass1 : MyClass
    {
        bool isDisposed = false;
        Stream stream;

        protected override void M1()
        {
            Console.WriteLine("aaaaaaaaaaaaaa");

        }

        protected override void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                stream?.Dispose();
                isDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var m = new MyClass1())
            {
                Console.WriteLine("Pre");
                m.M2();
            }
            Console.WriteLine("Aft");
            Console.ReadLine();


        }
    }
}
