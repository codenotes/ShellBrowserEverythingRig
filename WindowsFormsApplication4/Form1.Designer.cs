namespace WindowsFormsApplication4
{
    partial class Form1
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
            this.fileList1 = new Jam.Shell.FileList();
            this.button1 = new System.Windows.Forms.Button();
            this.shellControlConnector1 = new Jam.Shell.ShellControlConnector();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.oneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fileList1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileList1
            // 
            this.fileList1.AutoSizeColumn = -1;
            this.fileList1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileList1.IsDropTarget = false;
            this.fileList1.Location = new System.Drawing.Point(12, 12);
            this.fileList1.Name = "fileList1";
            this.fileList1.SearchOptions.AccessInterval = null;
            this.fileList1.SearchOptions.CreationInterval = null;
            this.fileList1.SearchOptions.FilterRegex = null;
            this.fileList1.SearchOptions.LastWriteInterval = null;
            this.fileList1.SearchOptions.MaxFileSize = ((long)(9223372036854775807));
            this.fileList1.SearchOptions.MinFileSize = ((long)(0));
            this.fileList1.SearchOptions.RecursiveSearch = true;
            this.fileList1.SearchOptions.RegexPattern = "";
            this.fileList1.ShowColorCompressed = System.Drawing.Color.Empty;
            this.fileList1.ShowColorEncrypted = System.Drawing.Color.Empty;
            this.fileList1.Size = new System.Drawing.Size(247, 200);
            this.fileList1.TabIndex = 0;
            this.fileList1.ThumbnailBorderColor = System.Drawing.Color.LightGray;
            this.fileList1.ThumbnailSize = new System.Drawing.Size(96, 96);
            this.fileList1.UseCompatibleStateImageBehavior = false;
            this.fileList1.SelectedIndexChanged += new System.EventHandler(this.fileList1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shellControlConnector1
            // 
            this.shellControlConnector1.Enabled = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneToolStripMenuItem,
            this.threeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // oneToolStripMenuItem
            // 
            this.oneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twoToolStripMenuItem});
            this.oneToolStripMenuItem.Name = "oneToolStripMenuItem";
            this.oneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oneToolStripMenuItem.Text = "one";
            // 
            // twoToolStripMenuItem
            // 
            this.twoToolStripMenuItem.Name = "twoToolStripMenuItem";
            this.twoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.twoToolStripMenuItem.Text = "two";
            // 
            // threeToolStripMenuItem
            // 
            this.threeToolStripMenuItem.Name = "threeToolStripMenuItem";
            this.threeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.threeToolStripMenuItem.Text = "three";
            this.threeToolStripMenuItem.Click += new System.EventHandler(this.threeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 282);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileList1);
            this.Name = "Form1";
            this.Text = "il";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileList1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Jam.Shell.FileList fileList1;
        private System.Windows.Forms.Button button1;
        private Jam.Shell.ShellControlConnector shellControlConnector1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeToolStripMenuItem;

    }
}

