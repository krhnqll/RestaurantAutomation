using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Data.Sql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RestoranOtomasyon
{
    public partial class ADMIN_LOGIN : Form
    {
        RestoranOtomasyonClass db;   
        public ADMIN_LOGIN()
        {
            InitializeComponent();

            db = new RestoranOtomasyonClass();
        }

        private void ADMIN_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            

            try
            {
                //We search user's username and password on the admin table.
                string adminQuery = "SELECT * FROM Admin WHERE Username = @username AND Password = @password";
                SqlCommand adminCmd = new SqlCommand(adminQuery, db.SqlServer);
                adminCmd.Parameters.AddWithValue("@Username", username);
                adminCmd.Parameters.AddWithValue("@Password", password);
                SqlDataAdapter adminSda = new SqlDataAdapter(adminCmd);
                DataTable adminDt = new DataTable();
                adminSda.Fill(adminDt);

                if (adminDt.Rows.Count > 0)
                {

                    int LoggedUserId = Convert.ToInt32(adminDt.Rows[0]["Admin_id"]);
                    SessionClass.Admin_id = LoggedUserId;
                    SessionClass.User_id = null;
                    
                    ADMIN_PAGE adminPage = new ADMIN_PAGE();
                    adminPage.Show();
                    this.Hide();
                    
                }
                else
                {
                    // User tablosunda arama yap
                    string userQuery = "SELECT * FROM [User] WHERE User_username = @username AND User_password = @password";
                    SqlCommand userCmd = new SqlCommand(userQuery, db.SqlServer);
                    userCmd.Parameters.AddWithValue("@username", username);
                    userCmd.Parameters.AddWithValue("@password", password);
                    SqlDataAdapter userSda = new SqlDataAdapter(userCmd);
                    DataTable userDt = new DataTable();
                    userSda.Fill(userDt);
                    

                    if (userDt.Rows.Count > 0)
                    {
                        int LoggedUserId = Convert.ToInt32(userDt.Rows[0]["User_id"]);
                        SessionClass.User_id = LoggedUserId;
                        SessionClass.Admin_id= null;

                        // if user find on the user table 
                        TABLE_LIST userPage = new TABLE_LIST();
                        userPage.Show();
                        this.Hide();
                    }
                    else
                    {
                        
                        MessageBox.Show("Incorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
             //
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
