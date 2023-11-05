using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnlines_Lab_3.Models;


namespace SachOnline_Lab_3.Controllers
{
    
    public class SachOnlineController : Controller
    {
       
        // GET: SachOnline
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChuDePartial()
        {
            return PartialView();
        }

        public ActionResult NXBPartial()
        {
            return PartialView();
        }

        public ActionResult SliderPartial()
        {
            return PartialView();
        }

    }
}