namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventsPartNos", "fsource", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventsPartNos", "fsource");
        }
    }
}
