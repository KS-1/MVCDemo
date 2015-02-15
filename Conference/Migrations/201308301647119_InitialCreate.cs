namespace Conference.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        Abstract = c.String(nullable: false, maxLength: 2000),
                        SpeakerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.Speakers", t => t.SpeakerID, cascadeDelete: true)
                .Index(t => t.SpeakerID);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        SpeakerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SpeakerID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SessionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Sessions", t => t.SessionID, cascadeDelete: true)
                .Index(t => t.SessionID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "SessionID" });
            DropIndex("dbo.Sessions", new[] { "SpeakerID" });
            DropForeignKey("dbo.Comments", "SessionID", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "SpeakerID", "dbo.Speakers");
            DropTable("dbo.Comments");
            DropTable("dbo.Speakers");
            DropTable("dbo.Sessions");
        }
    }
}
