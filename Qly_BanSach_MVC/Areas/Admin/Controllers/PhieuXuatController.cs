using Model.DAO;
using Qly_BanSach_MVC.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Areas.Admin.Controllers
{
    public class PhieuXuatController : BaseController
    {
        // GET: Admin/PhieuXuat
        public ActionResult Index(string searchString , int page = 1 , int pageSize =10)
        {
            var model = new PhieuXuatDAO().ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        public ActionResult ViewCT(string MaPX)
        {
            
            if (MaPX != null)
            {
                var session = new PhieuXuatModel();
                session.MaPX = MaPX;
                Session[Common.CommonConstants.MaPXSession] = session;
            }
            else
            {
                if (MaPX == null)
                {
                    var mapxsession = (PhieuXuatModel)Session[Common.CommonConstants.MaPXSession];
                    MaPX = mapxsession.MaPX;
                }
            }
          
         
            var model = new CTPhieuXuatDAO().GetById(MaPX);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(string MaPX)
        {
            
            var model = new PhieuXuatDAO().GetById(MaPX);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecord(string MaPX)
        {
            var model = new PhieuXuatDAO().GetById(MaPX);
            if (model !=null)
            {
                var infoPhieuXuat = new CTPhieuXuatDAO().GetById(MaPX);
                var dao = new CTPhieuXuatDAO();
                foreach(var item in infoPhieuXuat)
                {
                    dao.Delete(item.MaPX, item.MaSach);
                }
                var res = new PhieuXuatDAO().Delete(MaPX);
                if (res ==true)
                {
                    SetAlert("Xóa thành công", "success");
                }    
                else
                {
                    SetAlert("Xóa không thành công", "error");
                }

            }
            return RedirectToAction("Index");
        }
    }
}