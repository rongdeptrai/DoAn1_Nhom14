using ModelEF.ModelDb;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CustomerDao
    {
        private MyParkingContext db;
        public CustomerDao()
        {
            db = new MyParkingContext();

        }
        public int login(string user, string pass)
        {
            var rs = db.KhachHangs.SingleOrDefault(x => x.MaKH.Contains(user) && x.MatKhau.Contains(pass));
            if (rs == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public string Insert(KhachHang entityCus)
        {
            db.KhachHangs.Add(entityCus);
            db.SaveChanges();
            return entityCus.TenKH;
        }
        public int Search( string email, string sdt)
        {
            var d = db.KhachHangs.Where(x => x.Email.Contains(email) || x.SoDienThoai.Contains(sdt)).ToList();
            var c = d.Count();
            return c;
        }
        public KhachHang Find(string username)
            
        {
            var d= db.KhachHangs.Find(username);
            return d;
        }
        public List<KhachHang> ListAll()
        {
            return db.KhachHangs.ToList();
        }
        public IEnumerable<KhachHang> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<KhachHang> model = db.KhachHangs;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.TenKH.Contains(keysearch));
            }

            return model.OrderBy(x => x.TenKH).ToPagedList(page, pagesize);
        }
        public string Update(KhachHang entityCus)
        {
            var cus = Find(entityCus.MaKH);
            if (cus == null)
            {
                db.KhachHangs.Add(entityCus);
            }
            else
            {
                cus.MaKH = entityCus.MaKH;
                if (!string.IsNullOrEmpty(entityCus.MatKhau))
                {
                    cus.MatKhau = entityCus.MatKhau;
                }
              
            }
            db.SaveChanges();
            return entityCus.MaKH;
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

    }
}
