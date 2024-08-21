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

namespace RestoranOtomasyon
{
    public partial class ORDERS : Form
    {
        RestoranOtomasyonClass db;
        public ORDERS()
        {
            InitializeComponent();
            db = new RestoranOtomasyonClass();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ORDERS_Load(object sender, EventArgs e)
        {
            FetchDataFromOrdersTable();
            
                
        }
        private void FetchDataFromOrdersTable() 
        {
            try
            {

                string queery = @"SELECT DISTINCT Orders.Order_id, Orders.Date,[dbo].[DD].Desk_name, [User].User_name, [dbo].[Products].Prod_name,[dbo].[Products].Prod_price, Bar.Bar_name, Kitchen.Kitchen_name 
                        FROM 
                        [dbo].[Orders]
                        JOIN [dbo].[Bar] ON [dbo].[Orders].Bar_id = [dbo].[Bar].Bar_id
                        JOIN [dbo].[Kitchen] ON [dbo].[Orders].Kitchen_id =  [dbo].[Kitchen].Kitchen_id
                        JOIN [dbo].[User] ON [dbo].[Orders].[User_id] = [dbo].[User].User_id
                        JOIN [dbo].[Products] ON [dbo].[Orders].Prod_id = [dbo].[Products].Prod_id 
						JOIN [dbo].[DD] ON [dbo].[Orders].Desk_id = [dbo].[DD].Desk_id ";

                SqlCommand ordList = new SqlCommand(queery, db.SqlServer);
                SqlDataAdapter rd = new SqlDataAdapter(ordList);
                DataTable Ord = new DataTable();
                rd.Fill(Ord);

                dataGridView1.DataSource = Ord;

            }
            catch
            {

            }
            finally
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FetchDataFromOrdersTable();
        }
    }
}
