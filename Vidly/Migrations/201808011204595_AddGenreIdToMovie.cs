namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId_Id", c => c.Int());
            CreateIndex("dbo.Movies", "GenreId_Id");
            AddForeignKey("dbo.Movies", "GenreId_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId_Id" });
            DropColumn("dbo.Movies", "GenreId_Id");
        }
    }
}
