using Model.DAO;
using Qly_BanSach_MVC.Areas.Admin.Models;
using Qly_BanSach_MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (res == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
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
            return View("Index");
        }

        public ActionResult LogOut()
        {
            Session[Common.CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index");
        }
    }
}