namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.MembershipTypes");
            DropPrimaryKey("dbo.Genres");
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            AddPrimaryKey("dbo.Genres", "Id");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropPrimaryKey("dbo.Genres");
            DropPrimaryKey("dbo.MembershipTypes");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "Id", c => c.Byte(nullable: false, identity: true));
            DropColumn("dbo.Customers", "BirthDate");
            AddPrimaryKey("dbo.Genres", "Id");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
