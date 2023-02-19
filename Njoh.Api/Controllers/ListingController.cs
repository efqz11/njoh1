using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Njoh.Data.Database;
using Njoh.Data.Models;
using Njoh.Data.ViewModels;

namespace Njoh.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingController : ControllerBase
    {
        private readonly ILogger<ListingController> _logger;
        private readonly NjohDbContext ctx;

        public ListingController(ILogger<ListingController> logger, NjohDbContext ctx)
        {
            _logger = logger;
            this.ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Listing>> Get(int limit = 10, int page = 1)
        {
            return await ctx.Listings
                .Skip((page-1)*limit)
                .Take(limit)
                .Include(t=> t.Spectifications)
                .ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ListingVm model)
        {
            var list =
                new Listing
                {
                    CategoryId = model.CategoryId,
                    Content = model.Content,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Title = model.Title,
                    ExpiryDate = model.ExpiryDate,
                    CreatedDate = DateTime.UtcNow
                };

            if (model.Spectifications.Count() > 0)
                list.Spectifications.AddRange(
                    model.Spectifications.Select(t => new Specification
                    {
                        Key = t.Key,
                        Value = t.Value
                    }).ToList());


            ctx.Listings.Add(list);
            await ctx.SaveChangesAsync();
            return Ok(model);
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id, ListingVm model)
        {
            var listDb = await ctx.Listings
                .Include(t => t.Spectifications)
                .FirstOrDefaultAsync(t=> t.Id == id);
            if (listDb == null)
                return NotFound();


            listDb.CategoryId = model.CategoryId;
            listDb.Content = model.Content;
            listDb.Latitude = model.Latitude;
            listDb.Longitude = model.Longitude;
            listDb.Title = model.Title;
            listDb.ExpiryDate = model.ExpiryDate;


            if (model.Spectifications.Count() > 0)
            {
                ctx.Spectifications.RemoveRange(listDb.Spectifications);

                listDb.Spectifications.AddRange(
                    model.Spectifications.Select(t => new Specification
                    {
                        Key = t.Key,
                        Value = t.Value
                    }).ToList());
            }

            await ctx.SaveChangesAsync();
            return Ok(model);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var catDb = await ctx.Listings.FindAsync(id);
            if (catDb == null)
                return NotFound();

            ctx.Listings.Remove(catDb);
            await ctx.SaveChangesAsync();
            return Ok();
        }

    }
}