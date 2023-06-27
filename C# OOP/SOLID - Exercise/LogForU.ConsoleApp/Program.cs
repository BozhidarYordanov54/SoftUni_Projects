using LogForU.ConsoleApp.CustomLayouts;
using LogForU.Core.Appenders;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.IO;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;

//ILayout simpleLayout = new SimpleLayout();
//
//IAppender consoleAppender = new ConsoleAppender(simpleLayout);
//
//ILogFile file = new LogFile();
//IAppender fileAppender = new FileAppender(simpleLayout, file);
//
//ILogger logger = new Logger(consoleAppender, fileAppender);



ILayout xmlLayout = new XmlLayout();
IAppender consoleAppender = new ConsoleAppender(xmlLayout);

ILogFile file = new LogFile("test", "xml", Directory.GetCurrentDirectory());
IAppender fileAppender = new FileAppender(xmlLayout, file);

ILogger logger = new Logger(consoleAppender, fileAppender);

logger.Fatal("3/31/2015 5:23:54 PM", "microlib.dll does not respond");
logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");
