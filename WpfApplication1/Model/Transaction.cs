using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    [Table("tb_m_transaction")]
    public class Transaction
    {
        [Key]
        public int id { get; set; }

        public DateTime tDate { get; set; }

        public Transaction() { }
        public Transaction (DateTime tgl)
        {   
            this.tDate = tgl;
        }
    }
}
