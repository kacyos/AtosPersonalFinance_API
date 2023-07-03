using AtosPersonalFinance_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtosPersonalFinance_API.Controller
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("list-all")]
        public async Task<ActionResult> GetCategoriesAsync(
            [FromServices] Context context,
            [FromQuery] int user_id
        )
        {
            try
            {
                var categories = await context.Categories.AsNoTracking().ToListAsync();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to list categories.", error = ex.Message }
                );
            }
        }
    }
}
