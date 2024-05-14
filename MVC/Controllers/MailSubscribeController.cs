using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFreamework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {                  
        SubscribeMailManager sm = new SubscribeMailManager(new EfMailDal());
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {

            sm.TAdd(p);
            return PartialView();
        }
    }
}