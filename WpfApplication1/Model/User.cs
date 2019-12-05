using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    [Table("tb_m_user")]
    public class User
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }

        public User() { }
        //untuk login
        public User(string e, string pass)
        {
            this.Email = e;
            this.Password = pass;
        }
        //Regis sendiri
        public User(string name, string email,string pass)
        {
            this.Name = name;
            this.Email = email;
            this.Password = pass;
        }
        //update dari dalam tab menu
        public User(string n, string e, Role role)
        {
            this.Name = n;
            this.Email = e;
            this.Role = role;
        }
        //regis dari dalam tab menu
        public User(string n, string e, string pass, Role role)
        {
            this.Name = n;
            this.Email = e;
            this.Password = pass;
            this.Role = role;
        }
    }
}
