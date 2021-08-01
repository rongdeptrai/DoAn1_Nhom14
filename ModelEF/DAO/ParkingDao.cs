using ModelEF.ModelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ParkingDao
    {
        private MyParkingContext db;
        public ParkingDao()
        {
            db = new MyParkingContext();

        }
       
        public string Insert(DatCho entityPark)
        {
            db.DatChoes.Add(entityPark);
            db.SaveChanges();
            return entityPark.MaODo;
        }
        public List<ODo> Search()
        {
            var d = db.ODoes.Where(x => x.TrangThai.Contains("0") ).ToList();
                     return d;
        }

        public KhachHang Find(string username)

        {
            var d = db.KhachHangs.Find(username);
            return d;
        }
        public string Update(string entityCus)
        {
            var cus = Find(entityCus);
                if (!string.IsNullOrEmpty(cus.MaKH = entityCus))
                {
                  
                    cus.MaLKH ="MLKH02";
                }

      
            db.SaveChanges();
            return entityCus;
        }
        public bool Delete(string username)
        {
            try
            {
                var cus = db.KhachHangs.Find(username);
                db.KhachHangs.Remove(cus);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ChangeStatus(int id)
        {
            var cus = db.DatChoes.Single(u => u.IdDatCho == id);
            var a = cus.TrangThaiVaoBai;
            cus.TrangThaiVaoBai = !cus.TrangThaiVaoBai;
            db.SaveChanges();
            return cus.TrangThaiVaoBai;
        }
        public string ChangeStatusODo(int id)
        {
            var cus = db.ODoes.Single(u => u.IdODo == id);
            var a = cus.TrangThai;
            cus.TrangThai = "0";
            db.SaveChanges();
            return cus.TrangThai;
        }

    }
}
