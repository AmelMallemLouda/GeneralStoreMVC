namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControllerTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Transactions", "DateOfTransaction", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "DateOfTransaction");
            DropColumn("dbo.Transactions", "Price");
        }
    }
}
