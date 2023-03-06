public class TicketFile
{
  // public property
  public string filePath { get; set; }

  // constructor is a special method that is invoked
  // when an instance of a class is created
  public TicketFile(string ticketFilePath)
  {
    filePath = ticketFilePath;
  }
}