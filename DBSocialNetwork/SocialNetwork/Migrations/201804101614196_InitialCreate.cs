namespace SocialNetwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                        Titl = c.String(),
                        CreateData = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PublicationData = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CategoryId = c.Guid(nullable: false),
                        TypeContent = c.Int(nullable: false),
                        FileLink = c.String(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Contents", t => t.TypeContent)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.CategoryId)
                .Index(t => t.TypeContent);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                        CreateData = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CommentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.UserId, t.CommentId })
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        TypeContent = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeContent);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        FName = c.String(),
                        LName = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CountyryId = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Country_Alpha3 = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Countries", t => t.Country_Alpha3)
                .Index(t => t.Country_Alpha3);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Alpha3 = c.String(nullable: false, maxLength: 3),
                        Alpha2 = c.String(maxLength: 2),
                        Name = c.String(),
                        NumericCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Alpha3);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.FriendId, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Friends", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Country_Alpha3", "dbo.Countries");
            DropForeignKey("dbo.Posts", "TypeContent", "dbo.Contents");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Likes", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Likes", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Country_Alpha3" });
            DropIndex("dbo.Likes", new[] { "CommentId" });
            DropIndex("dbo.Likes", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "TypeContent" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropTable("dbo.Friends");
            DropTable("dbo.Countries");
            DropTable("dbo.Users");
            DropTable("dbo.Contents");
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
