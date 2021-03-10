using System;
using System.Collections.Generic;
using System.Diagnostics;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new EfProductDal());

            //var stopwatch = new Stopwatch();
            //stopwatch.Start();

            ////var addResult = productManager.Add(new Product
            ////    {ProductName = "Obj-257", CategoryId = 3, UnitPrice = 500000, UnitsInStock = 2});

            //var deleteResult = productManager.Delete(new Product {ProductId = 83});

            //stopwatch.Stop();

            ////Console.WriteLine(addResult.Message+"/"+addResult.Success);
            //Console.WriteLine(deleteResult.Message+"/"+deleteResult.Success);

            //Console.WriteLine("\n" + (int)stopwatch.Elapsed.TotalMilliseconds + "ms");
        }
    }
}
