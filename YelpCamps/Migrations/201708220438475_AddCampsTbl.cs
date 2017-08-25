namespace YelpCamps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campgrounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Campgrounds");
        }
    }
}
