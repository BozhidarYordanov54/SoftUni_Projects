using LogForU.Core.Enums;
using LogForU.Core.Exceptions;
using LogForU.Core.Models.Interfaces;
using LogForU.Core.Utils;
using System;

namespace LogForU.Core.Models
{
    public class Message : IMessage
    {
        private string createdTime;
        private string text;
        
        public Message(string createdTime, string text, ReportLevel reportlevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportlevel;
        }
        public string CreatedTime
        {
            get => createdTime;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new EmptyCreateTimeException();
                }

                if (!DateTimeValidator.ValidateDateTime(value)) 
                {
                    throw new InvalidDateTimeException();
                }
                createdTime = value;
            }
        }

        public string Text
        {
            get => text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }
                text = value;
            }
        }

        public ReportLevel ReportLevel { get; private set; }
    }
}
