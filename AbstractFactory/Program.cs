using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();

        }
        public abstract class Logging
        {
            public abstract void Log(string message);
        }
        public class Log4NetLogger:Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logging with Log4Net");
            }
        }
        public class Log4GameLogger:Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logging with Log4Game");
            }
        }
        public abstract class Caching
        {
            public abstract void Cache(string data);
        }
        public class MemCache:Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with MemCache");
            }
        }
        public class RedisCache:Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with RedisCache");
            }
        }
        public abstract class CrossCuttingConcernsFactory
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();
        }

        public class Factory1 : CrossCuttingConcernsFactory
        {
            public override Logging CreateLogger()
            {
                return new Log4GameLogger();
            }
            public override Caching CreateCaching()
            {
                return new RedisCache();
            }
        }
        public class Factory2 : CrossCuttingConcernsFactory
        {
            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }
            public override Caching CreateCaching()
            {
                return new MemCache();
            }
        }
        public class ProductManager
        {
            private CrossCuttingConcernsFactory _crossCuttingConcernFactory;
            private Logging _logging;
            private Caching _caching;
            public ProductManager (CrossCuttingConcernsFactory crossCuttingConcernsFactory)
            {
                _crossCuttingConcernFactory = crossCuttingConcernsFactory;
                _logging = _crossCuttingConcernFactory.CreateLogger();
                _caching = _crossCuttingConcernFactory.CreateCaching();
            }
            public void GetAll()
            {
                _logging.Log("Logged");
                _caching.Cache("Cached");

                Console.WriteLine("Products Listed!");
            }
        }
    }
}
