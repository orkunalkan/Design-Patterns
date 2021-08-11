using Ninject;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            Console.ReadLine();
        }
    }
    interface IProductDal
    {
        void Save();
    }
    class EfProductDal:IProductDal
    {
        
        public void Save()
        {
            Console.WriteLine("Saved witf Ef");
        }
    }
    class NhProductDal:IProductDal
    {
        
        public void Save()
        {
            Console.WriteLine("Saved witf Nh");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            _productDal.Save();
        }
    }
}
