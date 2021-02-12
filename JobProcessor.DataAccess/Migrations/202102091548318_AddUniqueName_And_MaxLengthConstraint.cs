namespace JobProcessor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueName_And_MaxLengthConstraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Name", c => c.String(maxLength: 50));
            CreateIndex("dbo.Jobs", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jobs", new[] { "Name" });
            AlterColumn("dbo.Jobs", "Name", c => c.String());
        }
    }
}
