namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixGenreId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreId_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId_Id" });
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenreId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreId_Id", c => c.Int());
            DropColumn("dbo.Movies", "GenreId");
            CreateIndex("dbo.Movies", "GenreId_Id");
            AddForeignKey("dbo.Movies", "GenreId_Id", "dbo.Genres", "Id");
        }
    }
}
