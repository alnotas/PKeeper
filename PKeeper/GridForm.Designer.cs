namespace PKeeper
{
   partial class GridForm
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
         if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridForm));
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.chk_timeOut = new System.Windows.Forms.CheckBox();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitPanel = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_renameTab = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_deleteTab = new System.Windows.Forms.Button();
            this.btn_addTab = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_collapse = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btn_expand = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_changePassword = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_saveFile = new System.Windows.Forms.Button();
            this.btn_reloadFile = new System.Windows.Forms.Button();
            this.btn_chooseFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.idleTimer = new System.Windows.Forms.Timer(this.components);
            this.countDownTimer = new System.Windows.Forms.Timer(this.components);
            this.pnl_Top.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).BeginInit();
            this.splitPanel.Panel1.SuspendLayout();
            this.splitPanel.Panel2.SuspendLayout();
            this.splitPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Top
            // 
            this.pnl_Top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Top.Controls.Add(this.chk_timeOut);
            this.pnl_Top.Controls.Add(this.lblTimeLeft);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(955, 25);
            this.pnl_Top.TabIndex = 1;
            // 
            // chk_timeOut
            // 
            this.chk_timeOut.AutoSize = true;
            this.chk_timeOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.chk_timeOut.Location = new System.Drawing.Point(734, 0);
            this.chk_timeOut.Name = "chk_timeOut";
            this.chk_timeOut.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.chk_timeOut.Size = new System.Drawing.Size(119, 21);
            this.chk_timeOut.TabIndex = 12;
            this.chk_timeOut.Text = "Close on timeout |\r\n";
            this.chk_timeOut.UseVisualStyleBackColor = true;
            this.chk_timeOut.CheckedChanged += new System.EventHandler(this.chk_timeOut_CheckedChanged);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTimeLeft.Location = new System.Drawing.Point(853, 0);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblTimeLeft.Size = new System.Drawing.Size(98, 16);
            this.lblTimeLeft.TabIndex = 11;
            this.lblTimeLeft.Text = "Time Remaining 60";
            this.lblTimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 393);
            this.panel2.TabIndex = 2;
            // 
            // splitPanel
            // 
            this.splitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanel.Location = new System.Drawing.Point(0, 0);
            this.splitPanel.Name = "splitPanel";
            // 
            // splitPanel.Panel1
            // 
            this.splitPanel.Panel1.AutoScroll = true;
            this.splitPanel.Panel1.Controls.Add(this.panel3);
            this.splitPanel.Panel1.Controls.Add(this.btn_collapse);
            this.splitPanel.Panel1MinSize = 150;
            // 
            // splitPanel.Panel2
            // 
            this.splitPanel.Panel2.Controls.Add(this.tabControl1);
            this.splitPanel.Panel2.Controls.Add(this.btn_expand);
            this.splitPanel.Size = new System.Drawing.Size(955, 393);
            this.splitPanel.SplitterDistance = 199;
            this.splitPanel.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listBox1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 393);
            this.panel3.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.DisplayMember = "0";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(0, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(185, 361);
            this.listBox1.TabIndex = 1;
            this.listBox1.ValueMember = "0";
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_renameTab);
            this.panel4.Controls.Add(this.btn_deleteTab);
            this.panel4.Controls.Add(this.btn_addTab);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(185, 32);
            this.panel4.TabIndex = 0;
            // 
            // btn_renameTab
            // 
            this.btn_renameTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_renameTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_renameTab.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btn_renameTab.FlatAppearance.BorderSize = 0;
            this.btn_renameTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_renameTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_renameTab.ImageIndex = 7;
            this.btn_renameTab.ImageList = this.imageList1;
            this.btn_renameTab.Location = new System.Drawing.Point(133, 7);
            this.btn_renameTab.Name = "btn_renameTab";
            this.btn_renameTab.Size = new System.Drawing.Size(20, 20);
            this.btn_renameTab.TabIndex = 3;
            this.btn_renameTab.UseVisualStyleBackColor = true;
            this.btn_renameTab.Click += new System.EventHandler(this.btn_renameTab_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "internet.bmp");
            this.imageList1.Images.SetKeyName(1, "copy.bmp");
            this.imageList1.Images.SetKeyName(2, "delete.bmp");
            this.imageList1.Images.SetKeyName(3, "plus.bmp");
            this.imageList1.Images.SetKeyName(4, "open.bmp");
            this.imageList1.Images.SetKeyName(5, "redo.bmp");
            this.imageList1.Images.SetKeyName(6, "save.bmp");
            this.imageList1.Images.SetKeyName(7, "edit.bmp");
            this.imageList1.Images.SetKeyName(8, "Key.bmp");
            this.imageList1.Images.SetKeyName(9, "db delete.bmp");
            this.imageList1.Images.SetKeyName(10, "db insert.bmp");
            // 
            // btn_deleteTab
            // 
            this.btn_deleteTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deleteTab.FlatAppearance.BorderSize = 0;
            this.btn_deleteTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteTab.ImageIndex = 2;
            this.btn_deleteTab.ImageList = this.imageList1;
            this.btn_deleteTab.Location = new System.Drawing.Point(159, 7);
            this.btn_deleteTab.Name = "btn_deleteTab";
            this.btn_deleteTab.Size = new System.Drawing.Size(20, 20);
            this.btn_deleteTab.TabIndex = 2;
            this.btn_deleteTab.UseVisualStyleBackColor = true;
            this.btn_deleteTab.Click += new System.EventHandler(this.btn_deleteTab_Click);
            // 
            // btn_addTab
            // 
            this.btn_addTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_addTab.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btn_addTab.FlatAppearance.BorderSize = 0;
            this.btn_addTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_addTab.ImageIndex = 3;
            this.btn_addTab.ImageList = this.imageList1;
            this.btn_addTab.Location = new System.Drawing.Point(108, 6);
            this.btn_addTab.Name = "btn_addTab";
            this.btn_addTab.Size = new System.Drawing.Size(20, 20);
            this.btn_addTab.TabIndex = 1;
            this.btn_addTab.UseVisualStyleBackColor = true;
            this.btn_addTab.Click += new System.EventHandler(this.btn_addTab_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox1.Location = new System.Drawing.Point(3, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_collapse
            // 
            this.btn_collapse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_collapse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_collapse.Location = new System.Drawing.Point(185, 0);
            this.btn_collapse.Name = "btn_collapse";
            this.btn_collapse.Size = new System.Drawing.Size(14, 393);
            this.btn_collapse.TabIndex = 4;
            this.btn_collapse.Text = "<";
            this.btn_collapse.UseVisualStyleBackColor = true;
            this.btn_collapse.Click += new System.EventHandler(this.btn_collapse_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(14, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(738, 393);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // btn_expand
            // 
            this.btn_expand.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_expand.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_expand.Location = new System.Drawing.Point(0, 0);
            this.btn_expand.Name = "btn_expand";
            this.btn_expand.Size = new System.Drawing.Size(14, 393);
            this.btn_expand.TabIndex = 6;
            this.btn_expand.Text = ">";
            this.btn_expand.UseVisualStyleBackColor = true;
            this.btn_expand.Visible = false;
            this.btn_expand.Click += new System.EventHandler(this.btn_expand_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_changePassword);
            this.panel6.Controls.Add(this.statusStrip1);
            this.panel6.Controls.Add(this.btn_saveFile);
            this.panel6.Controls.Add(this.btn_reloadFile);
            this.panel6.Controls.Add(this.btn_chooseFile);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 418);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(955, 54);
            this.panel6.TabIndex = 3;
            // 
            // btn_changePassword
            // 
            this.btn_changePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_changePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_changePassword.ImageIndex = 8;
            this.btn_changePassword.ImageList = this.imageList1;
            this.btn_changePassword.Location = new System.Drawing.Point(304, 6);
            this.btn_changePassword.Name = "btn_changePassword";
            this.btn_changePassword.Size = new System.Drawing.Size(140, 23);
            this.btn_changePassword.TabIndex = 6;
            this.btn_changePassword.Text = "Change password";
            this.btn_changePassword.UseVisualStyleBackColor = true;
            this.btn_changePassword.Click += new System.EventHandler(this.btn_changePassword_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 32);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(955, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btn_saveFile
            // 
            this.btn_saveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveFile.ImageIndex = 6;
            this.btn_saveFile.ImageList = this.imageList1;
            this.btn_saveFile.Location = new System.Drawing.Point(450, 6);
            this.btn_saveFile.Name = "btn_saveFile";
            this.btn_saveFile.Size = new System.Drawing.Size(140, 23);
            this.btn_saveFile.TabIndex = 2;
            this.btn_saveFile.Text = "Save file";
            this.btn_saveFile.UseVisualStyleBackColor = true;
            this.btn_saveFile.Click += new System.EventHandler(this.btn_saveFile_Click);
            // 
            // btn_reloadFile
            // 
            this.btn_reloadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reloadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reloadFile.ImageIndex = 5;
            this.btn_reloadFile.ImageList = this.imageList1;
            this.btn_reloadFile.Location = new System.Drawing.Point(158, 6);
            this.btn_reloadFile.Name = "btn_reloadFile";
            this.btn_reloadFile.Size = new System.Drawing.Size(140, 23);
            this.btn_reloadFile.TabIndex = 1;
            this.btn_reloadFile.Text = "Reload file";
            this.btn_reloadFile.UseVisualStyleBackColor = true;
            this.btn_reloadFile.Click += new System.EventHandler(this.btn_reloadFile_Click);
            // 
            // btn_chooseFile
            // 
            this.btn_chooseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chooseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_chooseFile.ImageIndex = 4;
            this.btn_chooseFile.ImageList = this.imageList1;
            this.btn_chooseFile.Location = new System.Drawing.Point(12, 6);
            this.btn_chooseFile.Name = "btn_chooseFile";
            this.btn_chooseFile.Size = new System.Drawing.Size(140, 23);
            this.btn_chooseFile.TabIndex = 0;
            this.btn_chooseFile.Text = "Choose file";
            this.btn_chooseFile.UseVisualStyleBackColor = true;
            this.btn_chooseFile.Click += new System.EventHandler(this.btn_chooseFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.DefaultExt = "dat";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Passwords file|*.dat|All files|*.*";
            this.openFileDialog1.Title = "Choose passwords file";
            // 
            // idleTimer
            // 
            this.idleTimer.Interval = 60000;
            this.idleTimer.Tick += new System.EventHandler(this.idleTimer_Tick);
            // 
            // countDownTimer
            // 
            this.countDownTimer.Interval = 400;
            this.countDownTimer.Tick += new System.EventHandler(this.countDownTimer_Tick);
            // 
            // GridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_Top);
            this.Controls.Add(this.panel6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GridForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pkeeper...the next generation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Top.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitPanel.Panel1.ResumeLayout(false);
            this.splitPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).EndInit();
            this.splitPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnl_Top;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Panel panel6;
      private System.Windows.Forms.Button btn_saveFile;
      private System.Windows.Forms.Button btn_reloadFile;
      private System.Windows.Forms.Button btn_chooseFile;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ToolTip toolTip2;
      private System.Windows.Forms.ToolTip toolTip3;
      private System.Windows.Forms.Button btn_changePassword;
      private System.Windows.Forms.Timer idleTimer;
      private System.Windows.Forms.Timer countDownTimer;
      private System.Windows.Forms.Label lblTimeLeft;
      public System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.SplitContainer splitPanel;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Panel panel4;
      private System.Windows.Forms.Button btn_renameTab;
      private System.Windows.Forms.Button btn_deleteTab;
      private System.Windows.Forms.Button btn_addTab;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.Button btn_collapse;
      private System.Windows.Forms.Button btn_expand;
      private System.Windows.Forms.CheckBox chk_timeOut;
   }
}

