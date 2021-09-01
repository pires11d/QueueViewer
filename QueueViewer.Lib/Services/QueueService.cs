using QueueViewer.Lib.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;

namespace QueueViewer.Lib.Services
{
    public class QueueService
    {
        public List<MessageQueue> PrivateQueues { get; set; } = new List<MessageQueue>();
        public List<MessageQueue> PublicQueues { get; set; } = new List<MessageQueue>();
        public List<MessageQueue> SystemQueues { get; set; } = new List<MessageQueue>();
        public MessageQueue CurrentQueue { get; set; }
        public string MachineId { get; set; } = Environment.MachineName;

        public string GetMessageBody(Message message)
        {
            string result = "";
            message.Formatter = new System.Messaging.XmlMessageFormatter(new String[] { });
            StreamReader reader = new StreamReader(message.BodyStream);

            while (reader.Peek() >= 0)
            {
                result += reader.ReadLine();
            }

            return result;
        }

        public string GetMessageExtension(Message message)
        {
            try
            {
                return StringExtensions.BytesToString(message.Extension);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetMessageSize(Message message)
        {
            return message.BodyStream?.Length.ToString().ToSize() ?? "0 Bytes";
        }

        public MessageQueue GetQueueByName(string name)
        {
            var queues = GetQueuesByName(name);
            if (queues == null)
                return null;

            var queueName = name.ToQueueName();
            var selectedQueue = queues.FirstOrDefault(x => x.QueueName == queueName);

            return selectedQueue;
        }

        public List<MessageQueue> GetQueuesByName(string name)
        {
            var prefix = name.Split('.').FirstOrDefault();
            switch (prefix)
            {
                case nameof(Constants.Private):
                    return PrivateQueues;
                case nameof(Constants.Public):
                    return PublicQueues;
                case nameof(Constants.System):
                    return SystemQueues;
                default:
                    break;
            }
            return null;
        }

        public void SetFilter(MessageQueue currentQueue)
        {
            if (currentQueue != null)
            {
                MessagePropertyFilter filter = new MessagePropertyFilter();
                filter.ClearAll();
                filter.Id = true;
                filter.Body = true;
                filter.Priority = true;
                filter.Extension = true;
                filter.ResponseQueue = true;
                currentQueue.MessageReadPropertyFilter = filter;
            }
        }
    }
}
