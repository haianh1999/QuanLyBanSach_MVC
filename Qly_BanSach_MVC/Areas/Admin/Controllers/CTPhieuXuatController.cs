using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Areas.Admin.Controllers
{
    public class CTPhieuXuatController : BaseController
    {
        // GET: Admin/CTPhieuXuat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(string MaPX, string MaSach)
        {
            var model = new CTPhieuXuatDAO().GetInfo(MaPX, MaSach);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CTPhieuXuat cTPhieu)
        {
            var model = new CTPhieuXuatDAO().GetInfo(cTPhieu.MaPX,cTPhieu.MaSach);
            var sach = new SachDAO().GetById(cTPhieu.MaSach);

            if (model!=null)
            {
                cTPhieu.DonGia = sach.GiaThanh * cTPhieu.SoLuong;
                var res = new CTPhieuXuatDAO().Edit(cTPhieu);
                if (res == true)
                {
                    SetAlert("Xóa thành công", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công", "error");

                }
            }
            return RedirectToAction("ViewCT", "PhieuXuat");
        }

        public ActionResult Delete(string MaPX, string MaSach)
        {
            var model = new CTPhieuXuatDAO().GetInfo(MaPX, MaSach);
            return View(model);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecord(string MaPX, string MaSach)
        {
            var model = new CTPhieuXuatDAO().GetInfo(MaPX, MaSach);
            if (model!=null)
            {
                var res = new CTPhieuXuatDAO().Delete(MaPX, MaSach);
                if (res==true)
                {
                    SetAlert("Xóa thành công", "success");
                }    
                else
                {
                    SetAlert("Xóa không thành công", "error");

                }
            }
            return RedirectToAction("ViewCT", "PhieuXuat");
        }
    }
}