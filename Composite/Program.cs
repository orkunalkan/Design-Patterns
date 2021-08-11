using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee orkun = new Employee { Name = "OrkunA" };
            Employee emre = new Employee { Name = "EmreA" };
            Employee deniz = new Employee { Name = "DenizA" };
            Employee ahmet = new Employee { Name = "AhmetA" };
            orkun.AddSubordinate(emre);
            orkun.AddSubordinate(deniz);
            emre.AddSubordinate(ahmet);

            foreach (Employee person in orkun)
            {
                Console.WriteLine("  {0}",person.Name);

                foreach (IPerson employee in person)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }
    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
