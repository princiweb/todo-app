using System.Data.Entity.Migrations;
using TodoApp.Data.Context;

namespace TodoApp.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
        }
    }
}
