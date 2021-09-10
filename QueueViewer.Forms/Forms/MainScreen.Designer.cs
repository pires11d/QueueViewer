
namespace QueueViewer.Forms
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
            this.MS_Header = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS_Queues = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_Expand = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Collapse = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Splitter = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Purge = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.CB_Refresh = new System.Windows.Forms.CheckBox();
            this.CBB_Refresh = new System.Windows.Forms.ComboBox();
            this.L_Unit = new System.Windows.Forms.Label();
            this.P_Top = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.P_Right = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.P_BotttomRight = new System.Windows.Forms.Panel();
            this.TC_Message = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TB_MessageBody = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TB_MessageExtension = new System.Windows.Forms.TextBox();
            this.P_TopRight = new System.Windows.Forms.Panel();
            this.P_CenterTopRight = new System.Windows.Forms.Panel();
            this.LV_Messages = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.P_BottomTopRight = new System.Windows.Forms.Panel();
            this.BTN_Prev = new System.Windows.Forms.Button();
            this.BTN_Next = new System.Windows.Forms.Button();
            this.P_TopTopRight = new System.Windows.Forms.Panel();
            this.LB_MaxMessages = new System.Windows.Forms.Label();
            this.CBB_MaxMessages = new System.Windows.Forms.ComboBox();
            this.BTN_RefreshMessages = new System.Windows.Forms.Button();
            this.P_Left = new System.Windows.Forms.Panel();
            this.P_BottomLeft = new System.Windows.Forms.Panel();
            this.TV_Queues = new System.Windows.Forms.TreeView();
            this.P_TopLeft = new System.Windows.Forms.Panel();
            this.BTN_RefreshQueues = new System.Windows.Forms.Button();
            this.P_Bottom = new System.Windows.Forms.Panel();
            this.T_Refresh = new System.Windows.Forms.Timer(this.components);
            this.CMS_Messages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_Reprocess = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Header.SuspendLayout();
            this.CMS_Queues.SuspendLayout();
            this.P_Top.SuspendLayout();
            this.P_Right.SuspendLayout();
            this.P_BotttomRight.SuspendLayout();
            this.TC_Message.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.P_TopRight.SuspendLayout();
            this.P_CenterTopRight.SuspendLayout();
            this.P_BottomTopRight.SuspendLayout();
            this.P_TopTopRight.SuspendLayout();
            this.P_Left.SuspendLayout();
            this.P_BottomLeft.SuspendLayout();
            this.P_TopLeft.SuspendLayout();
            this.P_Bottom.SuspendLayout();
            this.CMS_Messages.SuspendLayout();
            this.SuspendLayout();
            // 
            // MS_Header
            // 
            this.MS_Header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.MS_Header.Location = new System.Drawing.Point(0, 0);
            this.MS_Header.Name = "MS_Header";
            this.MS_Header.Size = new System.Drawing.Size(1017, 24);
            this.MS_Header.TabIndex = 1;
            this.MS_Header.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // CMS_Queues
            // 
            this.CMS_Queues.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Expand,
            this.TSMI_Collapse,
            this.TSMI_Splitter,
            this.TSMI_Create,
            this.TSMI_Insert,
            this.TSMI_Purge,
            this.TSMI_Delete});
            this.CMS_Queues.Name = "CMS_Queues";
            this.CMS_Queues.Size = new System.Drawing.Size(217, 142);
            this.CMS_Queues.Opening += new System.ComponentModel.CancelEventHandler(this.CMS_Queues_Opening);
            // 
            // TSMI_Expand
            // 
            this.TSMI_Expand.Name = "TSMI_Expand";
            this.TSMI_Expand.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D0)));
            this.TSMI_Expand.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Expand.Text = "Expand";
            this.TSMI_Expand.Click += new System.EventHandler(this.TSMI_Expand_Click);
            // 
            // TSMI_Collapse
            // 
            this.TSMI_Collapse.Name = "TSMI_Collapse";
            this.TSMI_Collapse.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.TSMI_Collapse.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Collapse.Text = "Collapse";
            this.TSMI_Collapse.Click += new System.EventHandler(this.TSMI_Collapse_Click);
            // 
            // TSMI_Splitter
            // 
            this.TSMI_Splitter.Name = "TSMI_Splitter";
            this.TSMI_Splitter.Size = new System.Drawing.Size(213, 6);
            // 
            // TSMI_Create
            // 
            this.TSMI_Create.Enabled = false;
            this.TSMI_Create.Name = "TSMI_Create";
            this.TSMI_Create.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.TSMI_Create.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Create.Text = "Create New Queue";
            this.TSMI_Create.Click += new System.EventHandler(this.TSMI_Create_Click);
            // 
            // TSMI_Insert
            // 
            this.TSMI_Insert.Enabled = false;
            this.TSMI_Insert.Name = "TSMI_Insert";
            this.TSMI_Insert.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.TSMI_Insert.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Insert.Text = "Insert Message";
            this.TSMI_Insert.Click += new System.EventHandler(this.TSMI_Insert_Click);
            // 
            // TSMI_Purge
            // 
            this.TSMI_Purge.Enabled = false;
            this.TSMI_Purge.Name = "TSMI_Purge";
            this.TSMI_Purge.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.TSMI_Purge.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Purge.Text = "Purge Queue";
            this.TSMI_Purge.Click += new System.EventHandler(this.TSMI_Purge_Click);
            // 
            // TSMI_Delete
            // 
            this.TSMI_Delete.Enabled = false;
            this.TSMI_Delete.Name = "TSMI_Delete";
            this.TSMI_Delete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.TSMI_Delete.Size = new System.Drawing.Size(216, 22);
            this.TSMI_Delete.Text = "Delete Queue";
            this.TSMI_Delete.Click += new System.EventHandler(this.TSMI_Delete_Click);
            // 
            // CB_Refresh
            // 
            this.CB_Refresh.AutoSize = true;
            this.CB_Refresh.Location = new System.Drawing.Point(16, 6);
            this.CB_Refresh.Name = "CB_Refresh";
            this.CB_Refresh.Size = new System.Drawing.Size(95, 17);
            this.CB_Refresh.TabIndex = 2;
            this.CB_Refresh.Text = "Refresh Every";
            this.CB_Refresh.UseVisualStyleBackColor = true;
            this.CB_Refresh.CheckedChanged += new System.EventHandler(this.CB_Refresh_CheckedChanged);
            // 
            // CBB_Refresh
            // 
            this.CBB_Refresh.FormattingEnabled = true;
            this.CBB_Refresh.Items.AddRange(new object[] {
            "2",
            "5",
            "10",
            "15",
            "30"});
            this.CBB_Refresh.Location = new System.Drawing.Point(117, 4);
            this.CBB_Refresh.Name = "CBB_Refresh";
            this.CBB_Refresh.Size = new System.Drawing.Size(43, 21);
            this.CBB_Refresh.TabIndex = 3;
            this.CBB_Refresh.SelectedIndexChanged += new System.EventHandler(this.CBB_Refresh_SelectedIndexChanged);
            // 
            // L_Unit
            // 
            this.L_Unit.AutoSize = true;
            this.L_Unit.Location = new System.Drawing.Point(164, 6);
            this.L_Unit.Name = "L_Unit";
            this.L_Unit.Size = new System.Drawing.Size(46, 13);
            this.L_Unit.TabIndex = 4;
            this.L_Unit.Text = "seconds";
            // 
            // P_Top
            // 
            this.P_Top.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.P_Top.Controls.Add(this.splitter2);
            this.P_Top.Controls.Add(this.P_Right);
            this.P_Top.Controls.Add(this.P_Left);
            this.P_Top.Location = new System.Drawing.Point(0, 21);
            this.P_Top.Name = "P_Top";
            this.P_Top.Size = new System.Drawing.Size(1006, 566);
            this.P_Top.TabIndex = 5;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(364, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 566);
            this.splitter2.TabIndex = 12;
            this.splitter2.TabStop = false;
            // 
            // P_Right
            // 
            this.P_Right.Controls.Add(this.splitter1);
            this.P_Right.Controls.Add(this.P_BotttomRight);
            this.P_Right.Controls.Add(this.P_TopRight);
            this.P_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Right.Location = new System.Drawing.Point(364, 0);
            this.P_Right.Name = "P_Right";
            this.P_Right.Size = new System.Drawing.Size(642, 566);
            this.P_Right.TabIndex = 11;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 336);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(642, 3);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // P_BotttomRight
            // 
            this.P_BotttomRight.Controls.Add(this.TC_Message);
            this.P_BotttomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_BotttomRight.Location = new System.Drawing.Point(0, 336);
            this.P_BotttomRight.Name = "P_BotttomRight";
            this.P_BotttomRight.Size = new System.Drawing.Size(642, 230);
            this.P_BotttomRight.TabIndex = 11;
            // 
            // TC_Message
            // 
            this.TC_Message.Controls.Add(this.tabPage1);
            this.TC_Message.Controls.Add(this.tabPage2);
            this.TC_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Message.ItemSize = new System.Drawing.Size(90, 30);
            this.TC_Message.Location = new System.Drawing.Point(0, 0);
            this.TC_Message.Name = "TC_Message";
            this.TC_Message.SelectedIndex = 0;
            this.TC_Message.Size = new System.Drawing.Size(642, 230);
            this.TC_Message.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TC_Message.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TB_MessageBody);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(634, 192);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Body";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TB_MessageBody
            // 
            this.TB_MessageBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_MessageBody.Location = new System.Drawing.Point(3, 3);
            this.TB_MessageBody.Multiline = true;
            this.TB_MessageBody.Name = "TB_MessageBody";
            this.TB_MessageBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_MessageBody.Size = new System.Drawing.Size(628, 186);
            this.TB_MessageBody.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TB_MessageExtension);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(634, 126);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Extension";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TB_MessageExtension
            // 
            this.TB_MessageExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_MessageExtension.Location = new System.Drawing.Point(3, 3);
            this.TB_MessageExtension.Multiline = true;
            this.TB_MessageExtension.Name = "TB_MessageExtension";
            this.TB_MessageExtension.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_MessageExtension.Size = new System.Drawing.Size(628, 120);
            this.TB_MessageExtension.TabIndex = 1;
            // 
            // P_TopRight
            // 
            this.P_TopRight.Controls.Add(this.P_CenterTopRight);
            this.P_TopRight.Controls.Add(this.P_BottomTopRight);
            this.P_TopRight.Controls.Add(this.P_TopTopRight);
            this.P_TopRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_TopRight.Location = new System.Drawing.Point(0, 0);
            this.P_TopRight.Name = "P_TopRight";
            this.P_TopRight.Size = new System.Drawing.Size(642, 336);
            this.P_TopRight.TabIndex = 10;
            // 
            // P_CenterTopRight
            // 
            this.P_CenterTopRight.Controls.Add(this.LV_Messages);
            this.P_CenterTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_CenterTopRight.Location = new System.Drawing.Point(0, 27);
            this.P_CenterTopRight.Name = "P_CenterTopRight";
            this.P_CenterTopRight.Size = new System.Drawing.Size(642, 282);
            this.P_CenterTopRight.TabIndex = 2;
            // 
            // LV_Messages
            // 
            this.LV_Messages.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LV_Messages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.LV_Messages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Messages.FullRowSelect = true;
            this.LV_Messages.GridLines = true;
            this.LV_Messages.HideSelection = false;
            this.LV_Messages.Location = new System.Drawing.Point(0, 0);
            this.LV_Messages.Name = "LV_Messages";
            this.LV_Messages.Size = new System.Drawing.Size(642, 282);
            this.LV_Messages.TabIndex = 0;
            this.LV_Messages.UseCompatibleStateImageBehavior = false;
            this.LV_Messages.View = System.Windows.Forms.View.Details;
            this.LV_Messages.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LV_Messages_ColumnClick);
            this.LV_Messages.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LV_Messages_ItemDrag);
            this.LV_Messages.SelectedIndexChanged += new System.EventHandler(this.LV_Messages_SelectedIndexChanged);
            this.LV_Messages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_Messages_KeyDown);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MessageId";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Creation Time";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Response Queue";
            this.columnHeader4.Width = 123;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Body Content";
            this.columnHeader5.Width = 129;
            // 
            // P_BottomTopRight
            // 
            this.P_BottomTopRight.BackColor = System.Drawing.SystemColors.ControlLight;
            this.P_BottomTopRight.Controls.Add(this.BTN_Prev);
            this.P_BottomTopRight.Controls.Add(this.BTN_Next);
            this.P_BottomTopRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_BottomTopRight.Location = new System.Drawing.Point(0, 309);
            this.P_BottomTopRight.Name = "P_BottomTopRight";
            this.P_BottomTopRight.Size = new System.Drawing.Size(642, 27);
            this.P_BottomTopRight.TabIndex = 2;
            // 
            // BTN_Prev
            // 
            this.BTN_Prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_Prev.Location = new System.Drawing.Point(3, 0);
            this.BTN_Prev.Name = "BTN_Prev";
            this.BTN_Prev.Size = new System.Drawing.Size(76, 26);
            this.BTN_Prev.TabIndex = 1;
            this.BTN_Prev.Text = "<<";
            this.BTN_Prev.UseVisualStyleBackColor = true;
            this.BTN_Prev.Click += new System.EventHandler(this.BTN_Prev_Click);
            // 
            // BTN_Next
            // 
            this.BTN_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Next.Location = new System.Drawing.Point(565, 0);
            this.BTN_Next.Name = "BTN_Next";
            this.BTN_Next.Size = new System.Drawing.Size(76, 26);
            this.BTN_Next.TabIndex = 0;
            this.BTN_Next.Text = ">>";
            this.BTN_Next.UseVisualStyleBackColor = true;
            this.BTN_Next.Click += new System.EventHandler(this.BTN_Next_Click);
            // 
            // P_TopTopRight
            // 
            this.P_TopTopRight.BackColor = System.Drawing.SystemColors.ControlLight;
            this.P_TopTopRight.Controls.Add(this.LB_MaxMessages);
            this.P_TopTopRight.Controls.Add(this.CBB_MaxMessages);
            this.P_TopTopRight.Controls.Add(this.BTN_RefreshMessages);
            this.P_TopTopRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_TopTopRight.Location = new System.Drawing.Point(0, 0);
            this.P_TopTopRight.Name = "P_TopTopRight";
            this.P_TopTopRight.Size = new System.Drawing.Size(642, 27);
            this.P_TopTopRight.TabIndex = 1;
            // 
            // LB_MaxMessages
            // 
            this.LB_MaxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_MaxMessages.AutoSize = true;
            this.LB_MaxMessages.Location = new System.Drawing.Point(538, 6);
            this.LB_MaxMessages.Name = "LB_MaxMessages";
            this.LB_MaxMessages.Size = new System.Drawing.Size(33, 13);
            this.LB_MaxMessages.TabIndex = 5;
            this.LB_MaxMessages.Text = "Show";
            // 
            // CBB_MaxMessages
            // 
            this.CBB_MaxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBB_MaxMessages.FormattingEnabled = true;
            this.CBB_MaxMessages.Items.AddRange(new object[] {
            "50",
            "100",
            "1000",
            "All"});
            this.CBB_MaxMessages.Location = new System.Drawing.Point(577, 3);
            this.CBB_MaxMessages.Name = "CBB_MaxMessages";
            this.CBB_MaxMessages.Size = new System.Drawing.Size(58, 21);
            this.CBB_MaxMessages.TabIndex = 4;
            this.CBB_MaxMessages.SelectedIndexChanged += new System.EventHandler(this.CBB_MaxMessages_SelectedIndexChanged);
            // 
            // BTN_RefreshMessages
            // 
            this.BTN_RefreshMessages.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_RefreshMessages.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_RefreshMessages.ForeColor = System.Drawing.Color.Green;
            this.BTN_RefreshMessages.Location = new System.Drawing.Point(3, 0);
            this.BTN_RefreshMessages.Name = "BTN_RefreshMessages";
            this.BTN_RefreshMessages.Size = new System.Drawing.Size(32, 27);
            this.BTN_RefreshMessages.TabIndex = 2;
            this.BTN_RefreshMessages.Text = "⟳";
            this.BTN_RefreshMessages.UseVisualStyleBackColor = false;
            this.BTN_RefreshMessages.Click += new System.EventHandler(this.BTN_RefreshMessages_Click);
            // 
            // P_Left
            // 
            this.P_Left.Controls.Add(this.P_BottomLeft);
            this.P_Left.Controls.Add(this.P_TopLeft);
            this.P_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.P_Left.Location = new System.Drawing.Point(0, 0);
            this.P_Left.Name = "P_Left";
            this.P_Left.Size = new System.Drawing.Size(364, 566);
            this.P_Left.TabIndex = 10;
            // 
            // P_BottomLeft
            // 
            this.P_BottomLeft.Controls.Add(this.TV_Queues);
            this.P_BottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_BottomLeft.Location = new System.Drawing.Point(0, 27);
            this.P_BottomLeft.Name = "P_BottomLeft";
            this.P_BottomLeft.Size = new System.Drawing.Size(364, 539);
            this.P_BottomLeft.TabIndex = 3;
            // 
            // TV_Queues
            // 
            this.TV_Queues.AllowDrop = true;
            this.TV_Queues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Queues.Location = new System.Drawing.Point(0, 0);
            this.TV_Queues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TV_Queues.Name = "TV_Queues";
            this.TV_Queues.ShowNodeToolTips = true;
            this.TV_Queues.Size = new System.Drawing.Size(364, 539);
            this.TV_Queues.TabIndex = 0;
            this.TV_Queues.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_Queues_NodeMouseClick);
            this.TV_Queues.DragDrop += new System.Windows.Forms.DragEventHandler(this.TV_Queues_DragDrop);
            this.TV_Queues.DragEnter += new System.Windows.Forms.DragEventHandler(this.TV_Queues_DragEnter);
            this.TV_Queues.DragOver += new System.Windows.Forms.DragEventHandler(this.TV_Queues_DragOver);
            this.TV_Queues.DragLeave += new System.EventHandler(this.TV_Queues_DragLeave);
            // 
            // P_TopLeft
            // 
            this.P_TopLeft.BackColor = System.Drawing.SystemColors.ControlLight;
            this.P_TopLeft.Controls.Add(this.BTN_RefreshQueues);
            this.P_TopLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_TopLeft.Location = new System.Drawing.Point(0, 0);
            this.P_TopLeft.Name = "P_TopLeft";
            this.P_TopLeft.Size = new System.Drawing.Size(364, 27);
            this.P_TopLeft.TabIndex = 2;
            // 
            // BTN_RefreshQueues
            // 
            this.BTN_RefreshQueues.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_RefreshQueues.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_RefreshQueues.ForeColor = System.Drawing.Color.Green;
            this.BTN_RefreshQueues.Location = new System.Drawing.Point(0, 0);
            this.BTN_RefreshQueues.Name = "BTN_RefreshQueues";
            this.BTN_RefreshQueues.Size = new System.Drawing.Size(32, 27);
            this.BTN_RefreshQueues.TabIndex = 5;
            this.BTN_RefreshQueues.Text = "⟳";
            this.BTN_RefreshQueues.UseVisualStyleBackColor = false;
            this.BTN_RefreshQueues.Click += new System.EventHandler(this.BTN_RefreshQueues_Click);
            // 
            // P_Bottom
            // 
            this.P_Bottom.Controls.Add(this.CB_Refresh);
            this.P_Bottom.Controls.Add(this.CBB_Refresh);
            this.P_Bottom.Controls.Add(this.L_Unit);
            this.P_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_Bottom.Location = new System.Drawing.Point(0, 590);
            this.P_Bottom.Name = "P_Bottom";
            this.P_Bottom.Size = new System.Drawing.Size(1017, 29);
            this.P_Bottom.TabIndex = 8;
            // 
            // T_Refresh
            // 
            this.T_Refresh.Tick += new System.EventHandler(this.T_Refresh_Tick);
            // 
            // CMS_Messages
            // 
            this.CMS_Messages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Reprocess});
            this.CMS_Messages.Name = "CMS_Messages";
            this.CMS_Messages.Size = new System.Drawing.Size(169, 26);
            this.CMS_Messages.Opening += new System.ComponentModel.CancelEventHandler(this.CMS_Messages_Opening);
            // 
            // TSMI_Reprocess
            // 
            this.TSMI_Reprocess.Name = "TSMI_Reprocess";
            this.TSMI_Reprocess.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.TSMI_Reprocess.Size = new System.Drawing.Size(168, 22);
            this.TSMI_Reprocess.Text = "Reprocess";
            this.TSMI_Reprocess.Click += new System.EventHandler(this.TSMI_Reprocess_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 619);
            this.ContextMenuStrip = this.CMS_Queues;
            this.Controls.Add(this.P_Bottom);
            this.Controls.Add(this.P_Top);
            this.Controls.Add(this.MS_Header);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MS_Header;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My QueueViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.MS_Header.ResumeLayout(false);
            this.MS_Header.PerformLayout();
            this.CMS_Queues.ResumeLayout(false);
            this.P_Top.ResumeLayout(false);
            this.P_Right.ResumeLayout(false);
            this.P_BotttomRight.ResumeLayout(false);
            this.TC_Message.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.P_TopRight.ResumeLayout(false);
            this.P_CenterTopRight.ResumeLayout(false);
            this.P_BottomTopRight.ResumeLayout(false);
            this.P_TopTopRight.ResumeLayout(false);
            this.P_TopTopRight.PerformLayout();
            this.P_Left.ResumeLayout(false);
            this.P_BottomLeft.ResumeLayout(false);
            this.P_TopLeft.ResumeLayout(false);
            this.P_Bottom.ResumeLayout(false);
            this.P_Bottom.PerformLayout();
            this.CMS_Messages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MS_Header;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMS_Queues;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Delete;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Insert;
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
        private System.Windows.Forms.ListView LV_Messages;
        private System.Windows.Forms.Panel P_Left;
        private System.Windows.Forms.TextBox TB_MessageBody;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TreeView TV_Queues;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TabControl TC_Message;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TB_MessageExtension;
        private System.Windows.Forms.Timer T_Refresh;
        private System.Windows.Forms.Panel P_TopTopRight;
        private System.Windows.Forms.Panel P_CenterTopRight;
        private System.Windows.Forms.Panel P_BottomLeft;
        private System.Windows.Forms.Panel P_TopLeft;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Expand;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Collapse;
        private System.Windows.Forms.ToolStripSeparator TSMI_Splitter;
        private System.Windows.Forms.ContextMenuStrip CMS_Messages;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Reprocess;
        private System.Windows.Forms.Panel P_BottomTopRight;
        private System.Windows.Forms.Button BTN_Next;
        private System.Windows.Forms.Button BTN_Prev;
        private System.Windows.Forms.Button BTN_RefreshMessages;
        private System.Windows.Forms.Button BTN_RefreshQueues;
        private System.Windows.Forms.Label LB_MaxMessages;
        private System.Windows.Forms.ComboBox CBB_MaxMessages;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

