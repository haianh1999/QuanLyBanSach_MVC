using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(string  Ma)
        {
            var sach = new SachDAO().ViewDetail(Ma);
            ViewBag.Sach = new TheLoaiDAO().ViewDetail(sach.MaTL);
            return View(sach);
        }
    }
}