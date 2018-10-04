namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCanManageCustomerRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'06add479-727a-424c-91b6-5c2f41b1326f', N'CanManageCustomers')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1ca4cc03-1d01-4e99-b331-fce88904f41c', N'06add479-727a-424c-91b6-5c2f41b1326f')");
        }
        
        public override void Down()
        {
        }
    }
}
