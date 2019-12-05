namespace WpfApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelSuppItemTransac : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stock = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Supplier_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_m_supplier", t => t.Supplier_id)
                .Index(t => t.Supplier_id);
            
            CreateTable(
                "dbo.tb_m_supplier",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_m_TransactionItem",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        Item_ID = c.Int(),
                        Transaction_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_item", t => t.Item_ID)
                .ForeignKey("dbo.tb_m_transaction", t => t.Transaction_id)
                .Index(t => t.Item_ID)
                .Index(t => t.Transaction_id);
            
            CreateTable(
                "dbo.tb_m_transaction",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_m_TransactionItem", "Transaction_id", "dbo.tb_m_transaction");
            DropForeignKey("dbo.tb_m_TransactionItem", "Item_ID", "dbo.tb_item");
            DropForeignKey("dbo.tb_item", "Supplier_id", "dbo.tb_m_supplier");
            DropIndex("dbo.tb_m_TransactionItem", new[] { "Transaction_id" });
            DropIndex("dbo.tb_m_TransactionItem", new[] { "Item_ID" });
            DropIndex("dbo.tb_item", new[] { "Supplier_id" });
            DropTable("dbo.tb_m_transaction");
            DropTable("dbo.tb_m_TransactionItem");
            DropTable("dbo.tb_m_supplier");
            DropTable("dbo.tb_item");
        }
    }
}
