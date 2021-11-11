using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SachDAO : BaseDAO
    {
        // hàm trả về list sách và phân trang 
        public IEnumerable<Sach> ListAllPaging(string searchString , int page,int pageSize)
        {
            IQueryable<Sach> model = db_.Saches;
            // kiểm tra xem biến search có tồn tại hay ko 
            // nếu tồn tại thì chạy hàm if
            if (!string.IsNullOrEmpty(searchString))
            {
                // trả về thông tin theo mã sách hoặc tên sách hoặc tên thể loại
                model = model.Where(x => x.MaSach.Equals(searchString) || x.TenSach.Equals(searchString) || x.TheLoai.TenTL.Equals(searchString));
            }
            // nếu search rỗng thì trả về danh sách sắp xếp giảm dần theo ngày thêm
            return model.OrderByDescending(x => x.NgayThem).ToPagedList(page, pageSize);
        }

        // Hàm lấy thông tin sách theo mã sách 
        public Sach GetById(string MaSach)
        {
            return db_.Saches.Find(MaSach);
        }
        // Hàm lấy thông tin sách theo mã sách 
        public Sach ViewDetail(string MaSach)
        {
            db_.Configuration.ProxyCreationEnabled = false;
            return db_.Saches.Find(MaSach);
        }
        // Hàm tự động thêm mới  mã sach
        public string GetMaxMaSach()
        {
            // lấy ra mã sách lớn nhất
            var max = db_.Saches.Max(t => t.MaSach);
            if (max == null)
            {
                return "S000000001";
            }
            var num = int.Parse(max.Substring(2)) + 1;
            max = "S";
            // vòng lặp + chuỗi nếu đọ dài của max + với độ dài của num < 10 thì + thêm số 0
            while (max.Length + num.ToString().Length < 10)
            {
                max += "0";
            }
            max += num;
            return max;
        }
        // Hàm thêm bản ghi vào database 
        public bool Insert(Sach sach)
        {
            try
            {
                var dao = GetById(sach.MaSach);
                // nếu chưa có sách thì mới thực hiện thêm mới
                if (dao==null)
                {
                    db_.Saches.Add(sach);
                    db_.SaveChanges();
                }    
            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }

        // Viết hàm Edit trả về kiểu bool
        public bool Edit(Sach sach)
        {
            try
            {
                var dao = GetById(sach.MaSach);
                if (dao!=null)
                {
                    dao.TenSach = sach.TenSach;
                    dao.Mieu_ta = sach.Mieu_ta;
                    dao.HinhAnh = sach.HinhAnh;
                    dao.GiaThanh = sach.GiaThanh;
                    dao.MaTL = sach.MaTL;
                    db_.SaveChanges();
                }    
            }
            catch (Exception)
            {

                return false;
            }
            return true;
          
            
        }

        // Viết hàm xóa 
        public bool Delete(string MaSach)
        {
            try
            {
                var dao = GetById(MaSach);
                if (dao!=null)
                {
                    db_.Saches.Remove(dao);
                    db_.SaveChanges();
                }    
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
