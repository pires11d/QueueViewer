using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;
using Jarbas = System.Messaging.Message;

namespace QueueViewer
{
    public partial class MainScreen : Form
    {
        public TreeNode CurrentNode { get; set; }
        public List<MessageQueue> PrivateQueues { get; set; } = new List<MessageQueue>();
        public List<MessageQueue> SystemQueues { get; set; } = new List<MessageQueue>();

        public MainScreen()
        {
            InitializeComponent();
            LoadTreeView();
        }

        private void LoadTreeView()
        {
            LoadQueues();

            TreeNode rootNode = TV_Queues.Nodes.Add("localhost");
            rootNode.Nodes.Add("Private Queues");
            rootNode.Nodes.Add("System Queues");

            var privateNode = rootNode.GetNode("Private Queues");
            LoadNode(privateNode, PrivateQueues);
            var systemNode = rootNode.GetNode("System Queues");
            LoadNode(systemNode, SystemQueues);
        }

        private void LoadQueues()
        {
            PrivateQueues = MessageQueue.GetPrivateQueuesByMachine(".").ToList();

            if (!PrivateQueues.Any())
                    MessageQueue.Create(@".\private$\jarbas");

            PrivateQueues = MessageQueue.GetPrivateQueuesByMachine(".").ToList();
        }

        private void LoadNode(TreeNode node, List<MessageQueue> queues)
        {
            foreach (var queue in queues)
            {
                node.Nodes.Add(queue.QueueName, queue.QueueName.ToQueueName());
            }
        }

        public void CreateQueue(string queueName)
        {
            if (string.IsNullOrEmpty(queueName))
                return;

            var queuePath = queueName.ToQueuePath();

            if (!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath);
                CurrentNode.Nodes.Add(queueName);
            }
        }

        public void DeleteQueue()
        {
            var queueName = CurrentNode?.Text;
            if (string.IsNullOrEmpty(queueName)) 
                return;

            var queuePath = queueName.ToQueuePath();

            if (MessageQueue.Exists(queuePath))
            {
                MessageQueue.Delete(queuePath);
                CurrentNode.Remove();
            }
        }

        #region BUTTONS

        private void TSMI_Create_Click(object sender, EventArgs e)
        {
            var dialog = new Dialog(this);
            dialog.Show();
        }

        private void TSMI_Delete_Click(object sender, EventArgs e)
        {
            DeleteQueue();
        }

        private void TV_Queues_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CurrentNode = e.Node;
        }

        #endregion BUTTONS
    }
}
