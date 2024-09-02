using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace RestoranOtomasyon
{
    
    public partial class REPORT : Form

    {
        RestoranOtomasyonClass ISLEMLER;
        private PrintDocument printDocument = new PrintDocument();
        DataTable dt;
        public REPORT()
        {
            InitializeComponent();
            ISLEMLER = new RestoranOtomasyonClass();
            //printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //printDialog.Document = printDocument;

            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}
            CreatePdf();
        }
        //private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    string textToPrint = "Bu bir çıktı sayfasıdır!";
        //    Font printFont = new Font("Arial", 14);
        //    e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, 10, 10);
            
        //}


        private void CreatePdf()
    {
        // PDF belgesini oluşturun
        Document doc = new Document();

        // PDF dosyasının yolunu belirtin
        string path = @"C:\path\to\your\output.pdf";

        // PdfWriter ile dosyayı oluşturun
        PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

        // PDF belgesini açın
        doc.Open();

        // PDF'e metin ekleyin
        Paragraph para = new Paragraph("Merhaba, bu bir PDF belgesidir!");
        doc.Add(para);

        // PDF belgesini kapatın
        doc.Close();

        MessageBox.Show("PDF dosyası başarıyla oluşturuldu: " + path);
    }

        private void REPORT_Load(object sender, EventArgs e)
        {
            fetchDataForReportsPage();
        }

        private void LblResult_Click(object sender, EventArgs e)
        {

        }

        public void fetchDataForReportsPage()
        {
            string queery = @"SELECT DISTINCT Orders.Order_id, Orders.Date, [dbo].[Products].Prod_name,[dbo].[Products].Prod_price, Products.Prod_cost
                        FROM 
                        [dbo].[Orders]
                        JOIN [dbo].[Bar] ON [dbo].[Orders].Bar_id = [dbo].[Bar].Bar_id
                        JOIN [dbo].[Kitchen] ON [dbo].[Orders].Kitchen_id =  [dbo].[Kitchen].Kitchen_id
                        JOIN [dbo].[User] ON [dbo].[Orders].[User_id] = [dbo].[User].User_id
                        JOIN [dbo].[Products] ON [dbo].[Orders].Prod_id = [dbo].[Products].Prod_id 
						JOIN [dbo].[DD] ON [dbo].[Orders].Desk_id = [dbo].[DD].Desk_id ";

            SqlCommand comm = new SqlCommand(queery,ISLEMLER.SqlServer);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);

            dt = new DataTable("Data");

            dataAdapter.Fill(dt);

            dataGridView1.DataSource = dt;


        }

        public void functForSaves()
        {
            int rowCount = dt.Rows.Count;

            int startRow7Day = rowCount >=7 ? rowCount -7 : 0;

            int startRow30Day = rowCount >= 30 ? rowCount - 30 :0;

            decimal total7day = 0;
            decimal total30day = 0;


            //7 day 
            for(int i = startRow7Day; i < rowCount;i++)
            {
                DataRow row = dt.Rows[i];

                decimal prodCost = Convert.ToDecimal(row["Prod_cost"]);
                decimal prodPrice = Convert.ToDecimal(row["Prod_price"]);

                decimal result = prodPrice - prodCost;

                total7day += result;

            }
            //30 day 
            for(int i = startRow30Day; i < rowCount;i++)
            {
                DataRow row = dt.Rows[i];

                decimal prodCost = Convert.ToDecimal(row["Prod_cost"]);
                decimal prodPrice = Convert.ToDecimal(row["Prod_price"]);

                decimal result = prodPrice - prodCost;

                total30day += result;
            }

            txtRESULT7.Text = total7day.ToString("C");
            txtResult30.Text = total30day.ToString("C");
        }

        //public void functForDays()
        //{
        //    DateTime today = DateTime.Today;
        //    decimal total7Day = 0;
        //    decimal total30Day = 0;

        //    var filteredRows7 = dt.AsEnumerable().Where(row => row.Field<DateTime>("Date")>= today.AddDays(-7));
        //    var filteredRows30 = dt.AsEnumerable().Where(row => row.Field<DateTime>("Date") >= today.AddDays(-30));

        //    foreach (var row in filteredRows7)
        //    {
        //        decimal prodCost = Convert.ToDecimal(row.Field<decimal>("Prod_cost"));
        //        decimal prodPrice = Convert.ToDecimal(row.Field<decimal>("Prod_price"));

        //        decimal result = prodPrice - prodCost;
        //        total7Day += result;
        //    }

        //    foreach(var row in filteredRows30)
        //    {
        //        decimal prodCost = Convert.ToDecimal(row.Field<decimal>("Prod_cost"));
        //        decimal prodPrice = Convert.ToDecimal(row.Field<decimal>("Prod_price"));

        //        decimal result = prodPrice - prodCost;
        //        total30Day += result;
        //    }

        //    txtDays7.Text = total7Day.ToString("C");
        //    txt30day.Text = total30Day.ToString("C");

        //}


        private void btnResult_Click(object sender, EventArgs e)
        {
            functForSaves();
            //functForDays();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
