using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Areas.Admin.Controllers
{
    public class SachController : BaseController
    {
        // GET: Admin/Sach
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            // tạo biến model trả về 1 list danh sách thể loại và phân trang
            var model = new SachDAO().ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        // Tạo hàm trả về view thêm sách
        [HttpGet]
        public ActionResult Create()
        {
            // tao mới sach model 
            Sach sach = new Sach();
            // gán thuộc tính list TheloaiCollection = danh sách thể loại
            sach.TheLoaiCollection = new TheLoaiDAO().GetAll();

            //trả về view sach
            return View(sach);
        }
        //Tao hàm upload file
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/assets/images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View("Index", "Home");
        }
        // tạo hàm  lưu bản ghi vào database
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Sach sach)
        {
            try
            {


                var dao = new SachDAO();

                var check = dao.GetById(sach.MaSach);
                if (check == null)
                {
                    // tạo biến file name lấy tên file đã chọn
                    string filename = Path.GetFileName(file.FileName);
                    // tạo biến mới _filename
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    // lấy đuôi của file
                    string extension = Path.GetExtension(file.FileName);
                    // tạo ra đường dẫn hình ảnh mới vào thư mục assets/images
                    string path = Path.Combine(Server.MapPath("~/assets/images/"), _filename);
                    // lưu đường dẫn vào trong database
                    sach.HinhAnh = "~/assets/images/" + _filename;
                    // lưu hình ảnh vào thư mục assets/images
                    file.SaveAs(path);
                    sach.MaSach = dao.GetMaxMaSach();
                    sach.NgayThem = DateTime.Now;
                    var res = dao.Insert(sach);
                    if (res == true)
                    {
                        SetAlert("Thêm sách thành công", "success");
                        RedirectToAction("Index", "Sach");
                    }

                }

                else
                {
                    SetAlert("Thêm không thành công", "error");
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }

        }

        // Viết hàm trả về view edit
        [HttpGet]
        public ActionResult Edit(string MaSach)
        {
            // tao mới sach model 
            var dao = new TheLoaiDAO().GetAll();
            ViewBag.InfoTheLoai = new SelectList(dao, "MaTL", "TenTL");
            var model = new SachDAO().ViewDetail(MaSach);
            return View(model);
        }
        // Viết hàm Edit bản ghi
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase fileEdit, Sach sach)
        {
            try
            {


                var dao = new SachDAO();

                var check = dao.GetById(sach.MaSach);
                if (check != null)
                {
                
                   
                    if (fileEdit == null)
                    {
                        var res = dao.Edit(sach);
                        if (res == true)
                        {
                            SetAlert("Sửa sách thành công", "success");
                            RedirectToAction("Index", "Sach");
                        }
                    }
                    else
                    {
                        // tạo biến file name lấy tên file đã chọn
                        string filename = Path.GetFileName(fileEdit.FileName);
                        // tạo biến mới _filename
                        string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                        // lấy đuôi của file
                        string extension = Path.GetExtension(fileEdit.FileName);
                        // tạo ra đường dẫn hình ảnh mới vào thư mục assets/images
                        string path = Path.Combine(Server.MapPath("~/assets/images/"), _filename);
                        // lưu đường dẫn vào trong database
                        sach.HinhAnh = "~/assets/images/" + _filename;
                        // lưu hình ảnh vào thư mục assets/images
                        fileEdit.SaveAs(path);
                        var res = dao.Edit(sach);
                        if (res == true)
                        {
                            SetAlert("Sửa sách thành công", "success");
                            RedirectToAction("Index", "Sach");
                        }
                    }


                }

                else
                {
                    SetAlert("Sửa không thành công", "error");
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }

        }

        // Hàm trả về view xóa sách
        [HttpGet]
        public ActionResult Delete(string MaSach)
        {
            var model = new SachDAO().GetById(MaSach);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecord(string MaSach)
        {
            var dao = new SachDAO();
            var model = dao.GetById(MaSach);
            if (model != null)
            {
                var res = dao.Delete(MaSach);
                if (res == true)
                {
                    SetAlert("Xóa thành công", "success");
                    return RedirectToAction("Index", "Sach");
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