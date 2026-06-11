using System.Net.Http.Json;
using System.Text.Json;

namespace EventGateway.Services;

public class AccountServiceClient(HttpClient httpClient)
{
    public async Task<bool> ApplyTransactionAsync(
        string accountId,
        object request,
        string traceId,
        CancellationToken ct = default)
    {
        httpClient.DefaultRequestHeaders.Remove("TraceId");
        
        logger.LogInformation("Calling account service for account {AccountId} traceId={TraceId}", accountId, traceId);

        var response = await httpClient.PostJson($"accounts/{accountId}/transactions", request, response);
        return true;
    }

  }
