using AtosPersonalFinance_API.Data;
using AtosPersonalFinance_API.Models.Dtos;
using AtosPersonalFinance_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AtosPersonalFinance_API.Controller
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpGet("list-all")]
        public async Task<ActionResult> GetTransactions(
            [FromServices] Context context,
            [FromQuery] int user_id
        )
        {
            try
            {
                var transactions = await context.Transactions
                    .Where(x => x.UserId == user_id)
                    .OrderByDescending(x => x.UpdatedAt)
                    .Include(x => x.Category)
                    .AsNoTracking()
                    .ToListAsync();

                return Ok(transactions);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível listar as despesas." });
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateTransactionAsync(
            [FromServices] Context context,
            [FromBody] CreateTransactionDTO request,
            [FromQuery] int user_id
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (request.Type != "revenue" && request.Type != "Expense")
                {
                    return BadRequest("Invalid type, must be income or expense");
                }

                //  if (!context.Categories.(request.Category_Id)) { }

                DateTime parsedDate;

                if (
                    !DateTime.TryParseExact(
                        request.Date,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out parsedDate
                    )
                )
                {
                    return BadRequest("Inavlid date, correct format dd/MM/yyyy");
                }

                var category = context.Categories.FirstOrDefault(x => x.Id == request.Category_Id);

                if (category == null)
                {
                    return BadRequest("Category invalid.");
                }

                var newTransaction = new Transaction
                {
                    Description = request.Description,
                    Type = request.Type,
                    Value = request.Value,
                    Date = parsedDate,
                    UserId = user_id,
                    CategoryId = request.Category_Id,
                    Category = category
                };

                await context.Transactions.AddAsync(newTransaction);
                await context.SaveChangesAsync();

                return Ok(newTransaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("last-seven-days")]
        public async Task<ActionResult> GetLastTransactionsFromSevenDays(
            [FromServices] Context context,
            [FromQuery] int user_id
        )
        {
            try
            {
                var transactions = await context.Transactions
                    .Where(t => t.UserId == user_id && t.Date >= DateTime.Now.AddDays(-7))
                    .ToListAsync();

                return Ok(transactions);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível listar as despesas." });
            }
        }

        [HttpGet("group-by-date")]
        public async Task<ActionResult> GetGroupedTransactionsByDate(
            [FromServices] Context context,
            [FromQuery] int user_id,
            int number_of_days
        )
        {
            try
            {
                var transactions = await context.Transactions
                    .Where(
                        t => t.UserId == user_id && t.Date >= DateTime.Now.AddDays(-number_of_days)
                    )
                    .GroupBy(t => t.Date)
                    .ToListAsync();

                return Ok(transactions);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível listar as despesas." });
            }
        }

        /*
        [HttpGet("byCategory")]
        public async Task<ActionResult> GetTransactionByCategory(
            [FromServices] Context context,
            [FromQuery] int userId,
            [FromQuery] int categoryId
        )
        {
            try
            {
                var transactions = await context.Transactions
                    .Include(t => t.Category)
                    .Where(t => t.UserId == userId && t.CategoryId == categoryId)
                    .ToListAsync();

                return Ok(transactions);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível listar as despesas." });
            }
        }

        [HttpGet("{userId}/{type}")]
        public async Task<ActionResult> GetTransactionByType(
            [FromServices] Context context,
            string type,
            int userId
        )
        {
            try
            {
                var transactions = await context.Transactions
                    .Where(t => t.Type == type && t.UserId == userId)
                    .ToListAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível listar as despesas." });
            }
        }*/
    }
}
