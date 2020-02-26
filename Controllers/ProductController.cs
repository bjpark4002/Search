using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Repository.ProductRepo;
using Database;
using System.Diagnostics;
using Repository.UserRepo;
using Itlize.Models;

namespace Itlize.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Products()
        {
            ProductRepo product = new ProductRepo(new Itlize_Project_1Entities());

            var t = product.GetAll();

            var x = t.GetEnumerator();

            List<Product> products = new List<Product>();

            while (x.MoveNext())
            {
                Debug.WriteLine(x.Current.Product_ID + "," + x.Current.Manufacturer_ID + "," + x.Current.Product_Name + "," + x.Current.Product_Image + "," + x.Current.Series + "," + x.Current.Model + "," + x.Current.Model_Year + "," + x.Current.Series_Info + "," + x.Current.Featured);

                products.Add(new Product()
                {
                    Product_ID = x.Current.Product_ID,
                    Product_Name = x.Current.Product_Name,
                    Series = x.Current.Series,
                    Model = x.Current.Model,
                    Model_Year = x.Current.Model_Year,
                    Series_Info = x.Current.Series_Info,
                    Featured = x.Current.Featured
                });


            }
            
            return View(products.ToList());
        }

        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult ProductsCompare()
        {
            return View();
        }

    }
}