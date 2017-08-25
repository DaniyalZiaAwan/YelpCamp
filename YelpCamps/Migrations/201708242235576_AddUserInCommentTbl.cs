namespace YelpCamps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInCommentTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Author_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "Author_Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Comments", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Author", c => c.String());
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropColumn("dbo.Comments", "Author_Id");
        }
    }
}
