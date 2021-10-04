namespace DotNetEFAutoLot.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CustId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CarId", "dbo.Inventory");
            RenameColumn(table: "dbo.Orders", name: "CustId", newName: "CunstomerId");
            RenameIndex(table: "dbo.Orders", name: "IX_CustId", newName: "IX_CunstomerId");
            DropPrimaryKey("dbo.CreditRisks");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Inventory");
            DropColumn("dbo.CreditRisks", "CustId");
            DropColumn("dbo.Customers", "CustId");
            DropColumn("dbo.Orders", "OrderId");
            DropColumn("dbo.Inventory", "CarId");
            AddColumn("dbo.CreditRisks", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditRisks", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Inventory", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Inventory", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddPrimaryKey("dbo.CreditRisks", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            AddPrimaryKey("dbo.Inventory", "Id");
            CreateIndex("dbo.CreditRisks", new[] { "LastName", "FirstName" }, unique: true, name: "IDX_CreditRisk_Name");
            AddForeignKey("dbo.Orders", "CunstomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CarId", "dbo.Inventory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarId", "dbo.Inventory");
            DropForeignKey("dbo.Orders", "CunstomerId", "dbo.Customers");
            DropPrimaryKey("dbo.Inventory");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.CreditRisks");
            DropIndex("dbo.CreditRisks", "IDX_CreditRisk_Name");
            DropColumn("dbo.Inventory", "Timestamp");
            DropColumn("dbo.Inventory", "Id");
            DropColumn("dbo.Orders", "Timestamp");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Customers", "Timestamp");
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.CreditRisks", "Timestamp");
            DropColumn("dbo.CreditRisks", "Id");
            AddColumn("dbo.Inventory", "CarId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "CustId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditRisks", "CustId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Inventory", "CarId");
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.Customers", "CustId");
            AddPrimaryKey("dbo.CreditRisks", "CustId");
            RenameIndex(table: "dbo.Orders", name: "IX_CunstomerId", newName: "IX_CustId");
            RenameColumn(table: "dbo.Orders", name: "CunstomerId", newName: "CustId");
            AddForeignKey("dbo.Orders", "CarId", "dbo.Inventory", "CarId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustId", "dbo.Customers", "CustId", cascadeDelete: true);
        }
    }
}
