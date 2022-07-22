using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemoFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();

        }

        private void LoadProducts()// Yeni loadı sağlayan kısım
        {
            dgwProducts.DataSource = _productDal.GetAll();// Yeni loadı sağlayan kısım
        }

        private void SearchProducts(string key)
        {
           // dgwProducts.DataSource = _productDal.GetAll().Where(p=>p.Name.Contains(key)).ToList();// Bu kısım sonuca göre arama yapıyor
           var result=_productDal.GetByName(key);
           // bu kısım ise database'e göre Ex: Küçük harf büyük harf duyarlılığı yok !!
           dgwProducts.DataSource = result;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)

            });
            LoadProducts();// Yeni loadı sağlayan kısım
            MessageBox.Show("Added");
        }

        private void txStockAmount_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),// id gridden alınır
                Name = tbxNameUpdate.Text,  //Diğer değişkenler değişikliğin yapıldığı textboxlardan alınır.
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)

            });
            LoadProducts();
            MessageBox.Show("Updated");
        }

        private void dgwProducts_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Cell Click");
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id= Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Deleted");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(tbxSearch.Text);
            SearchProducts(tbxSearch.Text);
        }
    }
}
