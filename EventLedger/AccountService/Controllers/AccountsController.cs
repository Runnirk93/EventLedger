using AccountService.Models;
using AccountService.Data;


namespace AccountService.Controllers;




[ApiController]
[HttpGet("/health")]
    public async Task<ActionResult> Health()
    {
        try
        {
                        return Ok(new { status = "ok", service = "accountservice", database = "open", timestamp = DateTime.Now });
        }
        catch (Exception exec)
        {
         return StatusCode(503, new { status = "bad", service = "accountservice", database = "closed" });
        }
    }
}
public class AccountsController(AccountDbContext db, ILogger<AccountsController> logger) : ControllerBase
{
    [HttpPost("{accountId}/transactions")]
    public Task<ActionResult> Transaction(string accountId, TransactionRequest request)
    {
        var traceId = Request.Headers["TraceId"];
         request.EventId, accountId, traceId);

             
      
      
      
