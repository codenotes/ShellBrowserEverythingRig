using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Everything;

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

 
        private void fileList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {


            fileList21.Clear();

            int i;
            const int bufsize = 260;
            StringBuilder buf = new StringBuilder(bufsize);
            StringBuilder buf2 = new StringBuilder();


            // set the search
            EverythingSearch.Everything_SetSearchW(textBox1.Text);

            fileList21.SearchTerm = textBox1.Text;


            // use our own custom scrollbar... 			
            // Everything_SetMax(listBox1.ClientRectangle.Height / listBox1.ItemHeight);
            // Everything_SetOffset(VerticalScrollBarPosition...);

            // execute the query
            EverythingSearch.Everything_QueryW(true);


            Text = textBox1.Text + " - " + EverythingSearch.Everything_GetNumResults() + " Results";

            var results = EverythingSearch.Everything_GetNumResults();

            string[] l = new string[results];

            // loop through the results, adding each result to the listbox.

            for (i = 0; i < results; i++)
            {
                // get the result's full path and file name.
                EverythingSearch.Everything_GetResultFullPathNameW(i, buf, bufsize);
                //    fileList1.Add(buf.ToString());

                l[i] = buf.ToString();

                //buf2.Append(buf);
                //buf2.Append(";");

                // add it to the list box				
                //       listBox1.Items.Insert(i, buf);
            }


            fileList21.AddStrings(l);

           






            //var p = fileList1.SelectedItems;

            //fileList21.Add("c:\\temp\\test.xml");

            //foreach(var x in p)
            //{
            //    Console.WriteLine(x.ToString());

            //}

            //fileList21.getVisible();

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
