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
        public string MachineId { get; set; }

        public QueueService(string machineId = null)
        {
            MachineId = machineId ?? Environment.MachineName;

            LoadQueues();
        }

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

        public void LoadQueues()
        {
            LoadPrivateQueues();
            LoadPublicQueues();
            LoadSystemQueues();
        }

        private void LoadPrivateQueues()
        {
            try
            {
                var machine = MachineId == Environment.MachineName ? "." : MachineId;
                PrivateQueues = MessageQueue.GetPrivateQueuesByMachine(machine).OrderBy(x => x.QueueName).ToList();
            }
            catch (Exception)
            {
            }
        }

        private void LoadPublicQueues()
        {
            try
            {
                PublicQueues = MessageQueue.GetPublicQueues().OrderBy(x => x.QueueName).ToList();
            }
            catch (Exception)
            {
            }
        }

        private void LoadSystemQueues()
        {
            try
            {
                string prefix = $"DIRECT=OS:{MachineId.ToLower()}";
                var dead1 = new MessageQueue(prefix + @"\SYSTEM$\DEADXACT", accessMode: QueueAccessMode.PeekAndAdmin);
                SetFilter(dead1);
                var dead2 = new MessageQueue(prefix + @"\SYSTEM$\DEADLETTER", accessMode: QueueAccessMode.PeekAndAdmin);
                SetFilter(dead2);

                SystemQueues = new List<MessageQueue>();
                SystemQueues.Add(dead1);
                SystemQueues.Add(dead2);
            }
            catch (Exception)
            {
            }
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
            var queues = GetQueuesByName(name) ?? GetQueuesByPath(name);
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

        public List<MessageQueue> GetQueuesByPath(string name)
        {
            var prefix = name.Split(new [] { @"$\" }, StringSplitOptions.None).FirstOrDefault();

            if (!string.IsNullOrEmpty(prefix))
                prefix = prefix.Capitalize();
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

        public string CreateQueue(string parentQueue, string queueName)
        {
            if (string.IsNullOrEmpty(queueName))
                return null;

            var queueFullName = $"{parentQueue}.{queueName}";
            var queuePath = queueFullName.ToQueuePath();

            if (MessageQueue.Exists(queuePath))
                throw new ApplicationException($"A fila de nome {queueName} já existe.");

            try
            {
                MessageQueue.Create(queuePath);
                return queueFullName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteQueue(string queueName)
        {
            if (string.IsNullOrEmpty(queueName))
                return;

            var queuePath = queueName.ToQueuePath();

            if (!MessageQueue.Exists(queuePath))
                throw new ApplicationException($"A fila de nome {queueName} não foi encontrada.");

            try
            {
                MessageQueue.Delete(queuePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveMessage(string queueName, string msgId)
        {
            var originQueue = GetQueueByName(queueName);
            originQueue.ReceiveById(msgId);
        }

        public void PurgeQueue()
        {
            if (CurrentQueue != null)
            {
                CurrentQueue.Purge();
            }
        }
    }
}
