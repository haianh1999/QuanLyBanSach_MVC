using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserDAO : BaseDAO
    {
        public IEnumerable<User> ListAllPaing(string searchString , int page, int pageSize)
        {
            IQueryable<User> model = db_.Users;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Equals(searchString) || x.HoTen.Equals(searchString) || x.SDT.Equals(searchString));
            }
            return model.OrderByDescending(x => x.NgayTao).Where(x=>x.PhanQuyen==2).ToPagedList(page, pageSize);
        }

        public User GetById(string username)
        {
            return db_.Users.Where(x => x.UserName.Equals(username)).SingleOrDefault();
        }

        public bool Edit(User user)
        {
            try
            {
                var model = GetById(user.UserName);
                if (model != null)
                {
                    model.password = user.password;
                    model.HoTen = user.HoTen;
                    model.NgaySinh = user.NgaySinh;
                    model.DiaChi = user.DiaChi;
                    model.SDT = user.SDT;
                    db_.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false ;
            }
           
        }
        public bool Insert(User user)
        {
            try
            {
                var model = GetById(user.UserName);
                if (model == null)
                {
                    db_.Users.Add(user);
                    db_.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public int Login(string UserName, string PassWord)
        {
            var res = db_.Users.SingleOrDefault(x => x.UserName == UserName);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.password == PassWord && res.PhanQuyen == 1)
                {
                    return 1;

                }
                if (res.password == PassWord && res.PhanQuyen == 2)
                {
                    return 2;

                }
                else
                {
                    return -2;
                }
            }

        }
    }
}
