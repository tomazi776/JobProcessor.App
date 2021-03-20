namespace JobProcessor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BranchSwitchedRollback : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "ProcessedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "ProcessedAt", c => c.DateTime());
        }
    }
}
