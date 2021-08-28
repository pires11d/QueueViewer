using QueueInator.Entities;
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
            rootNode.Nodes.Add(nameof(Constants.Private), Constants.Private);
            rootNode.Nodes.Add(nameof(Constants.Public), Constants.Public);
            rootNode.Nodes.Add(nameof(Constants.System), Constants.System);

            var privateNode = rootNode.GetNode(nameof(Constants.Private));
            LoadNode(privateNode, PrivateQueues);
            var publicNode = rootNode.GetNode(nameof(Constants.Public));
            LoadNode(publicNode, PublicQueues);
            var systemNode = rootNode.GetNode(nameof(Constants.System));
            LoadNode(systemNode, SystemQueues);
        }

        private void LoadQueues()
        {
            try
            {
                PrivateQueues = MessageQueue.GetPrivateQueuesByMachine(".").OrderBy(x => x.QueueName).ToList();
            }
            catch (Exception)
            {
            }

            try
            {
                PublicQueues = MessageQueue.GetPublicQueues().OrderBy(x => x.QueueName).ToList();
            }
            catch (Exception)
            {
            }

            try
            {
                string prefix = $"DIRECT=OS:{MachineId.ToLower()}";
                var dead1 = new MessageQueue(prefix + @"\SYSTEM$\DEADXACT", accessMode: QueueAccessMode.PeekAndAdmin);
                var dead2 = new MessageQueue(prefix + @"\SYSTEM$\DEADLETTER", accessMode: QueueAccessMode.PeekAndAdmin);

                SystemQueues = new List<MessageQueue>();
                SystemQueues.Add(dead1);
                SystemQueues.Add(dead2);
            }
            catch (Exception)
            {
            }
        }

        private void LoadNode(TreeNode parentNode, List<MessageQueue> queues, int depth = 0)
        {
            if (!queues.Any()) return;

            var groupedQueues = queues.GroupBy(x => x.QueueName.ToQueueName().Split('.')[depth]);

            foreach (var queueGroup in groupedQueues)
            {
                var lastNodeItems = queueGroup.Where(x => x.QueueName.Count(y => y == '.') == depth);

                var queue = lastNodeItems.FirstOrDefault();
                int messageCount = 0;
                try
                {
                    messageCount = queue?.GetAllMessages()?.Count() ?? 0;
                }
                catch (Exception)
                {
                }

                var newParent = AddNode(parentNode, queueGroup.Key, messageCount);

                var newItems = queueGroup.Except(lastNodeItems).ToList();

                LoadNode(newParent, newItems, depth + 1);
            }
        }

        private TreeNode AddNode(TreeNode node, string name, int n = 0)
        {
            var fullName = $"{node.Name}.{name}";
            return node.Nodes.Add(fullName, name + $" ({n})");
        }

        public void CreateQueue(string queueName)
        {
            if (string.IsNullOrEmpty(queueName))
                return;

            var queueFullName = $"{CurrentNode.Name}.{queueName}";

            var queuePath = queueFullName.ToQueuePath();

            if (!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath);
                CurrentNode.Nodes.Add(queueFullName, queueName);
            }
        }

        public void DeleteQueue()
        {
            var queueName = CurrentNode?.Name;
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
