namespace YelpCamps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorInCampTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campgrounds", "Author_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Campgrounds", "Author_Id");
            AddForeignKey("dbo.Campgrounds", "Author_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campgrounds", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Campgrounds", new[] { "Author_Id" });
            DropColumn("dbo.Campgrounds", "Author_Id");
        }
    }
}
