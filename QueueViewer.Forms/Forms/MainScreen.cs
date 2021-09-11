using QueueViewer.Lib.Entities;
using QueueViewer.Lib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Messaging;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace QueueViewer.Forms
{
    public partial class MainScreen : Form
    {
        public int RefreshTime { get; set; }
        public bool Refreshing { get; set; }
        public int MaxMessages { get; set; }
        public int CurrentPage { get; set; }
        public TreeNode CurrentNode { get; set; }
        public TreeNode HoveredNode { get; set; }
        public ListViewColumnSorter ColumnSorter { get; set; }
        public QueueService Service { get; set; }
        public Dictionary<TreeNode, int> NodesToUpdate { get; set; }
        public Stopwatch ScreenTimer { get; private set; }
        public int Theme { get; set; }
        private string _appDataFolder { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine(Application.CompanyName, Application.ProductName));
        private string _configPath { get; set; }
        private Config _config { get; set; }

        public MainScreen()
        {
            InitializeComponent();
            _configPath = Path.Combine(_appDataFolder, "config.xml");
            _config = new Config();
            Service = new QueueService();

            LoadTreeView();
            LoadListView();
            LoadConfig();

            ActiveControl = CB_Refresh;
        }

        public void LoadConfig()
        {
            if (File.Exists(_configPath))
            {
                try
                {
                    var file = File.ReadAllText(_configPath);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(file);

                    _config.AutoRefresh = xmlDoc.SelectSingleNode("Config/AutoRefresh").InnerXml;
                    _config.RefreshTime = xmlDoc.SelectSingleNode("Config/RefreshTime").InnerXml;
                    _config.MaxMessages = xmlDoc.SelectSingleNode("Config/MaxMessages").InnerXml;
                    _config.Language = xmlDoc.SelectSingleNode("Config/Language").InnerXml;
                    _config.Theme = xmlDoc.SelectSingleNode("Config/Theme").InnerXml;
                }
                catch (Exception)
                {
                }
            }

            CBB_Refresh.SelectedIndex = int.TryParse(_config.RefreshTime, out int refreshTimeInt) ? refreshTimeInt : 0;
            CBB_MaxMessages.SelectedIndex = int.TryParse(_config.MaxMessages, out int maxMessagesInt) ? maxMessagesInt : 0;
            CB_Refresh.Checked = bool.TryParse(_config.AutoRefresh, out bool autoRefreshBool) ? autoRefreshBool : true;
            Theme = int.TryParse(_config.Theme, out int themeInt) ? themeInt : 0;
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(_config.Language);
        }

        private void SaveConfig()
        {
            _config.Theme = Theme.ToString();
            _config.AutoRefresh = CB_Refresh.Checked.ToString();
            _config.RefreshTime = CBB_Refresh.SelectedIndex.ToString();
            _config.MaxMessages = CBB_MaxMessages.SelectedIndex.ToString();
            _config.Language = CultureInfo.CurrentCulture.Name;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
            TextWriter writer = new StreamWriter(_configPath);
            xmlSerializer.Serialize(writer, _config);
        }

        private void T_Refresh_Tick(object sender, EventArgs e)
        {
            RefreshScreen(TV_Queues.Nodes[0]);
        }

        public void RefreshScreen(TreeNode rootNode)
        {
            var treeNodes = rootNode.Nodes;
            NodesToUpdate = new Dictionary<TreeNode, int>();

            foreach (var q in Service.PrivateQueues)
            {
                try
                {
                    var nodes = treeNodes.Find(q.QueueName.ToQueueLabel(), true).ToList();
                    var node = nodes.FirstOrDefault(x => x.ImageIndex == 0);
                    UpdateNode(node);
                }
                catch (Exception)
                {
                }
            }

            foreach (var pq in Service.PublicQueues)
            {
                try
                {
                    var node = treeNodes.Find(pq.QueueName, true).FirstOrDefault();
                    UpdateNode(node);
                }
                catch (Exception)
                {
                }
            }

            foreach (var sq in Service.SystemQueues)
            {
                try
                {
                    var node = treeNodes.Find(sq.FormatName, true).FirstOrDefault();
                    UpdateNode(node);
                }
                catch (Exception)
                {
                }
            }

            RefreshNodeInfo();
        }

        private void RefreshNodeInfo()
        {
            if (NodesToUpdate?.Count() > 0)
            {
                foreach (var n in NodesToUpdate)
                {
                    var node = n.Key;
                    int newCount = n.Value;
                    int oldCount = (int)node.Tag;
                    node.Text = node.Text.UpdateCount(newCount);
                    node.Tag = newCount;
                    SetNodeColor(node, oldCount, newCount);
                }

                new Thread(() =>
                {
                    ScreenTimer = new Stopwatch();
                    ScreenTimer.Start();
                    while (true)
                    {
                        if (ScreenTimer.ElapsedMilliseconds > 1500)
                        {
                            break;
                        }
                    }
                    ScreenTimer.Stop();
                    ResetNodesBackColor(NodesToUpdate.Keys.ToList());
                }).Start();
            }
        }

        private void UpdateParentNode(TreeNode parentNode, int oldCount = 0, int newCount = 0)
        {
            if (parentNode != null && !IsRootNode(parentNode))
            {
                int parentOldCount = (int)parentNode.Tag;
                int parentNewCount = parentOldCount + newCount - oldCount;
                UpdateNode(parentNode, parentOldCount, parentNewCount);
                UpdateParentNode(parentNode.Parent, parentOldCount, parentNewCount);
            }
        }

        private bool IsRootNode(TreeNode node)
        {
            switch (node.Text)
            {
                case Constants.Private:
                    return true;
                case Constants.Public:
                    return true;
                case Constants.System:
                    return true;
                default:
                    return false;
            }
        }

        #region LOAD

        private void LoadTreeView()
        {
            LoadImages();
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
            TV_Queues.ImageList.Images.Add(Properties.Resources.mail.ToBitmap());
            TV_Queues.ImageList.Images.Add(Properties.Resources.folder.ToBitmap());
            TV_Queues.ImageList.Images.Add(Properties.Resources.folderX.ToBitmap());

            LV_Messages.LargeImageList = new ImageList();
            LV_Messages.LargeImageList.ImageSize = new Size(16, 16);
            LV_Messages.LargeImageList.Images.Add(Properties.Resources.mail.ToBitmap());
        }

        private void LoadNodes()
        {
            TV_Queues.Nodes.Clear();

            var machine = Service.MachineId == Environment.MachineName ? "localhost" : Service.MachineId;
            TreeNode rootNode = TV_Queues.Nodes.Add(machine, machine, 1, 1);
            rootNode.Nodes.Add(nameof(Constants.Private), Constants.Private, 1, 1);
            rootNode.Nodes.Add(nameof(Constants.Public), Constants.Public, 1, 1);
            rootNode.Nodes.Add(nameof(Constants.System), Constants.System, 2, 2);

            rootNode.Expand();
            foreach (TreeNode node in rootNode.Nodes)
            {
                node.Expand();
            }

            var privateNode = rootNode.Nodes.Find(nameof(Constants.Private), false).FirstOrDefault();
            LoadNode(privateNode, Service.PrivateQueues);
            var publicNode = rootNode.Nodes.Find(nameof(Constants.Public), false).FirstOrDefault();
            LoadNode(publicNode, Service.PublicQueues);
            var systemNode = rootNode.Nodes.Find(nameof(Constants.System), false).FirstOrDefault();
            LoadSystemNode(systemNode, Service.SystemQueues);
        }

        private void LoadSystemNode(TreeNode parentNode, List<MessageQueue> systemQueues)
        {
            foreach (var systemQueue in systemQueues)
            {
                var queueName = systemQueue.FormatName;
                var queueLabel = queueName.ToSystemQueueLabel(Service.MachineId);
                var messageCount = systemQueue.GetAllMessages()?.Count() ?? 0;
                AddSystemNode(parentNode, queueName, queueLabel, messageCount, 0);
            }
        }

        private TreeNode AddSystemNode(TreeNode parentNode, string queueName, string queueLabel, int n = 0, int imageIndex = 0)
        {
            var node = parentNode.Nodes.Add(queueName, queueLabel + $" ({n})", imageIndex, imageIndex);
            node.Tag = n;
            return node;
        }

        private void LoadNode(TreeNode parentNode, List<MessageQueue> queues, int depth = 0)
        {
            if (!queues.Any()) return;

            var groupedQueues = queues.GroupBy(x => x.QueueName.ToQueueLabel(true).Split('.')[depth]);

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

                if (lastNodeItems.Any() && newItems.Any())
                {
                    messageCount = lastNodeItems.Sum(x => x.GetAllMessages()?.Count() ?? 0);
                    AddNode(newParent, queueGroup.Key, messageCount, 0);
                }

                LoadNode(newParent, newItems, depth + 1);
            }
        }

        private TreeNode AddNode(TreeNode parentNode, string name, int n = 0, int imageIndex = 0)
        {
            string lastName = parentNode.Name.Split('.').LastOrDefault();
            bool folder = imageIndex == 0 && lastName == name;
            var fullName = folder ? $"{parentNode.Name}" : $"{parentNode.Name}.{name}";

            var node = parentNode.Nodes.Add(fullName, name + $" ({n})", imageIndex, imageIndex);
            node.Tag = n;
            return node;
        }

        private void UpdateNode(TreeNode node)
        {
            if (node != null)
            {
                var queue = Service.GetQueueByName(node.Name);
                int oldCount = node.Tag != null ? (int)node.Tag : 0;
                int newCount = queue.GetAllMessages()?.Count() ?? 0;
                UpdateNode(node, oldCount, newCount);
                UpdateParentNode(node.Parent, oldCount, newCount);
            }
        }

        private void UpdateNode(TreeNode node, int oldCount, int newCount)
        {
            if (NodesToUpdate == null)
                NodesToUpdate = new Dictionary<TreeNode, int>();

            if (newCount != oldCount)
            {
                NodesToUpdate.Add(node, newCount);
            }
        }

        private void SetNodeColor(TreeNode node, int oldCount, int newCount)
        {
            if (newCount > oldCount)
            {
                ChangeColor(node, Color.LightGreen);
            }
            else if (newCount < oldCount)
            {
                ChangeColor(node, Color.Salmon);
            }
        }

        private void ChangeColor(TreeNode node, Color color)
        {
            node.BackColor = color;
        }

        #endregion LOAD

        #region ACTIONS

        public void InsertMessageIntoQueue(MessageQueue queue, string content)
        {
            if (queue != null)
            {
                try
                {
                    MessageService.SendMessage(queue, content);
                    PlaySound(SoundsEnum.Success);
                }
                catch (Exception)
                {
                    PlaySound(SoundsEnum.Fail);
                    throw;
                }
            }
        }

        public void ShowMessages(MessageQueue selectedQueue, int operation = 0)
        {
            LV_Messages.Items.Clear();
            try
            {
                var allMessages = selectedQueue?.GetAllMessages()?.ToList();
                if (allMessages != null)
                {
                    var messages = allMessages.OrderByDescending(x => x.SentTime).ToList();

                    if (MaxMessages > 0)
                        messages = messages.Skip(CurrentPage * MaxMessages).Take(MaxMessages).ToList();
                    else
                        CurrentPage = 0;

                    if (operation > 0)
                        Service.CurrentMessages += messages.Count;
                    else if (operation < 0)
                        Service.CurrentMessages -= messages.Count;
                    else
                        Service.CurrentMessages = messages.Count;

                    foreach (var message in messages)
                    {
                        var size = Service.GetMessageSize(message);
                        var body = Service.GetMessageBody(message);

                        var values = new string[]
                        {
                            "✉",
                            message.Id,
                            size,
                            message.SentTime.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
                            message.ResponseQueue?.QueueName.ToQueueLabel() ?? "",
                            body
                        };
                        var item = new ListViewItem(values);
                        LV_Messages.Items.Add(item);
                    }
                    LV_Messages.Sort();

                    BTN_Next.Enabled = allMessages.Count > Service.CurrentMessages;
                    BTN_Prev.Enabled = CurrentPage > 0;
                }
                else
                {
                    BTN_Next.Enabled = false;
                    BTN_Prev.Enabled = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                if (!column.Text.Contains("Id"))
                    column.Width = -2;
            }
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
                        simpleSound = new SoundPlayer(Properties.Resources.swoosh);
                        simpleSound.Play();
                        break;
                    case SoundsEnum.Fail:
                        simpleSound = new SoundPlayer(Properties.Resources.aiai);
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

        private void ShowMessageInfo()
        {
            if (LV_Messages.SelectedItems.Count > 0)
            {
                var item = LV_Messages.SelectedItems[0];
                var id = item.SubItems[1].Text;
                if (!string.IsNullOrEmpty(id))
                {
                    var message = Service.CurrentQueue.PeekById(id);
                    var body = Service.GetMessageBody(message);
                    var extension = Service.GetMessageExtension(message);
                    TB_MessageBody.Text = body.Prettify();
                    TB_MessageExtension.Text = extension;
                }
            }
        }

        #endregion ACTIONS

        #region CONTROLS

        private void TSMI_Create_Click(object sender, EventArgs e)
        {
            var dialog = new NewQueueDialog(this);
            dialog.Show();
        }

        public string CreateNewQueue(string queueName)
        {
            return Service.CreateQueue(CurrentNode.Name, queueName);
        }

        private void TSMI_Delete_Click(object sender, EventArgs e)
        {
            var result = YesNoDialog("delete this queue");
            if (!result)
                return;

            try
            {
                Service.DeleteQueue(CurrentNode?.Name);
                CurrentNode.Remove();
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
            var dialog = new NewMessageDialog(this, Service.CurrentQueue);
            dialog.Show();
        }

        private void TSMI_Purge_Click(object sender, EventArgs e)
        {
            try
            {
                Service.PurgeQueue();
                UpdateNode(CurrentNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TV_Queues_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CurrentNode = e.Node;
            try
            {
                if (CurrentNode.Parent == null)
                    return;

                if (CurrentNode.Parent.Parent == null)
                    return;

                CurrentPage = 0;
                Service.CurrentMessages = 0;
                Service.CurrentQueue = Service.GetQueueByName(CurrentNode.Name);

                if (Service.IsSystemQueue(CurrentNode.Name))
                {
                    LV_Messages.Items.Clear();
                    SetListViewColor(SystemColors.ControlLight);
                }
                else
                {
                    Service.SetFilter(Service.CurrentQueue);
                    ShowMessages(Service.CurrentQueue);
                    SetListViewColor(SystemColors.ControlLightLight);
                }

                ResizeListViewColumns(LV_Messages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetListViewColor(Color color)
        {
            LV_Messages.BackColor = color;
        }

        private void LV_Messages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ShowMessageInfo();
            }
            catch (Exception)
            {
            }
        }

        private void CBB_Refresh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CBB_Refresh.Text, out int result))
            {
                RefreshTime = result;
                T_Refresh.Stop();
                T_Refresh.Interval = RefreshTime * 1000;
                StartOrStop();
            }
        }

        private void StartOrStop()
        {
            if (Refreshing)
            {
                T_Refresh.Start();
            }
            else
            {
                T_Refresh.Stop();
            }
        }

        private void CB_Refresh_CheckedChanged(object sender, EventArgs e)
        {
            Refreshing = CB_Refresh.Checked;
            StartOrStop();
        }

        private void CMS_Queues_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Control activeControl = ActiveControl;
            if (!(activeControl is TreeView))
                e.Cancel = true;

            if (activeControl is ListView)
            {
                CMS_Messages_Opening(sender, new System.ComponentModel.CancelEventArgs());
                return;
            }

            Point targetPoint = TV_Queues.PointToClient(System.Windows.Forms.Cursor.Position);
            var selectedNode = TV_Queues.GetNodeAt(targetPoint);
            var isNodeSelected = selectedNode != null;
            CMS_Queues.Items[TSMI_Create.Name].Visible = isNodeSelected;
            CMS_Queues.Items[TSMI_Insert.Name].Visible = isNodeSelected;
            CMS_Queues.Items[TSMI_Purge.Name].Visible = isNodeSelected;
            CMS_Queues.Items[TSMI_Delete.Name].Visible = isNodeSelected;
            CMS_Queues.Items[TSMI_Splitter.Name].Visible = isNodeSelected;
            if (selectedNode == null)
            {
                CurrentNode = null;
                CMS_Queues.Items[TSMI_Expand.Name].Text = "Expand All";
                CMS_Queues.Items[TSMI_Collapse.Name].Text = "Collapse All";
                return;
            }
            TV_Queues.SelectedNode = selectedNode;
            TV_Queues_NodeMouseClick(sender, new TreeNodeMouseClickEventArgs(selectedNode, MouseButtons.Left, 1, targetPoint.X, targetPoint.Y));

            bool showExtra = selectedNode.ImageIndex == 0;
            bool isFolder = selectedNode.ImageIndex == 1;
            CMS_Queues.Items[TSMI_Create.Name].Enabled = isFolder;
            CMS_Queues.Items[TSMI_Insert.Name].Enabled = showExtra;
            CMS_Queues.Items[TSMI_Purge.Name].Enabled = showExtra;
            CMS_Queues.Items[TSMI_Delete.Name].Enabled = showExtra;
        }

        private void CMS_Messages_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (LV_Messages.SelectedItems?.Count > 0)
            {
                var startPoint = LV_Messages.PointToClient(System.Windows.Forms.Cursor.Position);
                CMS_Messages.Show(LV_Messages, startPoint);
            }
        }

        private void TSMI_Reprocess_Click(object sender, EventArgs e)
        {
            if (LV_Messages.SelectedItems?.Count > 0)
            {
                try
                {
                    var items = LV_Messages.SelectedItems.Cast<ListViewItem>().ToList();
                    foreach (ListViewItem item in items)
                    {
                        var content = item.SubItems[5].Text;
                        var queueName = item.SubItems[4].Text;

                        Service.Reprocess(content, queueName);
                    }
                    ShowMessages(Service.CurrentQueue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LV_Messages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == ColumnSorter.SortColumn)
            {
                ColumnSorter.Order = ColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                ColumnSorter.SortColumn = e.Column;
                ColumnSorter.Order = SortOrder.Descending;
            }

            LV_Messages.Sort();
        }

        private void LV_Messages_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var selectedItems = LV_Messages.SelectedItems;
            DoDragDrop(selectedItems, DragDropEffects.Move);
        }

        private void TV_Queues_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void TV_Queues_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = TV_Queues.PointToClient(new Point(e.X, e.Y));

            TV_Queues.SelectedNode = TV_Queues.GetNodeAt(targetPoint);

            if (TV_Queues.SelectedNode != null)
            {
                if (HoveredNode != null && TV_Queues.SelectedNode != HoveredNode)
                {
                    HoveredNode.BackColor = SystemColors.Window;
                }

                TV_Queues.SelectedNode.Expand();
                if (TV_Queues.SelectedNode.ImageIndex == 0)
                {
                    HoveredNode = TV_Queues.SelectedNode;
                    TV_Queues.SelectedNode.BackColor = SystemColors.ActiveCaption;
                }
            }

            TV_Queues.Scroll();
        }

        private void TV_Queues_DragLeave(object sender, EventArgs e)
        {
            ResetNodesBackColor(TV_Queues.Nodes);
        }

        private void ResetNodesBackColor(TreeNodeCollection nodes)
        {
            if (nodes.Count > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.BackColor = SystemColors.Window;
                    ResetNodesBackColor(node.Nodes);
                }
            }
        }

        private void ResetNodesBackColor(List<TreeNode> nodes)
        {
            foreach (var node in nodes)
            {
                node.BackColor = SystemColors.Window;
            }
        }

        private void BTN_RefreshMessages_Click(object sender, EventArgs e)
        {
            if (CurrentNode != null && CurrentNode.Parent.ImageIndex != 2)
            {
                ShowMessages(Service.CurrentQueue);
            }
        }

        private void BTN_Next_Click(object sender, EventArgs e)
        {
            if (MaxMessages > 0)
            {
                CurrentPage++;
                ShowMessages(Service.CurrentQueue, +1);
            }
        }

        private void BTN_Prev_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
                ShowMessages(Service.CurrentQueue, -1);
            }
        }

        private void BTN_RefreshQueues_Click(object sender, EventArgs e)
        {
            RefreshScreen(TV_Queues.Nodes[0]);
        }

        private void CBB_MaxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CBB_MaxMessages.Text, out int result))
                MaxMessages = result;
            else
                MaxMessages = 0;

            ShowMessages(Service.CurrentQueue);
        }

        private void TSMI_Expand_Click(object sender, EventArgs e)
        {
            if (CurrentNode != null)
                TV_Queues.SelectedNode.ExpandAll();
            else
                TV_Queues.ExpandAll();
        }

        private void TSMI_Collapse_Click(object sender, EventArgs e)
        {
            if (CurrentNode != null)
                TV_Queues.SelectedNode.Collapse(false);
            else
                TV_Queues.CollapseAll();
        }

        private void LV_Messages_KeyDown(object sender, KeyEventArgs e)
        {
            if (ActiveControl is ListView)
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    foreach (ListViewItem item in LV_Messages.Items)
                    {
                        item.Selected = true;
                    }
                }
                else if (e.Control && e.KeyCode == Keys.F)
                {
                }
            }
        }

        private void TV_Queues_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = TV_Queues.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = TV_Queues.GetNodeAt(targetPoint);

            MessageQueue targetQueue = Service.GetQueueByName(targetNode.Name);

            ListView.SelectedListViewItemCollection draggedItems = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

            targetNode.Expand();

            if (targetNode.ImageIndex == 0 && e.Effect == DragDropEffects.Move)
            {
                try
                {
                    foreach (ListViewItem draggedItem in draggedItems)
                    {
                        var msg = draggedItem.SubItems[5].Text;
                        var msgId = draggedItem.SubItems[1].Text;
                        InsertMessageIntoQueue(targetQueue, msg);
                        Service.RemoveMessage(CurrentNode.Name, msgId);
                        draggedItem.Remove();
                    }

                    ShowMessages(Service.CurrentQueue);
                }
                catch (Exception)
                {
                }
            }
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion CONTROLS
    }
}
