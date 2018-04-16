namespace SocialNetwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableRepost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reposts",
                c => new
                    {
                        RepostId = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        PublicationData = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.RepostId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reposts", "PostId", "dbo.Posts");
            DropIndex("dbo.Reposts", new[] { "PostId" });
            DropTable("dbo.Reposts");
        }
    }
}
