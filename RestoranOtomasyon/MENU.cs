using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace RestoranOtomasyon
{
    public partial class MENU : Form
    {

        RestoranOtomasyonClass ISLEMLER;
        public MENU()
        {
            InitializeComponent();
            ISLEMLER = new RestoranOtomasyonClass();
            SiparisOlustur();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(button4.Tag.ToString());
            string queery = @"SELECT Prod_id,Prod_name,Prod_price FROM dbo.Categories JOIN dbo.Products ON dbo.Categories.Type_id = dbo.Products.Type_id WHERE dbo.Categories.Type_id =@CategoryId";

            SqlCommand drinks = new SqlCommand(queery, ISLEMLER.SqlServer);
            SqlDataAdapter drinksAdapter = new SqlDataAdapter(drinks);

            drinks.Parameters.AddWithValue("@CategoryId", categoryId); // Sorguda CategoryId değerine bizim tanımladığımız ifadeyi atar. Emin olmamızı sağlar.

            DataSet ds = new DataSet();
            drinksAdapter.Fill(ds, "PIZZA");
            ProductsList.DataSource = ds.Tables["PIZZA"];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(button6.Tag.ToString());
            string queery = @"SELECT Prod_id,Prod_name,Prod_price FROM dbo.Categories JOIN dbo.Products ON dbo.Categories.Type_id = dbo.Products.Type_id WHERE dbo.Categories.Type_id =@CategoryId";

            SqlCommand drinks = new SqlCommand(queery, ISLEMLER.SqlServer);
            SqlDataAdapter drinksAdapter = new SqlDataAdapter(drinks);

            drinks.Parameters.AddWithValue("@CategoryId", categoryId); // Sorguda CategoryId değerine bizim tanımladığımız ifadeyi atar. Emin olmamızı sağlar.

            DataSet ds = new DataSet();
            drinksAdapter.Fill(ds, "MEAT");
            ProductsList.DataSource = ds.Tables["MEAT"];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int categoryId = int.Parse(button1.Tag.ToString());
            string queery = @"SELECT Prod_id,Prod_name,Prod_price FROM dbo.Categories JOIN dbo.Products ON dbo.Categories.Type_id = dbo.Products.Type_id WHERE dbo.Categories.Type_id =@CategoryId";

            SqlCommand drinks = new SqlCommand(queery, ISLEMLER.SqlServer);
            SqlDataAdapter drinksAdapter = new SqlDataAdapter(drinks);

            drinks.Parameters.AddWithValue("@CategoryId", categoryId); // Sorguda CategoryId değerine bizim tanımladığımız ifadeyi atar. Emin olmamızı sağlar.

            DataSet ds = new DataSet();
            drinksAdapter.Fill(ds, "DRINKS");
            ProductsList.DataSource = ds.Tables["DRINKS"];




        }

        private void button2_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(button2.Tag.ToString());
            string queery = @"SELECT Prod_id,Prod_name,Prod_price FROM dbo.Categories JOIN dbo.Products ON dbo.Categories.Type_id = dbo.Products.Type_id WHERE dbo.Categories.Type_id =@CategoryId";

            SqlCommand drinks = new SqlCommand(queery, ISLEMLER.SqlServer);
            SqlDataAdapter drinksAdapter = new SqlDataAdapter(drinks);

            drinks.Parameters.AddWithValue("@CategoryId", categoryId); // Sorguda CategoryId değerine bizim tanımladığımız ifadeyi atar. Emin olmamızı sağlar.

            DataSet ds = new DataSet();
            drinksAdapter.Fill(ds, "SOUP");
            ProductsList.DataSource = ds.Tables["SOUP"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(button3.Tag.ToString());
            string queery = @"SELECT Prod_id,Prod_name,Prod_price FROM dbo.Categories JOIN dbo.Products ON dbo.Categories.Type_id = dbo.Products.Type_id WHERE dbo.Categories.Type_id =@CategoryId";

            SqlCommand drinks = new SqlCommand(queery, ISLEMLER.SqlServer);
            SqlDataAdapter drinksAdapter = new SqlDataAdapter(drinks);

            drinks.Parameters.AddWithValue("@CategoryId", categoryId); // Sorguda CategoryId değerine bizim tanımladığımız ifadeyi atar. Emin olmamızı sağlar.

            DataSet ds = new DataSet();
            drinksAdapter.Fill(ds, "CHICKEN");
            ProductsList.DataSource = ds.Tables["CHICKEN"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(button5.Tag.ToString());
            string queery = @"SELECT Prod_id,Prod_name,Prod_price FROM dbo.Categories JOIN dbo.Products ON dbo.Categories.Type_id = dbo.Products.Type_id WHERE dbo.Categories.Type_id =@CategoryId";

            SqlCommand drinks = new SqlCommand(queery, ISLEMLER.SqlServer);
            SqlDataAdapter drinksAdapter = new SqlDataAdapter(drinks);

            drinks.Parameters.AddWithValue("@CategoryId", categoryId); 

            DataSet ds = new DataSet();
            drinksAdapter.Fill(ds, "BURGER");
            ProductsList.DataSource = ds.Tables["BURGER"];
        }

        private void delete_prod(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void MENU_Load(object sender, EventArgs e)
        {
           
        }

        DataTable dt; 

        private void SiparisDnustur()
        {
            dt.Clear();
        }
        private void SiparisOlustur()
        {
            try
            {
                dt = new DataTable("MasaSiparisleri");

                dt.Columns.Add("Prod_name", typeof(string));
                dt.Columns.Add("Prod_price", typeof(decimal));

                dataGridView4.DataSource = dt;

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
            
        private void ProductsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = ProductsList.SelectedCells[0].RowIndex;
            int prodId = Convert.ToInt32(ProductsList.Rows[rowIndex].Cells["Prod_id"].Value);
            string query = @"SELECT Prod_name, Prod_price FROM Products WHERE Prod_id = @Prod_id";

            SqlCommand command = new SqlCommand(query, ISLEMLER.SqlServer);
            command.Parameters.AddWithValue("@Prod_id", prodId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            //DataTable dt = new DataTable();

            //dt.Columns.Add("Prod_name", typeof(string));
            //dt.Columns.Add("Prod_price", typeof(decimal));


            DataRow newRow = dt.NewRow();
            newRow["Prod_name"] = dataTable.Rows[0]["Prod_name"];
            newRow["Prod_price"] = dataTable.Rows[0]["Prod_price"];

            dt.Rows.Add(newRow);

            dataGridView4.DataSource = dt;

            //Double Click Eventi ile datagridViews arası veri aktarımı.
        }
        public void SetDeskName(String name)
        {
            
            this.Name = name;
            
            textBox1.Text = name;
        }

        private void savexit_Click(object sender, EventArgs e)
        {
            OrdersClass NewOrder = new OrdersClass();

            if (SessionClass.User_id.HasValue) // Giriş yapmış kullanıcının Id'sini eşitlediğim alan.
            {
                NewOrder.User_id = SessionClass.User_id.Value;
                NewOrder.Prd_id = GridData(); // Gridviewdan gelen veriyi nesneye eşitlediğim alan.
                NewOrder.date = DateTime.Now; // Anlık tarihi ekleme alanı.

                NewOrder.kitchen_id = FetchDatatFromKitchenTable(); ;
                NewOrder.Bar_id = FetchDataFromBarTable();
                NewOrder.Desk_id = 2;



                InsertProductInTable(NewOrder);

            }

            else if (SessionClass.Admin_id.HasValue)
            {
                NewOrder.User_id = SessionClass.Admin_id.Value;
                NewOrder.Prd_id = GridData(); // Gridviewdan gelen veriyi nesneye eşitlediğim alan.
                NewOrder.date = DateTime.Now; // Anlık tarihi ekleme alanı.

                NewOrder.kitchen_id = FetchDatatFromKitchenTable();
                NewOrder.Bar_id = FetchDataFromBarTable();
                NewOrder.Desk_id =2;




                InsertProductInTable(NewOrder);
            }
            else
            {
                MessageBox.Show("There Is Not User Or Admin Login!!");
            }

            
        }

        private int? GridData() // Gridviewden verileri çektiğimiz kısım.
        {

            int rowIndex = ProductsList.SelectedCells[0].RowIndex;
            int prodId = Convert.ToInt32(ProductsList.Rows[rowIndex].Cells["Prod_id"].Value);
                
            return prodId;
     
          
        }

        private DataTable GetDataFromTable() // Databaseden verileri çektiğimiz kısım.
        {

            return null; 
        }
        private void InsertProductInTable(OrdersClass NewOrder) // Verileri Orders Tablosuna Ekleyeceğimiz kısım.
        {
            

            try
            {
                ISLEMLER.SqlServer.Open();

                string query = @"INSERT INTO [dbo].[Orders] (Prod_id, User_id,Date,Kitchen_id,Bar_id,Desk_id) 
                                 VALUES (@Prod_id,@User_id,@Date,@Kitchen_id,@Bar_id,@Desk_id)";

                SqlCommand comm = new SqlCommand(query, ISLEMLER.SqlServer);

                comm.Parameters.AddWithValue("@Prod_id", NewOrder.Prd_id);
                comm.Parameters.AddWithValue("@User_id", NewOrder.User_id);
                comm.Parameters.AddWithValue("@Date", NewOrder.date);
                comm.Parameters.AddWithValue("@Kitchen_id", NewOrder.kitchen_id);
                comm.Parameters.AddWithValue("@Bar_id", NewOrder.Bar_id);
                comm.Parameters.AddWithValue("@Desk_id", NewOrder.Desk_id);

                comm.ExecuteNonQuery();

                MessageBox.Show("ADDING DATA WAS SUCCESSFUL", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally 
            { 
                ISLEMLER.SqlServer.Close(); 
            }
        }
        private int? FetchDataFromBarTable()
        {
            try
            {
                ISLEMLER.SqlServer.Open();
                string query = @"SELECT TOP 1 Bar_id FROM [dbo].[Bar] ORDER BY NEWID()";
                SqlCommand commBar = new SqlCommand(query, ISLEMLER.SqlServer);
                SqlDataAdapter adapter = new SqlDataAdapter(commBar);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                int randomId = (int)commBar.ExecuteScalar();

                return randomId;
            }
            catch
            {
                return -1;
            }
            finally
            {
                ISLEMLER.SqlServer.Close();
            }
    
        }
        private int? FetchDatatFromKitchenTable()
        {
            try
            {
                ISLEMLER.SqlServer.Open();
                string query = @"SELECT TOP 1 Kitchen_id FROM [dbo].[Kitchen] ORDER BY NEWID()";
                SqlCommand commBar = new SqlCommand(query, ISLEMLER.SqlServer);
                SqlDataAdapter adapter = new SqlDataAdapter(commBar);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                int randomId = (int)commBar.ExecuteScalar();

                return randomId;
            }
            catch
            {
                return -1;
            }
            finally
            {
                ISLEMLER.SqlServer.Close();
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SiparisDnustur();
        }
    }
}

