using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "//nlog.config";

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
    Ticket ticket = new Ticket();
    StreamWriter sw = new StreamWriter(ticketFilePath);
            for (int i = 0; i < 7; i++)
            {
                // ask a question
                Console.WriteLine("Enter a ticket (Y/N)?");
                // input the response
                string resp = Console.ReadLine().ToUpper();
                // if the response is anything other than "Y", stop asking
                if (resp != "Y") { break; }
                // prompt for a ticket id number
                Console.WriteLine("Enter a Ticket Number: ");
                // save the Ticket id number
                ticket.ticketId = UInt64.Parse(Console.ReadLine());
                // prompt for ticket Summary
                Console.WriteLine("Enter a Summary for the ticket:  ");
                // save the ticket Summary
                ticket.summary = Console.ReadLine();
                // prompt for ticket status
                Console.WriteLine("Enter the ticket status (open/closed).");
                // save the ticket status
                ticket.status = Console.ReadLine();
                // prompt for priority
                Console.WriteLine("Enter the ticket priority (high/low).");
                // save the ticket priority
                ticket.priority = Console.ReadLine();
                // prompt for the name of the ticket submitter
                Console.WriteLine("Enter the name of the person submitting the ticket.");
                // save the name of the submitter
                ticket.submitter = Console.ReadLine();
                // prompt for the name of the person to whom the ticket is assigned
                Console.WriteLine("Enter the name of the person to whom the ticket is assigned.");
                // save the name of the assignee
                ticket.assigned = Console.ReadLine();
                // prompt for the name of the ticket watcher
                Console.WriteLine("Enter the name of the person watching the ticket.");
                // save the name of the watcher
                ticket.watcher = Console.ReadLine();
                // sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}",ticket.ticketId,ticket.summary, ticket.status,ticket.priority,ticket.submitter,ticket.assigned,ticket.watcher);
                
                // add ticket
              ticketFile.AddTicket(ticket);
            }
            sw.Close();
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
