public class Ticket
{
  public UInt64 ticketId { get; set; }
  public string summary { get; set; }
  public string status{get;set;}
  public string priority{get;set;}
  public List<string> peopleInvolved { get; set; }
}