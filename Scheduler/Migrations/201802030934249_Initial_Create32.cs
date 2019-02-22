namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventsPartNos", "fjoNo", c => c.String());
            AddColumn("dbo.EventsPartNos", "fRemarks", c => c.String());
            DropColumn("dbo.Events", "fsource");
            DropColumn("dbo.Events", "JoNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "JoNo", c => c.String());
            AddColumn("dbo.Events", "fsource", c => c.String());
            DropColumn("dbo.EventsPartNos", "fRemarks");
            DropColumn("dbo.EventsPartNos", "fjoNo");
        }
    }
}
