using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private LeHoangLongContext db;
        public CategoryDao()
        {
            db = new LeHoangLongContext();

        }

        public int Insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product.ProductID;
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.ProductName.Contains(keysearch));
            }

            return model.OrderBy(x => x.ProductName).ToPagedList(page, pagesize);
        }
        public Product Find(int productID)
        {
            return db.Products.Find(productID);
        }
        public bool Delete(int productid)
        {
            try
            {
                var product = db.Products.Find(productid);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public int Update(Product entityProduct)
        {
            var product = Find(entityProduct.ProductID);
            if (product == null)
            {
                db.Products.Add(entityProduct);

            }
            else
            {
                product.ProductID = entityProduct.ProductID;
                if (!string.IsNullOrEmpty(entityProduct.ProductName))
                {
                    product.ProductName = entityProduct.ProductName;
                }
                product.ProductStatus = entityProduct.ProductStatus;
            }

            db.SaveChanges();
            return entityProduct.ProductID;
        }
    }
}
