using AtosPersonalFinance_API.Data;
using AtosPersonalFinance_API.Models.Dtos;
using AtosPersonalFinance_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to list expenses.", error = ex.Message });
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
                if (request.Type != "revenue" && request.Type != "expense")
                {
                    return BadRequest(new { message = "Invalid type, must be revenue or expense" });
                }

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
                    return BadRequest(
                        new { message = "Invalid date format, correct format dd/MM/yyyy" }
                    );
                }

                var category = context.Categories.FirstOrDefault(x => x.Id == request.CategoryId);

                if (category == null)
                {
                    return BadRequest(new { message = "Category not found." });
                }

                var newTransaction = new Transaction
                {
                    Description = request.Description,
                    Type = request.Type,
                    Value = request.Value,
                    Date = parsedDate,
                    UserId = user_id,
                    CategoryId = request.CategoryId
                };

                await context.Transactions.AddAsync(newTransaction);
                await context.SaveChangesAsync();

                return Ok(newTransaction);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to create transaction.", error = request }
                );
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
                    .OrderBy(t => t.Date)
                    .ToListAsync();

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to list last seven days.  ", error = ex.Message }
                );
            }
        }

        [HttpGet("group-by-category")]
        public async Task<ActionResult> GetGroupedTransactionsByDate(
            [FromServices] Context context,
            [FromQuery] int user_id,
            [FromQuery] string initial_date,
            [FromQuery] string final_date
        )
        {
            try
            {
                var transactions = await context.Transactions
                    .Where(
                        t =>
                            t.UserId == user_id
                            && t.Date >= DateTime.Parse(initial_date)
                            && t.Date <= DateTime.Parse(final_date)
                    )
                    .GroupBy(t => t.CategoryId)
                    .Select(
                        g =>
                            new
                            {
                                CategoryId = g.Key,
                                type = g.FirstOrDefault().Type,
                                CategoryName = g.FirstOrDefault().Category.Name,
                                Total = g.Sum(t => t.Value)
                            }
                    )
                    .ToListAsync();

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to list group by date.", error = ex.Message }
                );
            }
        }

        [HttpPatch("update")]
        public async Task<ActionResult> PatchEditTransaction(
            [FromServices] Context context,
            [FromQuery] int transaction_id,
            [FromBody] UpdateTransactionDTO request
        )
        {
            if (request.Type != "revenue" && request.Type != "expense")
            {
                return BadRequest("Invalid type, must be revenue or expense");
            }

            if (request.ToString().IsNullOrEmpty())
            {
                return null;
            }

            try
            {
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

                var transaction = await context.Transactions.FirstOrDefaultAsync(
                    x => x.Id == transaction_id
                );

                if (transaction == null)
                {
                    return BadRequest("Transaction not found.");
                }

                var category = await context.Categories.FirstAsync(
                    x => x.Id == request.Category_Id
                );

                transaction.Type = request.Type;
                transaction.CategoryId = request.Category_Id;
                transaction.Value = request.Value;
                transaction.Date = parsedDate;
                transaction.Description = request?.Description;
                transaction.UpdatedAt = DateTime.Now;
                transaction.Category = category;

                context.Transactions.Update(transaction);
                await context.SaveChangesAsync();
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to edit transaction.", error = ex.Message }
                );
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteTransaction(
            [FromServices] Context context,
            [FromQuery] int transaction_id
        )
        {
            try
            {
                var transaction = await context.Transactions.FirstOrDefaultAsync(
                    x => x.Id == transaction_id
                );

                if (transaction == null)
                {
                    return BadRequest("Transaction not found.");
                }

                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to delete transaction.", error = ex.Message }
                );
            }
        }

        [HttpGet("modified-today")]
        public async Task<ActionResult> GetModifiedToday(
            [FromServices] Context context,
            [FromQuery] int user_id
        )
        {
            try
            {
                var transactions = await context.Transactions
                    .Where(t => t.UserId == user_id && t.UpdatedAt.Date == DateTime.Now.Date)
                    .Include(t => t.Category)
                    .OrderByDescending(t => t.UpdatedAt)
                    .ToListAsync();

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to list modified today.", error = ex.Message }
                );
            }
        }

        [HttpGet("list-by")]
        public async Task<ActionResult> GetListBy(
            [FromServices] Context context,
            [FromQuery] int user_id,
            [FromQuery] string? transaction_type,
            [FromQuery] int? category_id,
            [FromQuery] string? initial_date,
            [FromQuery] string? final_date,
            [FromQuery] decimal? value
        )
        {
            if (
                string.IsNullOrEmpty(transaction_type)
                && category_id == null
                && string.IsNullOrEmpty(initial_date)
                && string.IsNullOrEmpty(final_date)
                && value == null
            )
            {
                return BadRequest(new { message = "You must provide at least one filter." });
            }
            try
            {
                var query = context.Transactions.AsQueryable();

                query = query.Where(t => t.UserId == user_id).Include(x => x.Category);

                if (category_id != null)
                {
                    query = query.Where(t => t.CategoryId == category_id);
                }

                if (!string.IsNullOrEmpty(transaction_type))
                {
                    query = query.Where(t => t.Type == transaction_type);
                }

                if (value != null)
                {
                    query = query.Where(t => t.Value == value);
                }

                if (!string.IsNullOrEmpty(initial_date))
                {
                    var parsedInitialDate = DateTime.Parse(initial_date);
                    query = query.Where(t => t.Date >= parsedInitialDate);
                }

                if (!string.IsNullOrEmpty(final_date))
                {
                    var parsedFinalDate = DateTime.Parse(final_date);
                    query = query.Where(t => t.Date <= parsedFinalDate);
                }

                var transactions = await query.ToListAsync();

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to list transactions.", error = ex.Message }
                );
            }
        }
    }
}
