using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

// designate the file to read/write to
string ticketFilePath = Directory.GetCurrentDirectory() + "//tickets.csv";

logger.Info("Program started");

TicketFile ticketFile = new TicketFile(ticketFilePath);

string choice = "";
do
{
  // display choices to user
  Console.WriteLine("1) Add Ticket");
  Console.WriteLine("2) Display All Tickets");
  Console.WriteLine("Enter to quit");

  // input selection
  choice = Console.ReadLine();
  logger.Info("User choice: {Choice}", choice);
  
  if (choice == "1")
  {
    // Add ticket
  } else if (choice == "2")
  {
    // Display All Tickets
    foreach(Ticket t in ticketFile.Tickets)
    {
      Console.WriteLine(t.Display());
    }
  }

} while (choice == "1" || choice == "2");


logger.Info("Program ended");
