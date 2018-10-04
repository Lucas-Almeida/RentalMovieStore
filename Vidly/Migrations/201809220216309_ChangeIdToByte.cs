namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdToByte : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Movies", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Movies", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
        }
    }
}
