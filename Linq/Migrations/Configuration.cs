
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Linq.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Linq.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}