namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'89da874f-b905-4e52-afa3-1e394d05283d', N'admin@vid.com', 0, N'AH+BHgX7CF+iEvsJNi55c1xxP+p44ry+UmpUFWPUk8WSMlO0Je7FtCCWyCP3pz1GTg==', N'ebee1793-f824-46c7-af40-cddab7215b4d', NULL, 0, 0, NULL, 1, 0, N'admin@vid.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'92655ee7-793e-49f1-89cf-04e945689434', N'guest@vid.com', 0, N'AF318ngauPoUkOCpP1Srt9H0M65+gkpgx7A7lKMNnNbzfNwU87nR6UTxtVLiLcKCiQ==', N'c70c4181-f80f-4f2d-94c3-1f9730165df0', NULL, 0, 0, NULL, 1, 0, N'guest@vid.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'06add479-727a-424c-91b6-5c2f41b1326e', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'89da874f-b905-4e52-afa3-1e394d05283d', N'06add479-727a-424c-91b6-5c2f41b1326e')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
