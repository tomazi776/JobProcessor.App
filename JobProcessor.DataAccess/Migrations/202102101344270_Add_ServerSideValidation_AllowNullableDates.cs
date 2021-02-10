namespace JobProcessor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ServerSideValidation_AllowNullableDates : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Jobs", new[] { "Name" });
            AlterColumn("dbo.Jobs", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Jobs", "DoAfter", c => c.DateTime());
            AlterColumn("dbo.Jobs", "UpdatedAt", c => c.DateTime());
            CreateIndex("dbo.Jobs", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jobs", new[] { "Name" });
            AlterColumn("dbo.Jobs", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "DoAfter", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "Name", c => c.String(maxLength: 50));
            CreateIndex("dbo.Jobs", "Name", unique: true);
        }
    }
}
