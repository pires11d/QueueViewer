namespace System.Messaging
{
    public class Queue : System.Messaging.MessageQueue, IComparable<Queue>
    {
        public string Name { get; set; }

        public int CompareTo(Queue queue)
        {
            return queue.Name.CompareTo(this.Name);
        }
    }
}
