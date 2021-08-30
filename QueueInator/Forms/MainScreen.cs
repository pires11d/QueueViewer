﻿using QueueInator.Entities;
using QueueInator.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Messaging;
using System.Windows.Forms;
using Message = System.Messaging.Message;

namespace QueueInator
{
    public partial class MainScreen : Form
    {
        public string MachineId { get; set; } = Environment.MachineName;
        public string SoundsFilePath { get; set; } = Path.Combine(Application.StartupPath, "Media");
        public string CurrentMessage { get; set; }
        public TreeNode CurrentNode { get; set; }
        public MessageQueue CurrentQueue { get; set; }
        public List<MessageQueue> PrivateQueues { get; set; } = new List<MessageQueue>();
        public List<MessageQueue> PublicQueues { get; set; } = new List<MessageQueue>();
        public List<MessageQueue> SystemQueues { get; set; } = new List<MessageQueue>();
        public ListViewColumnSorter ColumnSorter { get; set; }

        public MainScreen()
        {
            InitializeComponent();
            LoadTreeView();
            LoadListView();
            CBB_Refresh.SelectedIndex = 0;
        }

        #region LOAD

        private void LoadTreeView()
        {
            LoadImages();
            LoadQueues();
            LoadNodes();
        }

        private void LoadListView()
        {
            ResizeListViewColumns(LV_Messages);
            ColumnSorter = new ListViewColumnSorter();
            LV_Messages.ListViewItemSorter = ColumnSorter;
        }

        private void LoadImages()
        {
            TV_Queues.ImageList = new ImageList();
            TV_Queues.ImageList.Images.Add(QueueInator.Properties.Resources.mail.ToBitmap());
            TV_Queues.ImageList.Images.Add(QueueInator.Properties.Resources.folder.ToBitmap());
            TV_Queues.ImageList.Images.Add(QueueInator.Properties.Resources.folderX.ToBitmap());

            LV_Messages.LargeImageList = new ImageList();
            LV_Messages.LargeImageList.ImageSize = new Size(16, 16);
            LV_Messages.LargeImageList.Images.Add(QueueInator.Properties.Resources.mail.ToBitmap());
        }

        private void LoadQueues()
        {
            try
            {
                var machine = MachineId == Environment.MachineName ? "." : MachineId;
                PrivateQueues = MessageQueue.GetPrivateQueuesByMachine(machine).OrderBy(x => x.QueueName).ToList();
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

        public void InsertMessage(string content)
        {
            if (CurrentQueue != null)
            {
                CurrentQueue.Send(content);
                PlaySound(SoundsEnum.Success);
            }
        }

        public void PurgeQueue()
        {
            if (CurrentQueue != null)
            {
                CurrentQueue.Purge();
            }
        }

        private void ShowMessages(MessageQueue selectedQueue)
        {
            LV_Messages.Items.Clear();
            try
            {
                var messages = selectedQueue?.GetAllMessages()?.ToList();
                if (messages != null)
                {
                    foreach (var message in messages)
                    {
                        var body = GetMessageBody(message);

                        var values = new string[]
                        {
                            "✉",
                            message.Id,
                            message.ResponseQueue?.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
                            message.ResponseQueue?.QueueName.ToQueueLabel() ?? "",
                            body
                        };
                        var item = new ListViewItem(values, 0);
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

        private MessageQueue GetQueueByName(string name)
        {
            var queues = GetQueuesByName(name);
            if (queues == null)
                return null;

            var queueName = name.ToQueueName();
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

        private void PlaySound(SoundsEnum value)
        {
            try
            {
                SoundPlayer simpleSound;
                switch (value)
                {
                    case SoundsEnum.Start:
                        simpleSound = new SoundPlayer(@"C:\Windows\Media\chimes.wav");
                        simpleSound.Play();
                        break;
                    case SoundsEnum.Success:
                        simpleSound = new SoundPlayer(Path.Combine(SoundsFilePath, "swoosh.wav"));
                        simpleSound.Play();
                        break;
                    case SoundsEnum.Fail:
                        simpleSound = new SoundPlayer(Path.Combine(SoundsFilePath, "aiai.wav"));
                        simpleSound.Play();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion ACTIONS

        #region CONTROLS

        private void TSMI_Create_Click(object sender, EventArgs e)
        {
            var dialog = new NewQueueDialog(this);
            dialog.Show();
        }

        private void TSMI_Delete_Click(object sender, EventArgs e)
        {
            var result = YesNoDialog("delete this queue");
            if (!result)
                return;

            try
            {
                DeleteQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool YesNoDialog(string action)
        {
            string message = $"Are you sure you want to {action}?";
            string caption = "Confirmation Dialog";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        private void TSMI_Insert_Click(object sender, EventArgs e)
        {
            var dialog = new NewMessageDialog(this, CurrentQueue);
            dialog.Show();
        }

        private void TSMI_Purge_Click(object sender, EventArgs e)
        {
            try
            {
                PurgeQueue();
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
                CurrentQueue = GetQueueByName(CurrentNode.Name);

                ShowMessages(CurrentQueue);
                ResizeListViewColumns(LV_Messages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LV_Messages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Messages.SelectedItems.Count > 0)
            {
                var item = LV_Messages.SelectedItems[0];
                var body = item.SubItems[4].Text;
                TB_Message.Text = body.Prettify();
            }
        }

        private void CMS_Queues_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var activeControl = this.ActiveControl;
            if (!(activeControl is TreeView))
                e.Cancel = true;
        }

        private void LV_Messages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == ColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (ColumnSorter.Order == SortOrder.Ascending)
                {
                    ColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    ColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                ColumnSorter.SortColumn = e.Column;
                ColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            LV_Messages.Sort();
        }

        private void LV_Messages_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is ListViewItem)
            {
                var selectedItem = (ListViewItem)e.Item;
                CurrentMessage = selectedItem.SubItems[4]?.Text ?? "";
                DoDragDrop((selectedItem), DragDropEffects.Move);
            }
        }

        private void TV_Queues_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
        private void TV_Queues_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = TV_Queues.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            TV_Queues.SelectedNode = TV_Queues.GetNodeAt(targetPoint);

            if (TV_Queues.SelectedNode != null)
                TV_Queues.SelectedNode.Expand();
        }

        private void TV_Queues_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = TV_Queues.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = TV_Queues.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedItem.Equals(targetNode) && !ContainsNode(targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedItem.Remove();
                    var msg = draggedItem.SubItems[4].Text;
                    InsertMessage(msg);
                }
                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    var msg = draggedItem.SubItems[3].Text;
                    InsertMessage(msg);
                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node)
        {
            // Check the parent node of the second node.
            if (node.Parent == null) return false;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node.Parent);
        }

        #endregion CONTROLS
    }
}
