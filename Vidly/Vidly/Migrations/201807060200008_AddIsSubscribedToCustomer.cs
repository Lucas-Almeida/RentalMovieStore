namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Membership_SignUpFee", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "Membership_Duration", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Membership_DiscountRate", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Membership_DiscountRate");
            DropColumn("dbo.Customers", "Membership_Duration");
            DropColumn("dbo.Customers", "Membership_SignUpFee");
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
