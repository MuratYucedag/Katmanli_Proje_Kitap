using BusinessLayer.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatmanliMimariOrnek.Formlar
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        ProductManager pm = new ProductManager();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = pm.GetAll();
            gridControl1.DataSource = degerler;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            CategoryManager cm = new CategoryManager();
            lookUpEdit1.Properties.DataSource = (from x in cm.GetAll()
                                                 select new
                                                 {
                                                     x.CategoryID,
                                                     x.CategoryName
                                                 }).ToList();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.ProductName = TxtUrunAd.Text;
            p.ProdcutStock = short.Parse(TxtStok.Text);
            p.ProductPrice = decimal.Parse(TxtFiyat.Text);
            p.CategoryID = int.Parse(lookUpEdit1.EditValue.ToString());
            pm.ProductAddBL(p);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtID.Text);
            pm.DeleteProductBL(id);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtID.Text);
            string ad = TxtUrunAd.Text;
            short stok = short.Parse(TxtStok.Text);
            decimal fiyat = decimal.Parse(TxtFiyat.Text);
            int kategori = int.Parse(lookUpEdit1.EditValue.ToString());
            Product p = new Product();
            p.ProductID = id;
            p.ProductName = ad;
            p.ProdcutStock = stok;
            p.ProductPrice = fiyat;
            p.CategoryID = kategori;
            pm.UpdateProductBL(p);
        }

        private void BtnGetir_Click(object sender, EventArgs e)
        {
            string deger = TxtUrunAd.Text;
            var degerler = pm.GetByName(deger);
            gridControl1.DataSource = degerler;
        }
    }
}