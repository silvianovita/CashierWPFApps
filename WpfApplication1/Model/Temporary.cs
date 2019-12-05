using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model { 

    [Table("tb_temporary")]
    public class Temporary
    {
        [Key]
        public int id;
        
        public int quantity;

        public Items Item;

        public Temporary() { }

        public Temporary(int qty, Items item) {
            this.quantity = qty;
            this.Item = item;
        }
    }
}
