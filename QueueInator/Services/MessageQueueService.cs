using Newtonsoft.Json;
using System;
using System.IO;
using System.Messaging;
using System.Text;

namespace QueueInator.Services
{
    public class MessageQueueService
    {
        public void SendMessages(string queueName, object @event)
        {
            Console.WriteLine("Iniciado processamento de inserção de mensagens na fila.");

            var queue = new MessageQueue(queueName)
            {
                Formatter = new JsonMessageFormatter(),
            };

            if (MessageQueue.Exists($".\\{queue.QueueName}"))
            {
                Console.WriteLine($"Fila {queue.QueueName} encontrada. Iniciando inserção das mensagens.");

                using (var trn = new MessageQueueTransaction())
                {
                    try
                    {
                        using (queue)
                        {
                            trn.Begin();
                            queue.Send(@event, trn);
                            trn.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao inserir mensagem. {ex.Message}. Aperte ENTER para encerrar.");
                        trn.Abort();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Fila {queue.QueueName} nao encontrada.");
            }

            Console.WriteLine("Finalizado processamento de inserção de mensagens na fila. Aperte ENTER para encerrar.");
        }

        public class JsonMessageFormatter : System.Messaging.IMessageFormatter
        {
            private static readonly JsonSerializerSettings DefaultSerializerSettings =
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    };

            private readonly JsonSerializerSettings _serializerSettings;


            public Encoding Encoding { get; set; }


            public JsonMessageFormatter(Encoding encoding = null)
                : this(encoding, null)
            {
            }

            internal JsonMessageFormatter(Encoding encoding, JsonSerializerSettings serializerSettings = null)
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

                //Need to reset the body type, in case the same message
                //is reused by some other formatter.
                message.BodyType = 0;
            }
        }
    }
}
