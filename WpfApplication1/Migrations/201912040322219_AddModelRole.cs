namespace WpfApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelRole : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "tb_m_Role");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_m_Role", newName: "Roles");
        }
    }
}
