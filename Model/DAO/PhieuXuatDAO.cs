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
        // Hàm tự động thêm mới  mã sach
        public string GetMaxPX()
        {
            // lấy ra mã sách lớn nhất
            var max = db_.PhieuXuats.Max(t => t.MaPX);
            if (max == null)
            {
                return "PX00000001";
            }
            var num = int.Parse(max.Substring(2)) + 1;
            max = "PX";
            // vòng lặp + chuỗi nếu đọ dài của max + với độ dài của num < 10 thì + thêm số 0
            while (max.Length + num.ToString().Length < 10)
            {
                max += "0";
            }
            max += num;
            return max;
        }
        public PhieuXuat GetById(string MaPX)
        {
            return db_.PhieuXuats.Where(x => x.MaPX.Equals(MaPX)).SingleOrDefault();
        }

        public bool Insert(PhieuXuat phieuXuat)
        {
            try
            {
                var dao = GetById(phieuXuat.MaPX);
                if (dao == null)
                {
                    db_.PhieuXuats.Add(phieuXuat);
                    db_.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
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
