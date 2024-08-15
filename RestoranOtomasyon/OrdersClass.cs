using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon
{
    internal class OrdersClass
    {
        public int? Bar_id { get; set; }
        public int? kitchen_id { get; set; }

        public DateTime date { get; set; }

        public int Desk_id { get; set; }
        public int User_id { get; set; }

        public int? Prd_id { get; set; }

    }

}
