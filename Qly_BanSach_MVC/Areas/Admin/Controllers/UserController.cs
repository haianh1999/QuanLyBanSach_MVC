using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString , int page = 1 , int pageSize = 10)
        {
            var model = new UserDAO().ListAllPaing(searchString, page, pageSize);
            return View(model);
        }

        public ActionResult Edit(string username)
        {
            var model = new UserDAO().GetById(username);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDAO();
                var model = dao.GetById(user.UserName);
                if (model!=null)
                {
                    user.password = Common.Encryptor.MD5Hash(user.password);
                    var res = dao.Edit(user);
                    if (res==true)
                    {
                        SetAlert("Sửa thành công", "success");
                    }    
                    else
                    {
                        SetAlert("Sửa không thành công", "success");
                    }
                }    
            }    
            return RedirectToAction("Index","User");
        }
    }
}