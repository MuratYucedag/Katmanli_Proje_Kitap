using DataAccessLayer.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager
    {
        Repository<Product> repoproduct = new Repository<Product>();

        public List<Product> GetAll()
        {
            return repoproduct.List();
        }

        public List<Product> GetByName(string p)
        {
            return repoproduct.List(x => x.ProductName == p);
        }

        public int ProductAddBL(Product p)
        {
            if (p.ProductName == "" || p.ProductName.Length <= 4 || p.ProductName.Length >= 30 || p.ProdcutStock <= 0 || p.ProdcutStock >= 32000 || p.ProductPrice <= 0)
            {
                return -1;
            }
            return repoproduct.Insert(p);
        }
        public int DeleteProductBL(int p)
        {
            if (p != 0)
            {
                Product product = repoproduct.Find(x => x.ProductID == p);
                return repoproduct.Delete(product);
            }
            else
            {
                return -1;
            }
        }
        public int UpdateProductBL(Product p)
        {
            if (p.ProductName == "" || p.ProductName.Length <= 4 || p.ProductName.Length >= 30 || p.ProdcutStock <= 0 || p.ProdcutStock >= 32000 || p.ProductPrice <= 0 || p.ProductID == 0)
            {
                return -1;
            }
            Product product = repoproduct.Find(x => x.ProductID == p.ProductID);
            product.ProductName = p.ProductName;
            product.ProdcutStock = p.ProdcutStock;
            product.ProductPrice = p.ProductPrice;
            product.CategoryID = p.CategoryID;
            return repoproduct.Update(product);
        }
    }
}