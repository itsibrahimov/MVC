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
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        AuthorManager authormanager = new AuthorManager(new EfAuthorDal());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetails = blogmanager.GetBlogByID(id);
            return PartialView(authordetails);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetList().Where(x=>x.BlogID == id).Select(y=>y.AuthorID).FirstOrDefault();

            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }



        public ActionResult AuthorList() 
        { 
            var authorlists = authormanager.GetList();
            return View(authorlists); 
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {

            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(p);
            if (result.IsValid)
            {
            authormanager.AuthorAdd(p);
            return RedirectToAction("AuthorList");
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
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.GetByID(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(p);
            if (result.IsValid)
            {
                authormanager.AuthorUpdate(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            authormanager.AuthorUpdate(p);
            return RedirectToAction("AuthorList");
        }
    }
}