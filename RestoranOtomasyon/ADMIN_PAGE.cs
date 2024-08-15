using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranOtomasyon
{
    public partial class ADMIN_PAGE : Form
    {
        public ADMIN_PAGE()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Orders List.
            ORDERS order = new ORDERS();
            formGetir(order);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Menu Page.
            MENU menu = new MENU();
            formGetir(menu);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Payment Page.
            PAYMENT pay = new PAYMENT();
            formGetir(pay);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Desk List.
            TABLE_LIST tABLE_LIST = new TABLE_LIST();
            formGetir(tABLE_LIST);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Customer List.
            CUSTOMER_LIST cust = new CUSTOMER_LIST();
            formGetir(cust);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Products List.
            PRODUCTS prod = new PRODUCTS();
            formGetir(prod);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Report Page.
            REPORT rep = new REPORT();
            formGetir(rep);
        }
        private void formGetir(Form form)
        {
            // I call all forms use this function.
            panel2.Controls.Clear();
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(form);
            form.Show();
        }
    }
}
