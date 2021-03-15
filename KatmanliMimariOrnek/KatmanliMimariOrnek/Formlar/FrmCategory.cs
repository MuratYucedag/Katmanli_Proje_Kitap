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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }


        CategoryManager cm = new CategoryManager();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = cm.GetAll();
            gridControl1.DataSource = degerler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.CategoryName = TxtKategoriAd.Text;
            cm.CategoryAddBL(c);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtID.Text);
            cm.DeleteCategoryBL(id);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtID.Text);
            string ad = TxtKategoriAd.Text;
            Category c = new Category();
            c.CategoryID = id;
            c.CategoryName = ad;
            cm.UpdateCategoryBL(c);
        }
    }
}