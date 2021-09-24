using System.Collections.Generic;

namespace System.Messaging
{
    public static class MessageQueueExtensions
    {
        public static long Count(this MessageQueue queue)
        {
            if (queue is null) return 0;

            long count = 0;
            try
            {
                var enumerator = queue.GetMessageEnumerator2();
                while (enumerator.MoveNext())
                    count++;
            }
            catch (Exception)
            {
            }
            return count;
        }

        public static List<Message> GetMessages(this MessageQueue queue, int skip = 0, int take = 0, int max = 10000)
        {
            if (queue is null) return null;

            int count = 0;
            var messages = new List<Message>();
            try
            {
                var enumerator = queue.GetMessageEnumerator2();
                while (enumerator.MoveNext() && count < max)
                {
                    if (take == 0 && skip == 0)
                    {
                        messages.Add(enumerator.Current);
                    }
                    else
                    {
                        if (count >= skip && count < (skip + take))
                            messages.Add(enumerator.Current);
                    }

                    count++;
                }
            }
            catch (Exception)
            {
            }
            return messages;
        }
    }
}
