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
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly NjohDbContext ctx;

        public CategoriesController(ILogger<CategoriesController> logger, NjohDbContext ctx)
        {
            _logger = logger;
            this.ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await ctx.Categories.ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM model)
        {
            ctx.Categories.Add(new Category { Name = model.Name, ParentCategoryId = model.ParentCategoryId, Description = model.Description });
            await ctx.SaveChangesAsync();
            return Ok(model);
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id, CategoryVM model)
        {
            var catDb = await ctx.Categories.FindAsync(id);
            if (catDb == null)
                return NotFound();


            catDb.Name = model.Name;
            catDb.Description = model.Description;
            if (model.ParentCategoryId.HasValue)
                catDb.ParentCategoryId = model.ParentCategoryId;

            await ctx.SaveChangesAsync();
            return Ok(model);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var catDb = await ctx.Categories.FindAsync(id);
            if (catDb == null)
                return NotFound();

            ctx.Categories.Remove(catDb);
            await ctx.SaveChangesAsync();
            return Ok();
        }

    }
}