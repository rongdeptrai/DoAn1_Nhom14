using ModelEF.ModelDb;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class InvoiceDao
    {
        private MyParkingContext db;
        public  InvoiceDao
()
        {
            db = new MyParkingContext();

        }
       
        
        public HoaDon Find(string username)

        {
            var d = db.HoaDons.Find(username);
            return d;
        }
        public List<HoaDon> ListAll()
        {
            return db.HoaDons.ToList();
        }
        public IEnumerable<HoaDon> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<HoaDon> model = db.HoaDons;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.TenKH.Contains(keysearch));
            }

            return model.OrderBy(x => x.TenKH).ToPagedList(page, pagesize);
        }
        public string Insert(HoaDon entityPark)
        {
            db.HoaDons.Add(entityPark);
            db.SaveChanges();
            return entityPark.MaHD;
        }
    }
}
