using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Pd_Name { get; set; }

        public string Pd_Details { get; set; }

        public int QtyInStock { get; set; }

        public DateTime LastUpdated { get; set; }


        //This will add foreign key
        public Supplier? supplier { get; set; }

    }
}
