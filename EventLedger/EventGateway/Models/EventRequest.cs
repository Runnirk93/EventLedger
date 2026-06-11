using System.ComponentModel.DataAnnotations;

namespace EventGateway.Models;

public class EventRequest
{
     public string AccountId { get; set; } = string.Empty;

    public string EventId { get; set; } = string.Empty;

    
   
}
