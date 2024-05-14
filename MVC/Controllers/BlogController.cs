using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFreamework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        CommentManager cm = new CommentManager(new EfCommentDal());
        BlogManager bm = new BlogManager(new EfBlogDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {


            var bloglist = bm.GetList().ToPagedList(page,6);

            return PartialView(bloglist);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1.Post
            var posttitle1 = bm.GetList().OrderByDescending(z =>z.BlogID).Where(x=>x.CategoryID== 1).Select(y =>y.BlogTitle).FirstOrDefault();

            var postimage1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTime).FirstOrDefault();

            var blogtime1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTime).FirstOrDefault();
            var blogpostid1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogtime1 = blogtime1;
            ViewBag.blogpostid1 = blogpostid1;

            //2.Post
            var posttitle2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTime).FirstOrDefault();

            var blogtime2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTime).FirstOrDefault();
            var blogpostid2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogtime2 = blogtime2;
            ViewBag.blogpostid2 = blogpostid2;

            //3.Post
            var posttitle3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTime).FirstOrDefault();

            var blogtime3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTime).FirstOrDefault();
            var blogpostid3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogtime3 = blogtime3;
            ViewBag.blogpostid3 = blogpostid3;

            //4.Post
            var posttitle4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTime).FirstOrDefault();

            var blogtime4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTime).FirstOrDefault();
            var blogpostid4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogtime4 = blogtime4;
            ViewBag.blogpostid4 = blogpostid4;

            //5.Post
            var posttitle5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTime).FirstOrDefault();

            var blogtime5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTime).FirstOrDefault();
            var blogpostid5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.blogtime5 = blogtime5;
            ViewBag.blogpostid5 = blogpostid5;
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails()
        {

            return View();
        }


        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }


        [AllowAnonymous]
        public ActionResult BlogByCategory(int id) 
        { 
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(y=>y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;

            var CategoryDesc = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            return View(BlogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetList();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetList();
            return View(bloglist);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b) 
        {
            bm.BlogAdd(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            bm.BlogDelete(blog);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.BlogUpdate(p);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog (int id)
        {
            
            var commentlist = cm.CommentByBlog(id);
            return View(commentlist);
        }
        public ActionResult AuthorBlogList(int id)
        {

            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }
    }
}