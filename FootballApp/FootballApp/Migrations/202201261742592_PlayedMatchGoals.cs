namespace FootballApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayedMatchGoals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayedMatches", "GoalsScored", c => c.Int(nullable: false));
            AddColumn("dbo.PlayedMatches", "GoalsConceded", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayedMatches", "GoalsConceded");
            DropColumn("dbo.PlayedMatches", "GoalsScored");
        }
    }
}
