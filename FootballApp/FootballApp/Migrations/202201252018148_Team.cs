namespace FootballApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Team : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Footballers", "TeamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Footballers", "TeamID");
            AddForeignKey("dbo.Footballers", "TeamID", "dbo.Teams", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Footballers", "TeamID", "dbo.Teams");
            DropIndex("dbo.Footballers", new[] { "TeamID" });
            DropColumn("dbo.Footballers", "TeamID");
            DropTable("dbo.Teams");
        }
    }
}
