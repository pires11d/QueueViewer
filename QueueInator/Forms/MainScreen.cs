using QueueInator.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            ResizeListViewColumns(LV_Messages);
            CBB_Refresh.SelectedIndex = 2;
        }

        #region LOAD

        private void LoadTreeView()
        {
            LoadImages();

            LoadQueues();

            LoadNodes();
        }

        private void LoadImages()
        {
            TV_Queues.ImageList = new ImageList();
            TV_Queues.ImageList.Images.Add(QueueInator.Properties.Resources.mail.ToBitmap());
            TV_Queues.ImageList.Images.Add(QueueInator.Properties.Resources.folder.ToBitmap());
            TV_Queues.ImageList.Images.Add(QueueInator.Properties.Resources.folderX.ToBitmap());
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

        private void LoadNodes()
        {
            TV_Queues.Nodes.Clear();

            var machine = MachineId == Environment.MachineName ? "localhost" : MachineId;
            TreeNode rootNode = TV_Queues.Nodes.Add(machine, machine, 1, 1);
            rootNode.Nodes.Add(nameof(Constants.Private), Constants.Private, 1, 1);
            rootNode.Nodes.Add(nameof(Constants.Public), Constants.Public, 1, 1);
            rootNode.Nodes.Add(nameof(Constants.System), Constants.System, 2, 2);

            rootNode.Expand();
            foreach (TreeNode node in rootNode.Nodes)
            {
                node.Expand();
            }

            var privateNode = rootNode.GetNode(nameof(Constants.Private));
            LoadNode(privateNode, PrivateQueues);
            var publicNode = rootNode.GetNode(nameof(Constants.Public));
            LoadNode(publicNode, PublicQueues);
            var systemNode = rootNode.GetNode(nameof(Constants.System));
            LoadNode(systemNode, SystemQueues);
        }

        private void LoadNode(TreeNode parentNode, List<MessageQueue> queues, int depth = 0)
        {
            if (!queues.Any()) return;

            var groupedQueues = queues.GroupBy(x => x.QueueName.ToQueueLabel().Split('.')[depth]);

            foreach (var queueGroup in groupedQueues)
            {
                var lastNodeItems = queueGroup.Where(x => x.QueueName.Count(y => y == '.') == depth);

                int messageCount = 0;
                try
                {
                    messageCount = queueGroup.Select(x => x.GetAllMessages()?.Count() ?? 0).Sum();
                }
                catch (Exception)
                {
                }

                var newItems = queueGroup.Except(lastNodeItems).ToList();

                int imageIndex = newItems.Any() ? 1 : 0;

                var newParent = AddNode(parentNode, queueGroup.Key, messageCount, imageIndex);

                LoadNode(newParent, newItems, depth + 1);
            }
        }

        private TreeNode AddNode(TreeNode node, string name, int n = 0, int imageIndex = 0)
        {
            var fullName = $"{node.Name}.{name}";
            return node.Nodes.Add(fullName, name + $" ({n})", imageIndex, imageIndex);
        }

        #endregion LOAD

        #region ACTIONS

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

        private void ShowMessages(TreeNode node)
        {
            LV_Messages.Items.Clear();
            try
            {
                var selectedQueue = GetQueue(node);

                var messages = selectedQueue?.GetAllMessages()?.ToList();
                if (messages != null)
                {
                    foreach (var message in messages)
                    {
                        var body = GetMessageBody(message);

                        var values = new string[]
                        {
                            message.Id,
                            message.ResponseQueue?.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
                            body
                        };
                        var item = new ListViewItem(values);
                        LV_Messages.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetMessageBody(Message message)
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

        private MessageQueue GetQueue(TreeNode node)
        {
            var queues = GetQueuesByName(node.Name);
            if (queues == null)
                return null;

            var queueName = node.Name.ToQueueName();
            var selectedQueue = queues.FirstOrDefault(x => x.QueueName == queueName);

            return selectedQueue;
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        private List<MessageQueue> GetQueuesByName(string name)
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

        #endregion ACTIONS

        #region BUTTONS

        private void TSMI_Create_Click(object sender, EventArgs e)
        {
            var dialog = new NewQueueDialog(this);
            dialog.Show();
        }

        private void TSMI_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TV_Queues_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                CurrentNode = e.Node;
                ShowMessages(e.Node);
                ResizeListViewColumns(LV_Messages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion BUTTONS

        private void LV_Messages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Messages.SelectedItems.Count > 0)
            {
                var item = LV_Messages.SelectedItems[0];
                var body = item.SubItems[2].Text;
                TB_Message.Text = body.Prettify();
            }
        }

        private void CMS_Queues_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var activeControl = this.ActiveControl;
            if (!(activeControl is TreeView))
                e.Cancel = true;
        }
    }
}
