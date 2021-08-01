using ModelEF.ModelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class EmployeeDao
    {
        private MyParkingContext db;
        public EmployeeDao()
        {
            db = new MyParkingContext();

        }
        public int login(string user, string pass)
        {
            var rs = db.NhanViens.SingleOrDefault(x => x.MaNV.Contains(user) && x.MatKhau.Contains(pass));
            if (rs == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public int checkTypeEmp(string user)
        {
            var rs = db.NhanViens.SingleOrDefault(x=>x.MaNV.Contains(user) && x.MaCV.Equals("MCV001"));
            if (rs == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
