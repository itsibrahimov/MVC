using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFreamework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryvalues = cm.GettAll();
            return View(categoryvalues);
        }

        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryvalues = cm.GettAll();
            return PartialView(categoryvalues);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GettAll();
            return View(categorylist);
        }
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                 cm.CategoryAdd(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = cm.GetByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
            cm.CategoryUpdate(p);
            return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public ActionResult CategoryDelete(int id)
        {
            cm.CategoryStatusFalseBl(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryStatusTrue(int id)
        {
            cm.CategoryStatusTrueBl(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}