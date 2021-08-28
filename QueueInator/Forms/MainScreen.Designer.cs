
namespace QueueInator
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.TV_Queues = new System.Windows.Forms.TreeView();
            this.MS_Header = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS_Queues = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Purge = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.messageQueue1 = new System.Messaging.MessageQueue();
            this.CB_Refresh = new System.Windows.Forms.CheckBox();
            this.CBB_Refresh = new System.Windows.Forms.ComboBox();
            this.L_Unit = new System.Windows.Forms.Label();
            this.P_Top = new System.Windows.Forms.Panel();
            this.P_Right = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.P_BotttomRight = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.P_TopRight = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.P_Left = new System.Windows.Forms.Panel();
            this.P_Bottom = new System.Windows.Forms.Panel();
            this.MS_Header.SuspendLayout();
            this.CMS_Queues.SuspendLayout();
            this.P_Top.SuspendLayout();
            this.P_Right.SuspendLayout();
            this.P_BotttomRight.SuspendLayout();
            this.P_TopRight.SuspendLayout();
            this.P_Left.SuspendLayout();
            this.P_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // TV_Queues
            // 
            this.TV_Queues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Queues.Location = new System.Drawing.Point(0, 0);
            this.TV_Queues.Margin = new System.Windows.Forms.Padding(4);
            this.TV_Queues.Name = "TV_Queues";
            this.TV_Queues.ShowNodeToolTips = true;
            this.TV_Queues.Size = new System.Drawing.Size(287, 503);
            this.TV_Queues.TabIndex = 0;
            this.TV_Queues.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_Queues_NodeMouseClick);
            // 
            // MS_Header
            // 
            this.MS_Header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MS_Header.Location = new System.Drawing.Point(0, 0);
            this.MS_Header.Name = "MS_Header";
            this.MS_Header.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MS_Header.Size = new System.Drawing.Size(1102, 24);
            this.MS_Header.TabIndex = 1;
            this.MS_Header.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // CMS_Queues
            // 
            this.CMS_Queues.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Create,
            this.TSMI_Insert,
            this.TSMI_Purge,
            this.TSMI_Delete});
            this.CMS_Queues.Name = "CMS_Queues";
            this.CMS_Queues.Size = new System.Drawing.Size(217, 92);
            // 
            // TSMI_Create
            // 
            this.TSMI_Create.Name = "TSMI_Create";
            this.TSMI_Create.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.TSMI_Create.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Create.Text = "Create New Queue";
            this.TSMI_Create.Click += new System.EventHandler(this.TSMI_Create_Click);
            // 
            // TSMI_Insert
            // 
            this.TSMI_Insert.Name = "TSMI_Insert";
            this.TSMI_Insert.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.TSMI_Insert.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Insert.Text = "Insert Message";
            // 
            // TSMI_Purge
            // 
            this.TSMI_Purge.Name = "TSMI_Purge";
            this.TSMI_Purge.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.TSMI_Purge.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Purge.Text = "Purge Queue";
            // 
            // TSMI_Delete
            // 
            this.TSMI_Delete.Name = "TSMI_Delete";
            this.TSMI_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.TSMI_Delete.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Delete.Text = "Delete Queue";
            this.TSMI_Delete.Click += new System.EventHandler(this.TSMI_Delete_Click);
            // 
            // messageQueue1
            // 
            this.messageQueue1.DefaultPropertiesToSend.HashAlgorithm = System.Messaging.HashAlgorithm.Sha512;
            this.messageQueue1.MessageReadPropertyFilter.LookupId = true;
            this.messageQueue1.SynchronizingObject = this;
            // 
            // CB_Refresh
            // 
            this.CB_Refresh.AutoSize = true;
            this.CB_Refresh.Checked = true;
            this.CB_Refresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Refresh.Location = new System.Drawing.Point(19, 7);
            this.CB_Refresh.Name = "CB_Refresh";
            this.CB_Refresh.Size = new System.Drawing.Size(101, 18);
            this.CB_Refresh.TabIndex = 2;
            this.CB_Refresh.Text = "Refresh Every";
            this.CB_Refresh.UseVisualStyleBackColor = true;
            // 
            // CBB_Refresh
            // 
            this.CBB_Refresh.FormattingEnabled = true;
            this.CBB_Refresh.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "15"});
            this.CBB_Refresh.Location = new System.Drawing.Point(123, 5);
            this.CBB_Refresh.Name = "CBB_Refresh";
            this.CBB_Refresh.Size = new System.Drawing.Size(50, 22);
            this.CBB_Refresh.TabIndex = 3;
            // 
            // L_Unit
            // 
            this.L_Unit.AutoSize = true;
            this.L_Unit.Location = new System.Drawing.Point(177, 8);
            this.L_Unit.Name = "L_Unit";
            this.L_Unit.Size = new System.Drawing.Size(51, 14);
            this.L_Unit.TabIndex = 4;
            this.L_Unit.Text = "seconds";
            // 
            // P_Top
            // 
            this.P_Top.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.P_Top.Controls.Add(this.P_Right);
            this.P_Top.Controls.Add(this.P_Left);
            this.P_Top.Location = new System.Drawing.Point(0, 23);
            this.P_Top.Name = "P_Top";
            this.P_Top.Size = new System.Drawing.Size(1090, 503);
            this.P_Top.TabIndex = 5;
            // 
            // P_Right
            // 
            this.P_Right.Controls.Add(this.splitter1);
            this.P_Right.Controls.Add(this.P_BotttomRight);
            this.P_Right.Controls.Add(this.P_TopRight);
            this.P_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Right.Location = new System.Drawing.Point(287, 0);
            this.P_Right.Name = "P_Right";
            this.P_Right.Size = new System.Drawing.Size(803, 503);
            this.P_Right.TabIndex = 11;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 220);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(803, 3);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // P_BotttomRight
            // 
            this.P_BotttomRight.Controls.Add(this.textBox1);
            this.P_BotttomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_BotttomRight.Location = new System.Drawing.Point(0, 220);
            this.P_BotttomRight.Name = "P_BotttomRight";
            this.P_BotttomRight.Size = new System.Drawing.Size(803, 283);
            this.P_BotttomRight.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(803, 283);
            this.textBox1.TabIndex = 0;
            // 
            // P_TopRight
            // 
            this.P_TopRight.Controls.Add(this.listView1);
            this.P_TopRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_TopRight.Location = new System.Drawing.Point(0, 0);
            this.P_TopRight.Name = "P_TopRight";
            this.P_TopRight.Size = new System.Drawing.Size(803, 220);
            this.P_TopRight.TabIndex = 10;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(803, 220);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // P_Left
            // 
            this.P_Left.Controls.Add(this.TV_Queues);
            this.P_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.P_Left.Location = new System.Drawing.Point(0, 0);
            this.P_Left.Name = "P_Left";
            this.P_Left.Size = new System.Drawing.Size(287, 503);
            this.P_Left.TabIndex = 10;
            // 
            // P_Bottom
            // 
            this.P_Bottom.Controls.Add(this.CB_Refresh);
            this.P_Bottom.Controls.Add(this.CBB_Refresh);
            this.P_Bottom.Controls.Add(this.L_Unit);
            this.P_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_Bottom.Location = new System.Drawing.Point(0, 529);
            this.P_Bottom.Name = "P_Bottom";
            this.P_Bottom.Size = new System.Drawing.Size(1102, 31);
            this.P_Bottom.TabIndex = 8;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 560);
            this.ContextMenuStrip = this.CMS_Queues;
            this.Controls.Add(this.P_Bottom);
            this.Controls.Add(this.P_Top);
            this.Controls.Add(this.MS_Header);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MS_Header;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueueInator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MS_Header.ResumeLayout(false);
            this.MS_Header.PerformLayout();
            this.CMS_Queues.ResumeLayout(false);
            this.P_Top.ResumeLayout(false);
            this.P_Right.ResumeLayout(false);
            this.P_BotttomRight.ResumeLayout(false);
            this.P_BotttomRight.PerformLayout();
            this.P_TopRight.ResumeLayout(false);
            this.P_Left.ResumeLayout(false);
            this.P_Bottom.ResumeLayout(false);
            this.P_Bottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TV_Queues;
        private System.Windows.Forms.MenuStrip MS_Header;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMS_Queues;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Delete;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Insert;
        private System.Messaging.MessageQueue messageQueue1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Purge;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Create;
        private System.Windows.Forms.ComboBox CBB_Refresh;
        private System.Windows.Forms.CheckBox CB_Refresh;
        private System.Windows.Forms.Label L_Unit;
        private System.Windows.Forms.Panel P_Top;
        private System.Windows.Forms.Panel P_Bottom;
        private System.Windows.Forms.Panel P_Right;
        private System.Windows.Forms.Panel P_BotttomRight;
        private System.Windows.Forms.Panel P_TopRight;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel P_Left;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Splitter splitter1;
    }
}

