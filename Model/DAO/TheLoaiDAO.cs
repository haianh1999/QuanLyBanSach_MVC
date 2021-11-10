using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class TheLoaiDAO : BaseDAO
    {
        // ham trả về tất cả dữ liệu thể loại theo searchString , page , và pageSize
        public IEnumerable<TheLoai> ListAllPaging (string searchString , int page , int pageSize)
        {
            // tạo biến model
            IQueryable<TheLoai> model = db_.TheLoais;
            // kiểm tra nếu searchString khác null
            if(!string.IsNullOrEmpty(searchString))
            {
                // trả về  theo mã thể loại , hoặc tên thể loại
                model = model.Where(x => x.MaTL == searchString || x.TenTL == searchString);
            }
            // nếu searchString rỗng  thì trả về danh sách thể loại sắp xếp giảm dần theo mã thể loại
            return model.OrderByDescending(x => x.MaTL).ToPagedList(page, pageSize);
        }

        // hàm trả về thông tin thể loại theo mã thể loại
        public TheLoai GetById(string MaTL)
        {
            return db_.TheLoais.Where(x => x.MaTL == MaTL).SingleOrDefault();
        }
        // hàm trả về viewDetail
        public TheLoai ViewDetail(string MaTL)
        {
            return db_.TheLoais.Find(MaTL);
        }
        // Hàm tự động thêm mới  mã thể loại 
        public string GetMaxMaTheLoai()
        {
            // lấy ra mã thể loại lớn nhất
            var max = db_.TheLoais.Max(t => t.MaTL);
            if (max == null)
            {
                return "TL00000001";
            }
            var num = int.Parse(max.Substring(2)) + 1;
            max = "TL";
            // vòng lặp + chuỗi nếu đọ dài của max + với độ dài của num < 10 thì + thêm số 0
            while (max.Length + num.ToString().Length < 10)
            {
                max += "0";
            }
            max += num;
            return max;
        }

        // hàm thêm mới bản ghi có kiểu trả về là bool
        public bool Insert(TheLoai theloai)
        {
            try
            {
                // tạo biến dao lấy giá trị theo Mã thể loại
                var dao = GetById(theloai.MaTL);
                // nếu dao chưa có thì ms thêm vào data
                if (dao == null)
                {
                    db_.TheLoais.Add(theloai);
                    db_.SaveChanges();
                }
            }
            catch (Exception)
            {
                // nếu lỗi thì trả về false;
                return false;
            }
            // ngc lại trả về true
            return true;
          
        }

        // tạo hàm sửa bản ghi trả về bool
        public bool Edit(TheLoai theloai)
        {
            try
            {
                var dao = GetById(theloai.MaTL);
                if (dao!=null)
                {
                    dao.TenTL = theloai.TenTL;
                    dao.GhiChu = theloai.GhiChu;
                    db_.SaveChanges();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        // tạo hàm xóa bản ghi trả về kiểu bool
        public bool Delete(string MaTL)
        {
            try
            {
                // lấy giá trị thể loại theo mã thể loại
                var dao = GetById(MaTL);
                // nếu dao tồn tại thì ...
                if (dao!=null)
                {
                    // xóa dao ra khỏi database
                    db_.TheLoais.Remove(dao);
                    // lưu lại vào db
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
