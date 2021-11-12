using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qly_BanSach_MVC.Models
{
    [Serializable]
    public class CartItem
    {
        public Sach Sach { get; set; }
        public int quantity { get; set; }
    }
}