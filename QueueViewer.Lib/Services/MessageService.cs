using Newtonsoft.Json;
using System;
using System.IO;
using System.Messaging;
using System.Text;

namespace QueueViewer.Lib.Services
{
    public static class MessageService
    {
        public static void SendMessage(MessageQueue queue, string message)
        {
            message = message.RemoveSpaces();
            var formatter = new JsonMessageFormatter();
            queue.Formatter = formatter;

            var msg = new Message
            {
                BodyStream = new MemoryStream(formatter.Encoding.GetBytes(message)),
                BodyType = 0
            };

            using (var trn = new MessageQueueTransaction())
            {
                try
                {
                    using (queue)
                    {
                        trn.Begin();
                        queue.Send(msg, trn);
                        trn.Commit();
                    }
                }
                catch (Exception ex)
                {
                    trn.Abort();
                    throw new ApplicationException($"Erro ao inserir mensagem. {ex.Message}.");
                }
            }
        }

        public class JsonMessageFormatter : System.Messaging.IMessageFormatter
        {
            public static readonly JsonSerializerSettings DefaultSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            private readonly JsonSerializerSettings _serializerSettings;

            public Encoding Encoding { get; set; }

            public JsonMessageFormatter(Encoding encoding = null) : this(encoding, null)
            {
            }

            public JsonMessageFormatter(Encoding encoding, JsonSerializerSettings serializerSettings = null)
            {
                Encoding = encoding ?? Encoding.UTF8;
                _serializerSettings = serializerSettings ?? DefaultSerializerSettings;
            }

            public bool CanRead(Message message)
            {
                if (message == null)
                {
                    throw new ArgumentNullException("message");
                }

                var stream = message.BodyStream;

                return stream != null
                    && stream.CanRead
                    && stream.Length > 0;
            }

            public object Clone()
            {
                return new JsonMessageFormatter(Encoding, _serializerSettings);
            }

            public object Read(Message message)
            {
                if (message == null)
                {
                    throw new ArgumentNullException("message");
                }

                if (CanRead(message) == false)
                {
                    return null;
                }

                using (var reader = new StreamReader(message.BodyStream, Encoding))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject(json, _serializerSettings);
                }
            }

            public void Write(Message message, object obj)
            {
                if (message == null)
                {
                    throw new ArgumentNullException("message");
                }

                if (obj == null)
                {
                    throw new ArgumentNullException("obj");
                }

                string json = JsonConvert.SerializeObject(obj, Formatting.None, _serializerSettings);

                message.BodyStream = new MemoryStream(Encoding.GetBytes(json));
                message.BodyType = 0;
            }
        }
    }
}
