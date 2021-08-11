using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
        class Logging:ILogging
        {
            public void Log()
            {
                Console.WriteLine("Logging with SimpleLog");
            }
        }
        class Caching:ICaching
        {
            public void Cache()
            {
                Console.WriteLine("Caching with SimpleCache");
            }
        }
        class Authorize:IAuthorize
        {
            public void CheckUser()
            {
                Console.WriteLine("Checking wit CheckUser");
            }
        }
        class CustomerManager
        {
            private CrossCuttingConcernsFacade _concerns;
            public CustomerManager()
            {
                _concerns = new CrossCuttingConcernsFacade();
            }

            public void Save()
            {
                _concerns.Caching.Cache();
                _concerns.Authorize.CheckUser();
                _concerns.Logging.Log();
                Console.WriteLine("Saved");
            }
        }
        class CrossCuttingConcernsFacade
        {
            public ILogging Logging;
            public ICaching Caching;
            public IAuthorize Authorize;
            public CrossCuttingConcernsFacade()
            {
                Logging = new Logging();
                Caching = new Caching();
                Authorize = new Authorize();
            }
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }
    internal interface ILogging
    {
        void Log();
    }
    internal interface ICaching
    {
        void Cache();
    }
}
