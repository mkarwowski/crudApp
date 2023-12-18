namespace FootballApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Footballers", "FirstName", c => c.String(nullable: false, maxLength: 45));
            AlterColumn("dbo.Footballers", "Surname", c => c.String(nullable: false, maxLength: 78));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Footballers", "Surname", c => c.String());
            AlterColumn("dbo.Footballers", "FirstName", c => c.String());
        }
    }
}
