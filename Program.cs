using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
string ticketFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
logger.Info("Program started");

TicketFile ticketFile = new TicketFile(ticketFilePath);

logger.Info("Program ended");
