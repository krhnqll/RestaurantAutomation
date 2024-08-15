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
    public partial class CUSTOMER_LIST : Form
    {
        RestoranOtomasyonClass db;
        public CUSTOMER_LIST()
        {
            InitializeComponent();
            db = new RestoranOtomasyonClass();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (db.SqlServer.State == ConnectionState.Closed)
                    db.SqlServer.Open();

                string query = "INSERT INTO [User] (User_username, User_password, User_name, User_surname, User_Email, User_phonenum) VALUES (@u1, @u2, @u3, @u4, @u5, @u6)";
                SqlCommand command = new SqlCommand(query, db.SqlServer);
                
                command.Parameters.AddWithValue("@u1", textBox1.Text);
                command.Parameters.AddWithValue("@u2", textBox2.Text);
                command.Parameters.AddWithValue("@u3", textBox3.Text);
                command.Parameters.AddWithValue("@u4", textBox4.Text);
                command.Parameters.AddWithValue("@u5", textBox5.Text);
                command.Parameters.AddWithValue("@u6", textBox6.Text);
                
              
                command.ExecuteNonQuery();

         
                MessageBox.Show("New User Added!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string refresh = "SELECT User_id,User_username,User_password,User_name,User_surname,User_Email,User_phonenum FROM [User]";
                SqlCommand UserList = new SqlCommand(refresh, db.SqlServer);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(UserList);
                adapter.Fill(ds,"UserList");

                dataGridView1.DataSource = ds.Tables["UserList"];
            }
            catch 
            {

            }
            finally
            {
                //
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int choose = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[choose].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[choose].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[choose].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[choose].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[choose].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[choose].Cells[5].Value.ToString();
        }

        private void CUSTOMER_LIST_Load(object sender, EventArgs e)
        {
            string refresh = "SELECT User_id,User_username,User_password,User_name,User_surname,User_Email,User_phonenum FROM [User]";
            SqlCommand UserList = new SqlCommand(refresh, db.SqlServer);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(UserList);
            adapter.Fill(ds, "UserList");

            dataGridView1.DataSource = ds.Tables["UserList"];
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.SqlServer.State == ConnectionState.Closed)
                    db.SqlServer.Open();

                int choose = dataGridView1.SelectedCells[0].RowIndex;

                string del = "DELETE FROM [User] WHERE User_id = @User_id";
                SqlCommand delet = new SqlCommand(del, db.SqlServer);

                delet.Parameters.AddWithValue("@User_id", textBox1.Text);

                int rowsAffected = delet.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();

                }
                else
                {
                    MessageBox.Show("No user found with the specified ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
