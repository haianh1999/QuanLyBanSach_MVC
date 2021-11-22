using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Qly_BanSach_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Thêm giỏ hàng
            routes.MapRoute(
                    name: "Add Cart",
                    url: "them-gio-hang",
                    defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                    namespaces: new[] { "Qly_BanSach_MVC.Controllers" }
                );
            //Xem giỏ hàng
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Qly_BanSach_MVC.Controllers" }
           );
            //Xem sản phẩm theo id
            routes.MapRoute(
                name: "SanPham",
                url: "san-pham/{metatitle}-{Ma}",
                defaults: new { controller = "TheLoai", action = "Sach", id = UrlParameter.Optional },
                namespaces: new[] { "Qly_BanSach_MVC.Controllers" }
            );
            //Xem nội dung sản phẩm
            routes.MapRoute(
                name: "Sach Detail",
                url: "chi-tiet/{metatitle}-{Ma}",
                defaults: new { controller = "Sach", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Qly_BanSach_MVC.Controllers" }
            );
        
            // Thanh toán
            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new[] { "Qly_BanSach_MVC.Controllers" }
              );
        }
    }
}
