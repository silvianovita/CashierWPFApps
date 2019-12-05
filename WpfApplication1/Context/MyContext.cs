using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;

namespace WpfApplication1.Context
{

    class MyContext :DbContext
    {
        public MyContext() : base("MyContext") { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Items> Item { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<TransactionItem> TcItem { get; set; }
        
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
    }
}
