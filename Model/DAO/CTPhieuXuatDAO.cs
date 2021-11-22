using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CTPhieuXuatDAO : BaseDAO
    {
        public List<CTPhieuXuat> GetById(string MaPX)
        {
            var dao = db_.CTPhieuXuats.Where(x => x.MaPX == MaPX).ToList();
            return dao;
        }

        public CTPhieuXuat GetInfo(string MaPx,string MaSach)
        {
            return db_.CTPhieuXuats.Where(x => x.MaPX.Equals(MaPx) && x.MaSach.Equals(MaSach)).SingleOrDefault();
        }
        public bool Insert(CTPhieuXuat cTPhieuXuat)
        {
            try
            {
                var dao = GetInfo(cTPhieuXuat.MaPX, cTPhieuXuat.MaSach);
                if (dao == null)
                {
                    db_.CTPhieuXuats.Add(cTPhieuXuat);
                    db_.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Edit(CTPhieuXuat cTPhieuXuat)
        {
            try
            {
                var dao = GetInfo(cTPhieuXuat.MaPX,cTPhieuXuat.MaSach);
                if (dao != null)
                {
                    dao.SoLuong = cTPhieuXuat.SoLuong;
                    dao.DonGia = cTPhieuXuat.DonGia;
                    db_.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(string MaPx,string MaSach)
        {
            try
            {
                var dao = GetInfo(MaPx, MaSach);
                if (dao != null)
                {
                    db_.CTPhieuXuats.Remove(dao);
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
