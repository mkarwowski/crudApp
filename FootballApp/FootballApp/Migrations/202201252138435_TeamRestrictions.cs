namespace FootballApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamRestrictions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false, maxLength: 78));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "Name", c => c.String());
        }
    }
}
