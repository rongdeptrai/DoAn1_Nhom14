using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelEF.ModelDb;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ModelEF.DAO
{
    public class KhachHangDao
    {
        private Model2 db = new Model2();

        public List<KhachHang> getList()
        {
            var list = db.KhachHangs.ToList();
            return list;
        }
        public KhachHang getCount(int? id)
        {
            var row = db.KhachHangs.Find(id);
            return row;
        }

        public KhachHang getRow(string id)
        {
            var row = db.KhachHangs.Where(m => m.SoDienThoai == id).FirstOrDefault();
            return row;

        }
        public void Insert(KhachHang row)
        {
            db.KhachHangs.Add(row);
            db.SaveChanges();

        }
        public void Update(KhachHang row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void Delete(KhachHang row)
        {
            db.KhachHangs.Remove(row);
            db.SaveChanges();

        }
    }
}
