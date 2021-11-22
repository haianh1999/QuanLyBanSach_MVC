using Model.DAO;
using Model.EF;
using Qly_BanSach_MVC.Common;
using Qly_BanSach_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult DangKy(User user)
        {
            if (ModelState.IsValid)
            {
                var model = new UserDAO().GetById(user.UserName);
                if (model==null )
                {
                    user.password = Common.Encryptor.MD5Hash(user.password);
                    user.NgayTao = DateTime.Now;
                    user.PhanQuyen = 2;
                    var res = new UserDAO().Insert(user);
                    if (res==true)
                    {
                        return RedirectToAction("Login", "User");
                    }    
                }    
            }
            else
            {
                ModelState.AddModelError("", "Đăng ký không thành công");
            }

            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            Session[Common.CommonConstants.USER_SESSION] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (res == 2)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.Hoten = user.HoTen;
                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    return Redirect("/");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
          
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng !");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

    }
}