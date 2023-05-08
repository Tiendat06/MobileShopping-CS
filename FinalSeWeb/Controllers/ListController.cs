using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalSeWeb.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult OrderList(string Quan)
        {
            ViewBag.Quantity = Quan;
            return View();
        }
    }
}