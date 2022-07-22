namespace ADO.NET_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();// ProductDal objesi
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();// GetAll Data Table döndürüyor.
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("control");
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
        }

       

        private void btnAdd_Click(object sender, EventArgs e)// Add butonunun fonksiyonu
        {
            _productDal.Add(new Product
            {
                Name=tbxName.Text,
                UnitPrice=Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount=Convert.ToInt32(tbxStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Product Added");
        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Cell Content");
        }
    
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Cell Click");
            tbxNameUpdate.Text= dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),// id gridden alýnýr
                Name = tbxNameUpdate.Text,  //Diðer deðiþkenler deðiþkenin yapýldýðý textboxlardan alýnýr.
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)

            };
            _productDal.Update(product);// Add , update vs kodlarýmýz ProductDal classýnýn içinde bulunmaktadýr.
            LoadProducts();
            MessageBox.Show("Updated!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);// id gridden alýnýr
            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Deleted");
        }
    }
}