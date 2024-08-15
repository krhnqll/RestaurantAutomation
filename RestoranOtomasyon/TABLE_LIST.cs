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
    
    public partial class TABLE_LIST : Form
    {
        RestoranOtomasyonClass db;
        public TABLE_LIST()
        {
            InitializeComponent();
            db = new RestoranOtomasyonClass();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TABLE_LIST_Load(object sender, EventArgs e)
        {
            fecthData();

        }

        private void fecthData()
        {
            try
            {
                if (db.SqlServer.State == ConnectionState.Closed)
                    db.SqlServer.Open();

                string query = "SELECT Desk_name FROM Desks";
                SqlCommand command = new SqlCommand(query, db.SqlServer);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Desks");

                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (db.SqlServer.State == ConnectionState.Open)
                {
                    db.SqlServer.Close();
                }
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            string DeskName = selectedRow.Cells["Desk_name"].Value.ToString();
            //int Desk_id = Convert.ToInt32(selectedRow.Cells["Desk_id"].Value);
            //int? deskId = selectedRow.Cells["Desk_id"].Value != DBNull.Value ? (int?)selectedRow.Cells["Desk_id"].Value : null;


            MENU editForm = new MENU();
            

            editForm.ShowDialog();
            

        }
    }
}

