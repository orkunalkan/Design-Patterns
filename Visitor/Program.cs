using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager engin = new Manager { Name = "Engin", Salary = 1200 };
            Manager tekin = new Manager { Name = "Tekin", Salary = 1100 };

            Worker orkun = new Worker { Name = "Orkun", Salary = 2100 };
            Worker emre = new Worker { Name = "Emre", Salary = 2100 };


            engin.Subordinates.Add(tekin);
            tekin.Subordinates.Add(orkun);
            tekin.Subordinates.Add(emre);

            OrganizationalStructure organizationalStructure = new OrganizationalStructure(engin);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            payriseVisitor payriseVisitor = new payriseVisitor();

            organizationalStructure.Accept(payrollVisitor);
            organizationalStructure.Accept(payriseVisitor);

            Console.ReadLine();
        }
    }
    class OrganizationalStructure
    {
        public EmployeeBase Employee;
        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }


    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach(var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager worker);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} Paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} Paid {1}", manager.Name, manager.Salary);
        }
    }

    class payriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }
}
