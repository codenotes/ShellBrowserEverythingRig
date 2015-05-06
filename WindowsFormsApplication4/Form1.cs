using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        ContextMenuStrip cm = new ContextMenuStrip();
        public Form1()
        {
            InitializeComponent();
            fileList1.ContextMenuStrip = contextMenuStrip1;

            contextMenuStrip1.ItemClicked += (sender, e) =>
        {
            Console.WriteLine("dybb");
        };

        //    contextMenuStrip1.Click += new EventHandler(fuck);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileList1.ShellControlConnector = shellControlConnector1;

            fileList1.Add("c:\\temp\\test.xml");
            fileList1.Add("c:\\temp\\test2.xml");


       //     fileList1.CheckBoxes = true;
                    

           

         
        }

        private void fuck(object sender, EventArgs e)
        {
            Console.WriteLine("fyj");
        }

        private void fileList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = fileList1.SelectedItems;

            fileList21.Add("c:\\temp\\test.xml");

            foreach(var x in p)
            {
                Console.WriteLine(x.ToString());

            }


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Console.WriteLine("opening");


        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("df");
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            Console.WriteLine("itemclicked");
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            Console.WriteLine("closed");
        }

        private void threeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("three");
        }

        private void fileList21_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
