using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new NewCustomerBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.ReadLine();

        }
        class ProductViewModel
        {
            public int id { get; set; }
            public string CategoryName { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal DiscountedPrice { get; set; }
            public bool DiscountApplied { get; set; }
        }
        abstract class ProductBuilder
        {
            public abstract void GetProductData();
            public abstract void ApplyDiscount();
            public abstract ProductViewModel GetModel();
        }
        class NewCustomerBuilder : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();
            public override void GetProductData()
            {
                model.id = 1;
                model.CategoryName = "Beverages";
                model.ProductName = "Chai";
                model.UnitPrice = 20;
            }
            public override void ApplyDiscount()
            {
                model.DiscountedPrice = model.UnitPrice*(decimal)0.90;
                model.DiscountApplied = true;
            }
            public override ProductViewModel GetModel()
            {
                return model;
            }
        }

        class OldCustomerBuilder : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();
            public override void GetProductData()
            {
                model.id = 1;
                model.CategoryName = "Beverages";
                model.ProductName = "Chai";
                model.UnitPrice = 20;
            }
            public override void ApplyDiscount()
            {
                model.DiscountedPrice = model.UnitPrice;
                model.DiscountApplied = false;
            }
            public override ProductViewModel GetModel()
            {
                return model;
            }
        }

        class ProductDirector
        {
            public void GenerateProduct(ProductBuilder productBuilder)
            {
                productBuilder.GetProductData();
                productBuilder.ApplyDiscount();
            }
        }





    }
}
