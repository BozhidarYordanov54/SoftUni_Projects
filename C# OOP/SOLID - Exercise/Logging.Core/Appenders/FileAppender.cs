using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models.Interfaces;
using System;
using System.IO;

namespace LogForU.Core.Appenders
{
    public class FileAppender : IAppender
    {
        //TODO add log file
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel report = ReportLevel.Info)
        {
            Layout = layout;
            LogFile = logFile;
            ReportLevel = report;
        }
        public ILayout Layout { get; private set; }
        public ILogFile LogFile { get; private set; }
        public ReportLevel ReportLevel { get; set; }

        public int MessageAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            //TODO add log file
            string contents =
                string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text);

            LogFile.WriteLine(contents);
            File.AppendAllText(LogFile.FullPath, contents + Environment.NewLine);
            MessageAppended++;
        }
    }
}
