using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Singletons
    {
        private Singletons() { }

        private static Singletons instance;

        private static object lockObject = new object();

        public static Singletons UseInstance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Singletons();
                    }
                }
                return instance;
            }

        }
        public void Save()
        {
            Console.WriteLine("Saved!!");
        }

    }
}
