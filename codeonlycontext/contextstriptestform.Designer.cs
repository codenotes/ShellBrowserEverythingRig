namespace codeonlycontext
{
    partial class contextstriptestform
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileList1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileList1
            // 
            this.fileList1.AutoSizeColumn = -1;
            this.fileList1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileList1.IsDropTarget = false;
            this.fileList1.Location = new System.Drawing.Point(12, 182);
            this.fileList1.Name = "fileList1";
            this.fileList1.SearchOptions.AccessInterval = null;
            this.fileList1.SearchOptions.CreationInterval = null;
            this.fileList1.SearchOptions.Filter = "";
            this.fileList1.SearchOptions.FilterRegex = null;
            this.fileList1.SearchOptions.LastWriteInterval = null;
            this.fileList1.SearchOptions.MaxFileSize = ((long)(9223372036854775807));
            this.fileList1.SearchOptions.MinFileSize = ((long)(0));
            this.fileList1.SearchOptions.RecursiveSearch = true;
            this.fileList1.SearchOptions.RegexPattern = "";
            this.fileList1.ShowColorCompressed = System.Drawing.Color.Empty;
            this.fileList1.ShowColorEncrypted = System.Drawing.Color.Empty;
            this.fileList1.Size = new System.Drawing.Size(452, 200);
            this.fileList1.TabIndex = 1;
            this.fileList1.ThumbnailBorderColor = System.Drawing.Color.LightGray;
            this.fileList1.ThumbnailSize = new System.Drawing.Size(96, 96);
            this.fileList1.UseCompatibleStateImageBehavior = false;
            this.fileList1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.fileList1_DrawColumnHeader);
            this.fileList1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.fileList1_DrawItem);
            this.fileList1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.fileList1_DrawSubItem);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "tstt";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(353, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(189, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 6;
            // 
            // contextstriptestform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 394);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileList1);
            this.Name = "contextstriptestform";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Jam.Shell.FileList fileList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
    }
}

