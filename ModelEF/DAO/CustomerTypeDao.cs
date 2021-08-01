using ModelEF.ModelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CustomerTypeDao
    {
        private MyParkingContext db;
        public CustomerTypeDao()
        {
            db = new MyParkingContext();

        }

        public List<LoaiKhachHang> ListAll()
        {
            
            return db.LoaiKhachHangs.ToList();
        }
    }
}
