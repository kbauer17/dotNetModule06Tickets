using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

Ticket ticket = new Ticket
{
  ticketId = 1,
  summary = "This is a bug ticket",
  status = "Open",
  priority = "High",
  peopleInvolved = new List<string> { "Drew Kjell", "John Doe", "Bill Jones" }
};

Console.WriteLine(ticket.Display());

logger.Info("Program ended");
