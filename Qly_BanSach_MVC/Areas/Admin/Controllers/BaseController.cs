using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_BanSach_MVC.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // Set thông báo
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMesssage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}