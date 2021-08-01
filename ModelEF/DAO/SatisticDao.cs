using ModelEF.ModelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class SatisticDao
    {
        MyParkingContext db;
        public SatisticDao()
        {
            db = new MyParkingContext();

        }

   
        public List<HoaDon> ListAll()
        {
            return db.HoaDons.ThenByDescending(p => p.TongTien).ToList();
        }
    }
}
