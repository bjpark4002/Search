using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database;

namespace Itlize.Controllers
{
    public class SearchController : Controller
    {
       
        //GET: Search


        [HttpPost]
        public JsonResult AutoComplete(string prefix, string filterId)
        {

            Itlize_Project_1Entities db = new Itlize_Project_1Entities();
            List<tblSubCategories> filteredSubCategoryList;
            if(filterId == "Category")
            {
                
                filteredSubCategoryList = db.tblSubCategories.ToList();

            }
            else
            {

                filteredSubCategoryList = db.tblSubCategories.Where(x => x.Category_ID == filterId).ToList();
            }



            Itlize_Project_1Entities entities = new Itlize_Project_1Entities();
            var suggestions = (from suggestion in filteredSubCategoryList
                               where suggestion.SubCategory_Name.StartsWith(prefix)
                               select new
                               {
                                   label = suggestion.SubCategory_Name,
                                   val = suggestion.SubCategory_ID
                               }).ToList();
            return Json(suggestions);

        }
        [HttpPost]
        public ActionResult Index(string subName, string subId)
        {
            ViewBag.Message = subName + " , " + subId;
            return View();
        }


        public ActionResult SearchPage()
        {

            //ViewBag.CategoryList = new SelectList(GetTblCategoriesList(), "Category_ID", "Category_Name");
            ViewBag.CategoryList = GetTblCategoriesList();
            ViewBag.SubCategoryList = GetTblSubCategoriesList();
            ViewData["tmpVar"] = "0";
            return View();
        }

        public ActionResult FindResult(string CategoryId, string SubCategoryId)
        {
            ViewData["CategoryId"] = CategoryId;
            ViewData["SubCategoryId"] = SubCategoryId;

            //return RedirectToAction("Products", "Product");
            return View("../Product/Products");

        }

        public List<tblCategories> GetTblCategoriesList()
        {
            Itlize_Project_1Entities db = new Itlize_Project_1Entities();
            List<tblCategories> categories = db.tblCategories.ToList();
            return categories;
        }
        public List<tblSubCategories> GetTblSubCategoriesList()
        {
            Itlize_Project_1Entities db = new Itlize_Project_1Entities();
            List<tblSubCategories> subcategories = db.tblSubCategories.ToList();
            return subcategories;
        }
        public ActionResult GetFilteredSubCategories(string categoryId)
        {
            Itlize_Project_1Entities db = new Itlize_Project_1Entities();
            //int num = Int32.Parse(categoryId);
            List<tblSubCategories> filteredSubCategoryList;
 
            filteredSubCategoryList = db.tblSubCategories.Where(x => x.Category_ID == categoryId).ToList();

            ViewBag.SubOptions = new SelectList(filteredSubCategoryList, "SubCategory_ID", "SubCategory_Name");
            return PartialView("SubOptionPartial");
        }




    }
}