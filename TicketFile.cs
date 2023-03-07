using NLog;
public class TicketFile
{
  // public property
  public string filePath { get; set; }
  public List<Ticket> Tickets { get; set; }

  // constructor is a special method that is invoked
  // when an instance of a class is created
  public TicketFile(string ticketFilePath)
  {
    filePath = ticketFilePath;
    // create instance of Logger
    NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

    Tickets = new List<Ticket>();

    // to populate the Ticket list with data, read from the data file
    try
    {
      StreamReader sr = new StreamReader(filePath);
  
      while (!sr.EndOfStream)
      { 
        // create instance of Ticket class
        Ticket ticket = new Ticket();
        string line = sr.ReadLine();      
       
        string[] ticketDetails = line.Split('|');
        ticket.ticketId = UInt64.Parse(ticketDetails[0]);
        ticket.summary = ticketDetails[1];
        ticket.status = ticketDetails[2];
        ticket.priority = ticketDetails[3];
        ticket.submitter = ticketDetails[4];
        ticket.assigned = ticketDetails[5];
        ticket.watcher = ticketDetails[6];
              
        Tickets.Add(ticket);
      }
      // close file when done
      sr.Close();
      logger.Info("Tickets in file {Count}", Tickets.Count);
    }
    catch (Exception ex)
    {
      logger.Error(ex.Message);
    }
  }
}