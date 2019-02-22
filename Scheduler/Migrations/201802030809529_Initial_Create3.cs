namespace Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "fsource", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "fsource");
        }
    }
}
