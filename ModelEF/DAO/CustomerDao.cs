using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CustomerDao
    {
        private LeHoangLongContext db;
        public CustomerDao()
        {
            db = new LeHoangLongContext();

        }
        public string Insert(UserAccount entityCus)
        {
            db.UserAccounts.Add(entityCus);
            db.SaveChanges();
            return entityCus.UserName;
        }
        public UserAccount Find(string username)
        {
            return db.UserAccounts.Find(username);
        }
        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }
        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }

            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
        public string Update(UserAccount entityCus)
        {
            var cus = Find(entityCus.UserName);
            if (cus == null)
            {
                db.UserAccounts.Add(entityCus);
            }
            else
            {
                cus.UserName = entityCus.UserName;
                if (!string.IsNullOrEmpty(entityCus.Password))
                {
                    cus.Password = entityCus.Password;
                }
                cus.Status = entityCus.Status;
            }
            db.SaveChanges();
            return entityCus.UserName;
        }
        public bool Delete(string username)
        {
            try
            {
                var cus = db.UserAccounts.Find(username);
                db.UserAccounts.Remove(cus);
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
            var cus = db.UserAccounts.Single(u => u.CusID == id);
            var a = cus.Status;
            cus.Status = !cus.Status;
            db.SaveChanges();
            return cus.Status;
        }
    }
}
