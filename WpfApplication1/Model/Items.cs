using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    [Table("tb_item")]
    public class Items
    {
        [Key]
        public int ID { get; set; }

        public String Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

        public Supplier Supplier { get; set; }

        public Items() { }
        public Items(string n, int s, int p, Supplier supplier)
        {
            this.Name = n;
            this.Stock = s;
            this.Price = p;
            this.Supplier = supplier;
        }
    }
}
