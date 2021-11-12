using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult TheLoaiCategories()
        {
            var model = new TheLoaiDAO().GetAll();
            return PartialView(model);
        }
    }
}