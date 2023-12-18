namespace FootballApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayedMatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayedMatches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeamID = c.Int(nullable: false),
                        _result = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayedMatches", "TeamID", "dbo.Teams");
            DropIndex("dbo.PlayedMatches", new[] { "TeamID" });
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false, maxLength: 78));
            DropTable("dbo.PlayedMatches");
        }
    }
}
