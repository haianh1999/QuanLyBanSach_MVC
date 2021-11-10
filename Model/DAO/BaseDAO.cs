using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BaseDAO
    {
        public QlBanSachDbcontext db_ = null;
        public BaseDAO()
        {
            db_ = new QlBanSachDbcontext();
        }
    }
}
