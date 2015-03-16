using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Rb.Common;
using Rb.Common.Enums;
using Rb.Data.Entities;

namespace Rb.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RbDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RbDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            SeedSearchRequests(context);
        }

        private static void SeedSearchRequests(RbDbContext context)
        {
            Enum.GetValues(typeof (RequestType))
                .Cast<RequestType>()
                .Select(i => new Request { Description = i.GetDescription(), Type = i })
                .ToList()
                .ForEach(i => context.Requests.AddOrUpdate(r => r.Type, i));

            context.SaveChanges();
        }
    }
}