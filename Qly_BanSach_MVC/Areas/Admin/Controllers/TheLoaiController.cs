using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Areas.Admin.Controllers
{
    // kế thừa các thuộc tính từ lớp basecontroller
    public class TheLoaiController : BaseController
    {
        // GET: Admin/TheLoai
        // tạo hàm index trả về view 
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            // tạo biến model trả về 1 list danh sách thể loại 
            var model = new TheLoaiDAO().ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        // Tạo hàm trả về view tạo mới bản ghi
        [HttpGet]
        public ActionResult Create()
        {
            // trả về view create
            return View();
        }

        // Tạo hàm thêm mới có phương thức là post
        [HttpPost]
        public ActionResult Create(TheLoai theLoai)
        {
            try
            {
                var dao = new TheLoaiDAO();
                if (ModelState.IsValid)
                {

                    // tạo biến check xem thể loại đã tồn tại hay chưa
                    var check = dao.GetById(theLoai.MaTL);
                    if (check == null)
                    {
                        // tạo biến matl = mã thể loại mới được tạo từ hàm GetMaxMaTheLoai
                        var matl = dao.GetMaxMaTheLoai();
                        theLoai.MaTL = matl;
                        // tạo biến res kiểm tra xem Insert trả về true hay false
                        var res = dao.Insert(theLoai);
                        // nếu true thì set thông báo thành công
                        if (res == true)
                        {
                            SetAlert("Thêm mới thành công", "success");
                            return RedirectToAction("Index", "TheLoai");
                        }
                    }

                }
                else
                {
                    // ngc lại k thành công
                    SetAlert("Thêm không thành công", "error");
                    ModelState.AddModelError("", "Thêm không thành công");
                }
                // trả về lỗi
                return View(theLoai);
            }
            catch (Exception)
            {

                return View();
            }
        
        }

        // Tạo hàm trả về view Edit
        [HttpGet]
        public ActionResult Edit(string MaTL)
        {
            var model = new TheLoaiDAO().ViewDetail(MaTL);
            return View(model);
        }

        // tạo hàm submit Edit
        [HttpPost]
        public ActionResult Edit(TheLoai theloai)
        {
            // kiểm tra xem có validate không 
            // nếu validate thì trả về lỗi 
            // nếu không thì thực hiện hàm if
            if (ModelState.IsValid)
            {
                var dao = new TheLoaiDAO();
                // kiểm tra xem có tồn tại thể loại để sửa hay không
                var model = dao.GetById(theloai.MaTL);
                if (model != null)
                {
                    // trả về kiểu bool nếu sửa thành công
                    var res = dao.Edit(theloai);
                    if (res == true)
                    {
                        SetAlert("Sửa thành công", "success");
                        return RedirectToAction("Index", "TheLoai");
                    }

                }
            }              
            else
            {
                SetAlert("Sửa không thành công", "error");
                ModelState.AddModelError("", "Sửa không thành công");
            }
            return View(theloai);
        }

        // tạo hàm view ra thông tin thể loại cần xóa
        [HttpGet]
        public ActionResult Delete(string MaTL)
        {
            var model = new TheLoaiDAO().ViewDetail(MaTL);
            return View(model);
        }

        //Tạo hàm xóa bản ghi trong database có phương thức là post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecord(string MaTL)
        {
            var dao = new TheLoaiDAO();
            var model = dao.ViewDetail(MaTL);
            if (model!=null)
            {
                var res = dao.Delete(MaTL);
                if (res==true)
                {
                    SetAlert("Xóa thành công", "success");
                    return RedirectToAction("Index", "TheLoai");
                }
                else
                {
                    SetAlert("Xóa không thành công", "error");
                }
            }
            return View(dao.ListAllPaging(null, 1, 5));
        }
    }
}