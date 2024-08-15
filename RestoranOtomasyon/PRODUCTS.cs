using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestoranOtomasyon
{
    public partial class PRODUCTS : Form
    {
        RestoranOtomasyonClass ISLEMLER;
        public PRODUCTS()
        {
            InitializeComponent();
            ISLEMLER = new RestoranOtomasyonClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ISLEMLER.SqlServer.State == ConnectionState.Closed)
                    ISLEMLER.SqlServer.Open();

                string queery = @"INSERT INTO [PRODUCTS] (Prod_name,Prod_price,Prod_cost, Type_id) VALUES (@p1,@p2,@p3,@p4)";
                SqlCommand addProd = new SqlCommand(queery, ISLEMLER.SqlServer);

                addProd.Parameters.AddWithValue("@p1", textBox1.Text);
                addProd.Parameters.AddWithValue("@p2", textBox2.Text);
                addProd.Parameters.AddWithValue("@p3", textBox4.Text);
                addProd.Parameters.AddWithValue("@p4", comboBox1.SelectedValue);

                addProd.ExecuteNonQuery();

                MessageBox.Show("New Product Added!");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
            }
            catch 
            {
                
            }
            finally
            {
                if (ISLEMLER.SqlServer.State == ConnectionState.Open)
                {   
                    ISLEMLER.SqlServer.Close();
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PRODUCTS_Load(object sender, EventArgs e)
        {
    
                fetchData();
                ComboDoldur();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string queery = @"SELECT [Categories].Type_id,[Categories].Type_name,Prod_id,Prod_name,Prod_price,Prod_cost FROM dbo.Categories JOIN dbo.Products ON dbo.Categories.Type_id = dbo.Products.Type_id";
                SqlCommand ProductsList = new SqlCommand(queery, ISLEMLER.SqlServer);
                SqlDataAdapter DataAdapter = new SqlDataAdapter(ProductsList);

                DataSet ds = new DataSet("ProdList");
                DataAdapter.Fill(ds, "ProdList");
                dataGridView1.DataSource = ds.Tables["ProdList"];
            }
            catch
            {

            }
        }

        private void ComboDoldur()
        {      
            
            string queery = @"SELECT * FROM dbo.Categories";


            SqlCommand ComboBoxList = new SqlCommand(queery, ISLEMLER.SqlServer);
            SqlDataAdapter comb = new SqlDataAdapter(ComboBoxList);
            DataSet ds = new DataSet("CombList");
            comb.Fill(ds, "CombList");  

            comboBox1.DataSource = ds.Tables["CombList"];
            comboBox1.DisplayMember = "Type_name";  
            comboBox1.ValueMember= "Type_id";
        }
        private void fetchData()
        {
            try
            {
                string queery = @"SELECT [Categories].Type_id,[Categories].Type_name,Prod_id,Prod_name,Prod_price,Prod_cost FROM dbo.Categories JOIN dbo.Products ON dbo.Categories.Type_id = dbo.Products.Type_id";
                SqlCommand ProductsList = new SqlCommand(queery, ISLEMLER.SqlServer);
                SqlDataAdapter DataAdapter = new SqlDataAdapter(ProductsList);

                DataSet ds = new DataSet("ProdList");
                DataAdapter.Fill(ds, "ProdList");
                dataGridView1.DataSource = ds.Tables["ProdList"];
            }
            catch
            {

            }
        }
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
