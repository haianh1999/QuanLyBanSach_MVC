using Model.DAO;
using Model.EF;
using Qly_BanSach_MVC.Common;
using Qly_BanSach_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Qly_BanSach_MVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(string MaSach, int quantity)
        {
            var product = new SachDAO().ViewDetail(MaSach);
            var cart = Session[Common.CommonConstants.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Sach.MaSach == MaSach))
                {
                    foreach (var item in list)
                    {
                        if (item.Sach.MaSach == MaSach)
                        {
                            item.quantity += quantity;
                        }

                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Sach = product;
                    item.quantity = quantity;
                    list.Add(item);
                }
                Session[Common.CommonConstants.CartSession] = list;

            }
            else
            {
                // tạo mới đối tượng
                var item = new CartItem();
                item.Sach = product;
                item.quantity = quantity;

                var list = new List<CartItem>();
                list.Add(item);
                // gán vào session
                Session[Common.CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[Common.CommonConstants.CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Sach.MaSach == item.Sach.MaSach);
                if (jsonItem != null)
                {
                    item.quantity = jsonItem.quantity;
                }

            }
            Session[Common.CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }


        public JsonResult Delete(string MaSach)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            sessionCart.RemoveAll(x => x.Sach.MaSach == MaSach);
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Payment(PhieuXuat phieuXuat)
        {
            var loginSession = Session[Common.CommonConstants.USER_SESSION];
            if (loginSession==null)
            {
                return RedirectToAction("Login", "User");
            }    
            else
            {
                var userSession = (UserLogin)Session[CommonConstants.USER_SESSION];
                var dao = new PhieuXuatDAO();
                var ctdao = new CTPhieuXuatDAO();
                var check = dao.GetById(phieuXuat.MaPX);
                if (check==null)
                {
                    phieuXuat.MaPX = dao.GetMaxPX();
                    phieuXuat.UserName = userSession.UserName;
                    phieuXuat.NgayTao = DateTime.Now;
                    var res = dao.Insert(phieuXuat);
                    if (res==true)
                    {
                        var cart = Session[Common.CommonConstants.CartSession];
                        var list = new List<CartItem>();
                        if (cart != null)
                        {
                            list = (List<CartItem>)cart;
                        }
                        foreach (var item in list)
                        {
                            CTPhieuXuat cTPhieu = new CTPhieuXuat();
                            cTPhieu.MaPX = phieuXuat.MaPX;
                            cTPhieu.MaSach = item.Sach.MaSach;
                            cTPhieu.SoLuong = item.quantity;
                            cTPhieu.DonGia = item.Sach.GiaThanh * item.quantity;
                            var resCT = ctdao.Insert(cTPhieu);
                        }    
                        
                    }
                    Session[Common.CommonConstants.CartSession] = null;
                    return RedirectToAction("Success", "Cart");
                }    
            }
            return View("Index");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}