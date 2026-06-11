
using EventLedger.Tests.Helpers;

namespace EventLedger.Tests;

public class AccountServiceTests : Disposable
{
    private readonly AccountWebFactory factory;
    private readonly HttpClient client;

    public AccountTest()
    {
        factory = new AccountWebFactory();
        client = factory.CreateClient();
    }

    [Fact]
    public async Task ApplyTransactionvalid()
    {
        var response = await _client.PostJson("accounts/accid1/transactions", new
        {
                       accountId = "accid1",
            type = "CREDIT",
            amount = 100.00m,
            currency = "USD",
            eventTimestamp = DateTime.Now
        });
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ApplyTransaction_Duplicate_ReturnsDuplicateMessage()
    {
        var eventId = $"evt-dup-{Guid.NewGuid()}";
        var payload = new
        {
            eventId,
            accountId = "acct02",
            type = "CREDIT",
            amount = 100.00m,
            currency = "USD",
            eventTimestamp = DateTime.UtcNow
        };

        await _client.PostAsJsonAsync("accounts/acct02/transactions", payload);
        var r2 = await _client.PostAsJsonAsync("accounts/acct02/transactions", payload);

                Assert.Equal("duplicate", body!.RootElement.GetProperty("message").GetString());
    }

}
