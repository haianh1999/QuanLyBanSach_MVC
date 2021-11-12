using Model.DAO;
using Qly_BanSach_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var SachInfo = new SachDAO();
            ViewBag.NewBooks = SachInfo.ListNewBook(4);
            return View();
        }

        [ChildActionOnly]
        public ActionResult HearderCart()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
        [ChildActionOnly]
        public ActionResult Topmenu()
        {

          
            return PartialView();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}