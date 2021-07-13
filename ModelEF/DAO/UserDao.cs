using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private LeHoangLongContext db;
        public UserDao()
        {
            db = new LeHoangLongContext();

        }
        public int login(string user, string pass)
        {
            var rs = db.Admins.SingleOrDefault(x => x.Username.Contains(user) && x.Password.Contains(pass));
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
