﻿using DataAccesLayer.Concrete;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ChartController : Controller
    {
        // GET: Char
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeResult()
        {
            return Json(catgorylist(),(JsonRequestBehavior.AllowGet));
        }
        public List<Class1> catgorylist()
        {
            List<Class1> c = new List<Class1>();
            c.Add(new Class1()
            {
                CategoryName = "Teknoloji",
                BlogCount = 14
                
            });
            c.Add(new Class1()
            {
                CategoryName = "Spor",
                BlogCount = 10

            });
            c.Add(new Class1()
            {
                CategoryName = "Kitap",
                BlogCount = 16

            });
            return c;
        }

        public ActionResult VisualizeResult2()
        {
            return Json(BlogList(), (JsonRequestBehavior.AllowGet));
        }

        public List<Class2>BlogList()
        {
            List<Class2> cs2 = new List<Class2>();
            using(var c= new Context())
            {
                cs2 = c.Blogs.Select(x=>new Class2()
                {
                 BlogName = x.BlogTitle,
                 Raintg = x.BlogRaiting
                }).ToList();  
            }
            return cs2;
        }
        public ActionResult Chart1()
        {
            return View();
        }
        public ActionResult Chart2()
        {
            return View();
        }
        public ActionResult Chart3()
        {
            return View();
        }
    }

}