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
    public enum efrmtype { Menu,Payment }
    
    public partial class TABLE_LIST : Form
    {
        RestoranOtomasyonClass db;
        efrmtype frmtype = efrmtype.Menu;
        
        public TABLE_LIST()
        {
            InitializeComponent();
            db = new RestoranOtomasyonClass();
        }
        public TABLE_LIST(efrmtype callType)
        {
            InitializeComponent();

            frmtype = callType;  

            db = new RestoranOtomasyonClass();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TABLE_LIST_Load(object sender, EventArgs e)
        {
            
            foreach(Control control in this.Controls)
            {
                if(control is Button button && button.Tag != null)
                {
                    int tagValue = Convert.ToInt32(button.Tag);

                    bool recordExist = CheckExistDatabase(tagValue);

                    if(recordExist)
                    {
                        button.BackColor = Color.Red;
                    }
                    else
                    {
                        button.BackColor= Color.Green;
                    }

                }
            }
            if(frmtype == efrmtype.Menu)
            {
                lblTAGNEWORDER.Visible = true;
                
            }
            else if(frmtype == efrmtype.Payment)
            {
                lblTAGNEWORDER.Visible = false;
                btnEXIT.Visible = false;
            }
 
        }

        private void fecthData()
        {
            //try
            //{
            //    if (db.SqlServer.State == ConnectionState.Closed)
            //        db.SqlServer.Open();

            //    string query = "SELECT Desk_name FROM Desks";
            //    SqlCommand command = new SqlCommand(query, db.SqlServer);
            //    SqlDataAdapter adapter = new SqlDataAdapter(command);
            //    DataTable dataTable = new DataTable("Desks");

            //    adapter.Fill(dataTable);

            //    dataGridView1.DataSource = dataTable;
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    if (db.SqlServer.State == ConnectionState.Open)
            //    {
            //        db.SqlServer.Close();
            //    }
            //}
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   
            //DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            //string DeskName = selectedRow.Cells["Desk_name"].Value.ToString();
            ////int Desk_id = Convert.ToInt32(selectedRow.Cells["Desk_id"].Value);
            ////int? deskId = selectedRow.Cells["Desk_id"].Value != DBNull.Value ? (int?)selectedRow.Cells["Desk_id"].Value : null;


            //MENU editForm = new MENU();
            

            //editForm.ShowDialog();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int dESK_ID = int.Parse(button3.Tag.ToString());
            string query = button3.Text;

            if (frmtype == efrmtype.Menu)
            {
                MENU MenForm = new MENU();
                MenForm.setDeskId(dESK_ID);
                MenForm.SetDeskName(query);
                MenForm.ShowDialog();

            }
            else
            {
                PAYMENT PayFrm = new PAYMENT();
                PayFrm.setDeskId(dESK_ID);
                PayFrm.SetDeskName(query);
                PayFrm.ShowDialog();
                
            }

            bool recordExist = CheckExistDatabase(dESK_ID);

            if (recordExist)
            {
                button3.BackColor = Color.Red;
            }
            else
            {
                button3.BackColor = Color.Green;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dESK_ID = int.Parse(button1.Tag.ToString());
            string query = button1.Text;

            if (frmtype == efrmtype.Menu)
            {
                MENU MenForm = new MENU();
                MenForm.setDeskId(dESK_ID);
                MenForm.SetDeskName(query);
                MenForm.ShowDialog();

            }
            else
            {
                PAYMENT PayFrm = new PAYMENT();
                PayFrm.setDeskId(dESK_ID);
                PayFrm.SetDeskName(query);
                PayFrm.ShowDialog();
                

            }

            bool recordExist = CheckExistDatabase(dESK_ID);

            if (recordExist)
            {
                button1.BackColor = Color.Red;
            }
            else
            {
                button1.BackColor = Color.Green;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dESK_ID = int.Parse(button2.Tag.ToString());
            string query = button2.Text;

            if(frmtype == efrmtype.Menu)
            {
                MENU MenForm = new MENU();
                MenForm.setDeskId(dESK_ID);
                MenForm.SetDeskName(query);
                MenForm.ShowDialog();

            }
            else
            {
                PAYMENT PayFrm = new PAYMENT();
                PayFrm.setDeskId(dESK_ID);
                PayFrm.SetDeskName(query);
                PayFrm.ShowDialog();
                

            }



            bool recordExist = CheckExistDatabase(dESK_ID);

            if (recordExist)
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button2.BackColor = Color.Green;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int dESK_ID = int.Parse(button4.Tag.ToString());
            string query = button4.Text;
            if (frmtype == efrmtype.Menu)
            {
                MENU MenForm = new MENU();
                MenForm.setDeskId(dESK_ID);
                MenForm.SetDeskName(query);
                MenForm.ShowDialog();


            }
            else
            {
                PAYMENT PayFrm = new PAYMENT();
                PayFrm.setDeskId(dESK_ID);
                PayFrm.SetDeskName(query);
                PayFrm.ShowDialog();
                


            }

            bool recordExist = CheckExistDatabase(dESK_ID);

            if (recordExist)
            {
                button4.BackColor = Color.Red;
            }
            else
            {
                button4.BackColor = Color.Green;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int dESK_ID = int.Parse(button5.Tag.ToString());
            string query = button5.Text;

            if (frmtype == efrmtype.Menu)
            {
                MENU MenForm = new MENU();
                MenForm.setDeskId(dESK_ID);
                MenForm.SetDeskName(query);
                MenForm.ShowDialog();

            }
            else
            {
                PAYMENT PayFrm = new PAYMENT();
                PayFrm.setDeskId(dESK_ID);
                PayFrm.SetDeskName(query);
                PayFrm.ShowDialog();
                

            }

            bool recordExist = CheckExistDatabase(dESK_ID);

            if (recordExist)
            {
                button5.BackColor = Color.Red;
            }
            else
            {
                button5.BackColor = Color.Green;
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
        }
        public bool CheckExistDatabase(int tagValue)
        {
            bool exists = false;

            
            string query = "SELECT COUNT(*) FROM Desks WHERE Desk_id = @TagValue";

            {
                using (SqlCommand command = new SqlCommand(query,db.SqlServer ))
                {
                    command.Parameters.AddWithValue("@TagValue", tagValue);

                    db.SqlServer.Open();

                    
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    exists = count > 0;
                }
                db.SqlServer.Close();
            }

            return exists;
        
    }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            ADMIN_LOGIN aDMIN_LOGIN = new ADMIN_LOGIN();

            aDMIN_LOGIN.Show();
            this.Close();
        }
    }
}

