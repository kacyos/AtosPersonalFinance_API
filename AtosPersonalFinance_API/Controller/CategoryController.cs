using AtosPersonalFinance_API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtosPersonalFinance_API.Controller
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetCategoriesAsync(
            [FromServices] Context context,
            [FromQuery] int userId
        )
        {
            try
            {
                var categories = await context.Categories.AsNoTracking().ToListAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível listar as categorias." });
            }
        }
    }
}
