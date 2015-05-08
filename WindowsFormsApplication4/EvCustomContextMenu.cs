using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;


namespace EvMenu
{
    public delegate void MenuStripCallback(object sender);

    class EvCustomContextMenu
    {

          public enum ShowCommands : int
    {
        SW_HIDE = 0,
        SW_SHOWNORMAL = 1,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11,
        SW_MAX = 11
    }

    [DllImport("shell32.dll")]
   public static extern IntPtr ShellExecute(
        IntPtr hwnd,
        string lpOperation,
        string lpFile,
        string lpParameters,
        string lpDirectory,
        ShowCommands nShowCmd);
      
       
        private MenuStripCallback [] cbMenuArray=new MenuStripCallback[5]{null,null,null,null,null};

        private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        private Form cbForm;

         public EvCustomContextMenu()
        {
            contextMenuStrip1 = new ContextMenuStrip();
            oneToolStripMenuItem = new ToolStripMenuItem();
            twoToolStripMenuItem = new ToolStripMenuItem();
            threeToolStripMenuItem = new ToolStripMenuItem();

            InitMenu();

        }

        public void SetHandler(int menuitem, MenuStripCallback d)
        {
            cbMenuArray[menuitem] = d;


        }

        public void InitMenu()
        {


            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
            this.oneToolStripMenuItem,
            this.threeToolStripMenuItem
            });

            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            //this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            //this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
 //           this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
   //         this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // oneToolStripMenuItem

            //this.oneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] 
            //{
            //this.twoToolStripMenuItem});

            this.oneToolStripMenuItem.Name = "oneToolStripMenuItem";
            this.oneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oneToolStripMenuItem.Text = "Copy Full Name To Clipboard";
            this.oneToolStripMenuItem.Click += new System.EventHandler(this.CopyClipboard);
            // 


            //this.twoToolStripMenuItem.Name = "twoToolStripMenuItem";
            //this.twoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            //this.twoToolStripMenuItem.Text = "two";
            // 
            // threeToolStripMenuItem
            // 
            this.threeToolStripMenuItem.Name = "threeToolStripMenuItem";
            this.threeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.threeToolStripMenuItem.Text = "Open Path";
         //   this.threeToolStripMenuItem.Click += new System.EventHandler(this.threeToolStripMenuItem_Click);
            this.threeToolStripMenuItem.Click += new System.EventHandler(this.OpenPath);
            // 
            // Form1

        }

              private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
          //  Console.WriteLine("opening");


        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("df");
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //ToolStripItem item = e.ClickedItem;
            //Console.WriteLine("itemclicked");
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
           // Console.WriteLine("closed");
        }

   //     private void threeToolStripMenuItem_Click(object sender, EventArgs e)

        private void CopyClipboard(object sender, EventArgs e)
        {
            Console.WriteLine("clipboard");

            if (cbMenuArray[0] == null) return;

            cbMenuArray[0](null);

        }
        
        private void OpenPath(object sender, EventArgs e)
        {

            if (cbMenuArray[1] == null) return;
          
          //  Console.WriteLine("open path");
                
                cbMenuArray[1](null);
                


                //ShellExecute(IntPtr.Zero, "open", "explorer.exe", "c:\\temp", "", ShowCommands.SW_NORMAL);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


    }
}
