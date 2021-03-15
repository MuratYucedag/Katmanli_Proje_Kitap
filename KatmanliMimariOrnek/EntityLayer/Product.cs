using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(30)]
        public string ProductName { get; set; }

        public short ProdcutStock { get; set; }

        public decimal ProductPrice { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}