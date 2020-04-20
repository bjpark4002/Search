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
        public ActionResult Products(string CategoryId, string SubCategoryId, string initialPageLoader)
        {
            ProductRepo product = new ProductRepo(new Itlize_Project_1Entities());

            Itlize_Project_1Entities result = new Itlize_Project_1Entities();
            ViewData["CategoryId"] = CategoryId;
            ViewData["SubCategoryId"] = SubCategoryId;

            //-------------------------------------------------------------------------------------------
            //case 1 = when user select nothing 
            //(categoryid == category)
            //-------------------------------------------------------------------------------------------            //case 2 = when user only selct category
            //pass category id and output all in the category
            //-------------------------------------------------------------------------------------------
            //case 3 = when user only search 
            // pass product with its categoryid and show all products in the category
            //-------------------------------------------------------------------------------------------
            //case 4 = normal search
            // find products belong to these categoryid and subcategoryId
            //and make a list of it 
            // then pass to view in viewbag


            ViewData["initialPageLoader"] = initialPageLoader;

            List<Product> items;
            ViewBag.initialOutput = result.tblProducts.Where(x => x.SubCategory_ID == SubCategoryId).ToList();
            //this gets list of 



            return View();
        }

        public ActionResult SlidePartial()
        {
            return PartialView("SlidePartial");
        }
        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult ProductsCompare()
        {
            return View();
        }

        public ActionResult ProductResult(string Cate, string SubC, 

            string AirFlowAmount1, string AirFlowAmount2, 
            string MaxPowerAmount1, string MaxPowerAmount2,
            string MaxSoundAmount1, string MaxSoundAmount2,
            string FanAmount1, string FanAmount2,
            string HeightAmount1, string HeightAmount2,
            string FirmAmount1, string FirmAmount2,
            string GlobalAmount1, string GlobalAmount2
            )
        {

            IDictionary<string, int> dict = new Dictionary<string, int>();

            List<string> idList = new List<string>();
            Itlize_Project_1Entities result = new Itlize_Project_1Entities();
            List<Product> items;
            List<tblTechSpecFilters> after_Tech_Spec = result.tblTechSpecFilters.ToList();

            
            // filter airflow
            foreach( tblTechSpecFilters tem in result.tblTechSpecFilters)
            {
                Console.WriteLine(tem.Property_ID,tem.SubCategory_ID, tem.Min_Value, tem.Max_Value);
                //to do
                // Subc == tem.Category_ID
                // tblTechSpecFilters.Property_ID ==1 

                if (!dict.ContainsKey(tem.SubCategory_ID))
                {
                    dict[tem.SubCategory_ID] = 1;
                }
                else
                {
                    dict[tem.SubCategory_ID] += 1;
                }
            }

            //ViewBag.initialOutput = result.tblProducts.Where(x => x.SubCategory_ID == SubCategoryId).ToList();


            ViewBag.AirFlowAmount1 = AirFlowAmount1;
            ViewBag.AirFlowAmount2 = AirFlowAmount2;

            ViewBag.MaxPowerAmount1 = MaxPowerAmount1;
            ViewBag.MaxPowerAmount2 = MaxPowerAmount2;

            ViewBag.MaxSoundAmount1 = MaxSoundAmount1;
            ViewBag.MaxSoundAmount2 = MaxSoundAmount2;

            ViewBag.FanAmount1 = FanAmount1;
            ViewBag.FanAmount2 = FanAmount2;

            ViewBag.HeightAmount1 = HeightAmount1;
            ViewBag.HeightAmount2 = HeightAmount2;

            ViewBag.FirmAmount1 = FirmAmount1;
            ViewBag.FirmAmount2 = FirmAmount2;

            ViewBag.GlobalAmount1 = GlobalAmount1;
            ViewBag.GlobalAmount2 = GlobalAmount2;


            return PartialView("ProductResult");
        }




    }
}