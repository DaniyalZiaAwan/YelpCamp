namespace YelpCamps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                        CampgroundId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campgrounds", t => t.CampgroundId, cascadeDelete: true)
                .Index(t => t.CampgroundId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CampgroundId", "dbo.Campgrounds");
            DropIndex("dbo.Comments", new[] { "CampgroundId" });
            DropTable("dbo.Comments");
        }
    }
}
