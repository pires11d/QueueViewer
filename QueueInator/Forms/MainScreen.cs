using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Windows.Forms;
using Message = System.Messaging.Message;

namespace QueueInator
{
    public partial class MainScreen : Form
    {
        public string MachineId { get; set; } = Environment.MachineName;
        public TreeNode CurrentNode { get; set; }
        public List<MessageQueue> PrivateQueues { get; set; } = new List<MessageQueue>();
        public List<MessageQueue> PublicQueues { get; set; } = new List<MessageQueue>();
        public List<MessageQueue> SystemQueues { get; set; } = new List<MessageQueue>();

        public MainScreen()
        {
            InitializeComponent();
            LoadTreeView();
            CBB_Refresh.SelectedIndex = 1;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void LoadTreeView()
        {
            LoadQueues();

            TV_Queues.Nodes.Clear();

            TreeNode rootNode = TV_Queues.Nodes.Add("localhost");
            rootNode.Nodes.Add("Public Queues", "Public Queues");
            rootNode.Nodes.Add("Private Queues", "Private Queues");
            rootNode.Nodes.Add("System Queues", "System Queues");

            var publicNode = rootNode.GetNode("Public Queues");
            LoadNode(publicNode, PublicQueues);
            var privateNode = rootNode.GetNode("Private Queues");
            LoadNode(privateNode, PrivateQueues);
            var systemNode = rootNode.GetNode("System Queues");
            LoadNode(systemNode, SystemQueues);
        }

        private void LoadQueues()
        {
            try
            {
                PublicQueues = MessageQueue.GetPublicQueues().OrderBy(x => x.QueueName).ToList();
            }
            catch (Exception)
            {
            }

            //PrivateQueues = MessageQueue.GetPrivateQueuesByMachine(".").OrderBy(x => x.QueueName).ToList();

            string prefix = $"DIRECT=OS:{MachineId.ToLower()}";
            //var deadLetter = new MessageQueue(prefix+@"\DeadLetter$");
            //var xactDeadLetter = new MessageQueue(prefix+ @"\XactDeadLetter$");
            var dead1 = new MessageQueue(prefix + @"\SYSTEM$\DEADXACT", accessMode: QueueAccessMode.PeekAndAdmin);
            var dead2 = new MessageQueue(prefix + @"\SYSTEM$\DEADLETTER", accessMode: QueueAccessMode.PeekAndAdmin);

            SystemQueues = new List<MessageQueue>();
            SystemQueues.Add(dead1);
            SystemQueues.Add(dead2);
        }

        private void LoadNode(TreeNode parentNode, List<MessageQueue> queues, int depth = 0)
        {
            if (!queues.Any()) return;

            var groupedQueues = queues.GroupBy(x => x.QueueName.ToQueueName().Split('.')[depth]);

            foreach (var item in groupedQueues)
            {
                var newParent = AddNode(parentNode, item.Key, item.Count());

                var lastNodeItems = item.Where(x => x.QueueName.Count(y => y == '.') == depth);

                var newItems = item.Except(lastNodeItems).ToList();

                LoadNode(newParent, newItems, depth + 1);
            }
        }

        private TreeNode AddNode(TreeNode node, string name, int n = 0)
        {
            return node.Nodes.Add(name, name + $" ({n})");
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
            var dialog = new NewQueueDialog(this);
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
