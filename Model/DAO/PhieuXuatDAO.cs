using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PhieuXuatDAO : BaseDAO
    {
        public IEnumerable<PhieuXuat> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<PhieuXuat> model = db_.PhieuXuats;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MaPX.Equals(searchString) || x.UserName.Equals(searchString));
            }
            return model.OrderByDescending(x => x.NgayTao).ToPagedList(page, pageSize);
        }

        public PhieuXuat GetById(string MaPX)
        {
            return db_.PhieuXuats.Where(x => x.MaPX.Equals(MaPX)).SingleOrDefault();
        }

        public bool Delete(string MaPX)
        {
            try
            {
                var dao = GetById(MaPX);
                if(dao!=null)
                {
                    db_.PhieuXuats.Remove(dao);
                    db_.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

    }

}
