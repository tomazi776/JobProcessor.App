namespace JobProcessor.DataAccess.Migrations
{
    using JobProcessor.DataAccess.ContextConfig;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<JobProcessorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobProcessorContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
