namespace JobProcessor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ProcessedAt_Date_To_Jobs_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "ProcessedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "ProcessedAt");
        }
    }
}
