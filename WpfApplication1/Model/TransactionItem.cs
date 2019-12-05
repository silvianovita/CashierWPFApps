using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    [Table("tb_m_TransactionItem")]
    public class TransactionItem
    {
        [Key]
        public int id { get; set; }

        public int quantity { get; set; }

        public Transaction Transaction { get; set; }
        public Items Item { get; set; }

        public TransactionItem() { }
        public TransactionItem(int qty, Items itm)
        {
            this.quantity = qty;
            this.Item = itm;
        }
        public TransactionItem(int qty, Transaction tsct, Items itm)
        {
            this.quantity = qty;
            this.Transaction = tsct;
            this.Item = itm;
        }
    }
}
