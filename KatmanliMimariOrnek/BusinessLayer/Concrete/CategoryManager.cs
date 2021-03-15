using DataAccessLayer.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repocategory = new Repository<Category>();

        public List<Category> GetAll()
        {
            return repocategory.List();
        }

        public int CategoryAddBL(Category p)
        {
            if (p.CategoryName == "" || p.CategoryName.Length <= 4 || p.CategoryName.Length >= 30)
            {
                return -1;
            }
            return repocategory.Insert(p);
        }
        public int DeleteCategoryBL(int p)
        {
            Category category = repocategory.Find(x => x.CategoryID == p);
            return repocategory.Delete(category);
        }
        public int UpdateCategoryBL(Category p)
        {
            Category category = repocategory.Find(x => x.CategoryID == p.CategoryID);
            category.CategoryName = p.CategoryName;
            return repocategory.Update(category);
        }
    }
}