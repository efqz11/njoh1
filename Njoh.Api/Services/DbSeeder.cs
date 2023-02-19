using Microsoft.EntityFrameworkCore;
using Njoh.Data.Database;

namespace Njoh.Api.Services
{
    public class DbSeeder
    {
        private readonly NjohDbContext ctx;

        public DbSeeder(Data.Database.NjohDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task SeedAsync()
        {
            var cats = new[]
            {
                "Household",
                "Food",
                "Electronics"
            };

            if (await ctx.Categories.AnyAsync())
                return;

            foreach (var cat in cats)
            {
                ctx.Categories.Add(new Data.Models.Category
                {
                    Name = cat,
                    Description = cat
                });
            }

            await ctx.SaveChangesAsync();
        }
    }
}
