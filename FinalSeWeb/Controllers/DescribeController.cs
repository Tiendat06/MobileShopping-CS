using FinalSeWeb.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalSeWeb.Controllers
{
    public class DescribeController : Controller
    {
        FINAL_SEEntities db = new FINAL_SEEntities();
        // GET: Describe
        public ActionResult Describe()
        {
            var myValue = Request.QueryString["pID"];

            Session["product_ID"] = myValue;
            

            MOBILE_PRODUCT mobilePro = db.MOBILE_PRODUCT.FirstOrDefault(x => x.Product_ID == myValue);
            return View(mobilePro);
        }


        

    }
}