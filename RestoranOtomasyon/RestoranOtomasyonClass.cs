using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestoranOtomasyon
{
    public class RestoranOtomasyonClass
    {
        private SqlConnection _connection;

        public SqlConnection SqlServer
        { get { return _connection; } }

        public string CnnStr
        {
            get { return "Data Source = TAZ; Initial Catalog = ttt; Integrated Security = True; Persist Security Info = False; "; }
        }
        public RestoranOtomasyonClass()
        {

            _connection = new SqlConnection("Data Source=TAZ;Initial Catalog=RestaurantAutomation;Integrated Security=True;Persist Security Info=False;");
        }
    }

}

