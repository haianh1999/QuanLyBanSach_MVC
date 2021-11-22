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

        [HttpGet]
        public ActionResult Sach(string Ma,int page =1 , int pageSize =10)
        {
            var theLoai = new TheLoaiDAO().ViewDetail(Ma);
            ViewBag.InfoTheLoai = theLoai;
            int totalRecord = 0;
            var model = new SachDAO().ListByCategoryId(Ma, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Pre = page - 1;
            return View(model);
        }
    }
}