using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    [Table("tb_m_Role")]
    public class Role
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public Role() { }
        public Role(string name)
        {
            this.Name = name;
        }

    }
}
