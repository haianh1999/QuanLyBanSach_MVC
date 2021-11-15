using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qly_BanSach_MVC.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }

    }

}
