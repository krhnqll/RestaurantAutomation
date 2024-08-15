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
    public partial class Case : Form
    {
        public Case()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MENU men = new MENU();
            formGetir(men);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PAYMENT py = new PAYMENT();
            formGetir(py);
        }

        private void Case_Load(object sender, EventArgs e)
        {

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

        private void btndesks_Click(object sender, EventArgs e)
        {
            TABLE_LIST tbl = new TABLE_LIST();
            formGetir(tbl);
        }
    }
}
