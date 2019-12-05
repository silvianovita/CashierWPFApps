using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    [Table("tb_m_supplier")]
    public class Supplier
    {
        [Key]
        public int id { get; set; }

        public String Name { get; set; }
        public String Email { get; set; }
        public DateTimeOffset CreateDate { get; set; }

        //public ICollection<Items> Item { get; set; }

        public Supplier() { }
        public Supplier(String Name, String Email)
        {
            this.Name = Name;
            this.Email = Email;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }

}
