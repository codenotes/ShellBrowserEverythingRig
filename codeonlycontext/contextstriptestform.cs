using Everything;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using EvMenu;
using System.Drawing;
using System.Data;
using Etier.IconHelper;
using System.Collections.Generic;
using System.IO;

namespace codeonlycontext
{
    public partial class contextstriptestform : Form
    {
         private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeToolStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
       
        public contextstriptestform()
        {
            InitializeComponent();

            contextMenuStrip1 = new ContextMenuStrip();
            oneToolStripMenuItem = new ToolStripMenuItem();
            twoToolStripMenuItem = new ToolStripMenuItem();
            threeToolStripMenuItem = new ToolStripMenuItem();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
        

                
                
                
                //fileList1.Add("c:\\temp\\test.xml");
            this.AcceptButton = button1;

            var ev = new EvMenu.EvCustomContextMenu();
            //ev.InitMenu();

            fileList1.ContextMenuStrip = ev.contextMenuStrip1;
            ev.SetHandler(0, new EvMenu.MenuStripCallback(CopyClipboard));
            ev.SetHandler(1, new EvMenu.MenuStripCallback(OpenPath));

            //fileList1.ContextMenuStrip = contextMenuStrip1;


            textBox1.Focus();
            
        

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
            var x = fileList1.SelectedItems;
            
           
            foreach(Jam.Shell.FileListItem f  in x)
            {

                Console.WriteLine(f.FullPath);
                
                
                


            }
        }


        private void mouseclick(object sender, EventArgs e)
        {

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            fileList1.Refresh();


        }
        bool isDir(string s)
        {


            System.IO.FileAttributes attr = System.IO.File.GetAttributes(s);

            //detect whether its a directory or file
            if (attr.HasFlag(System.IO.FileAttributes.Directory))
                return true;
            else
                return false;

        }


        public void CopyClipboard(object data)
        {
            //Console.WriteLine("copy clipboard called.");
           
            var f = fileList1.SelectedItems;
            string s = "";

            foreach(Jam.Shell.FileListItem x in f)
            {
                s = s + x.Path+";";
            }

            s=s.Substring(0, s.Length - 1);
            Clipboard.SetText(s);

        }

        //used by delegate
        public void OpenPath(object data)
        {

            var d = System.IO.Path.GetDirectoryName(fileList1.SelectedItems[0].Path);
            EvMenu.EvCustomContextMenu.ShellExecute(IntPtr.Zero, "open", "explorer.exe", d, "", EvMenu.EvCustomContextMenu.ShowCommands.SW_NORMAL);

        }

        public void OpenPath(object sender, EventArgs e)
        {


            EvMenu.EvCustomContextMenu.ShellExecute(IntPtr.Zero, "open", "explorer.exe", "c:\\temp", "", EvMenu.EvCustomContextMenu.ShowCommands.SW_NORMAL);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            fileList1.Clear();
            fileList1.BeginUpdate();

            



           
            int i;
            const int bufsize = 260;
            StringBuilder buf = new StringBuilder(bufsize);
            StringBuilder buf2 = new StringBuilder();


            // set the search
            EverythingSearch.Everything_SetSearchW(textBox1.Text);

            // use our own custom scrollbar... 			
            // Everything_SetMax(listBox1.ClientRectangle.Height / listBox1.ItemHeight);
            // Everything_SetOffset(VerticalScrollBarPosition...);

            // execute the query
            EverythingSearch.Everything_QueryW(true);

            // sort by path
            // Everything_SortResultsByPath();

            // clear the old list of results			
            //listBox1.Items.Clear();

            // set the window title
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
            
            
            fileList1.AddStrings(l);
            //foreach (var s  in l)
            //{

            //    Console.WriteLine("{0}", s);
            //}
            


            fileList1.EndUpdate();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //fileList1.SelectAll();
            //fileList1.RedrawItems(0, 2,true);

            fileList1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            fileList1.Clear();
            
        }

        private void fileList1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Console.WriteLine("drawsubitem:{0}", e.SubItem.Text);


            
            if(e.ColumnIndex>0)
            using (System.Drawing.StringFormat sf = new System.Drawing.StringFormat())
            {
                using (Font myTextFont = new Font(fileList1.Font.Name, 
                    fileList1.Font.Size, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.SubItem.Text, myTextFont,
                        Brushes.Black, e.Bounds, sf);
                }

            }


         

        }

        int count = 0;
        //this gets called

        //from MSDN
       



        static public int MeasureDisplayStringWidth(Graphics graphics, string text,
                                            Font font)
            {
                System.Drawing.StringFormat format  = new System.Drawing.StringFormat ();
                System.Drawing.RectangleF   rect    = new System.Drawing.RectangleF(0, 0,
                                                                              1000, 1000);
                System.Drawing.CharacterRange[] ranges  = 
                { new System.Drawing.CharacterRange(0, 
                                                                           text.Length) };
                System.Drawing.Region[]         regions = new System.Drawing.Region[1];

                format.SetMeasurableCharacterRanges (ranges);

                regions = graphics.MeasureCharacterRanges (text, font, rect, format);
                rect    = regions[0].GetBounds (graphics);

                return (int)(rect.Right + 1.0f);
            }



        private void whiteout(int x, int y, int width, int height, DrawListViewItemEventArgs e)
        {
         //   SolidBrush white = new SolidBrush(fileList1.BackColor);
            SolidBrush white = new SolidBrush(fileList1.BackColor);
            var r2 = new Rectangle();
            r2.X = x;
            r2.Y = y;
            r2.Height = height;
            r2.Width = width;
            e.Graphics.FillRectangle(white, r2);


        }

        private void redout(int x, int y, int width, int height, DrawListViewItemEventArgs e)
        {
            //   SolidBrush white = new SolidBrush(fileList1.BackColor);
            SolidBrush white = new SolidBrush(System.Drawing.Color.Red);
            var r2 = new Rectangle();
            r2.X = x;
            r2.Y = y;
            r2.Height = height;
            r2.Width = width;
            e.Graphics.FillRectangle(white, r2);


        }


        private void boldtest(Font f, string substr, DrawListViewItemEventArgs e)
        {
            
            var boldFont = new Font(f, FontStyle.Bold);


          //  redout(e.Bounds.X,e.Bounds.Y,20, e.Bounds.Height,e);

        //    var ii=Jam.Shell.SystemImageListHelper.GetIndexFromPath(e.Item.Text);

      //      var ic= Jam.Shell.SystemImageListHelper.
            
            //var ic = Jam.Shell.SystemImageListHelper.GetFileIcon(e.Item.Text, Jam.Shell.SystemImageListSize.SmallIcons,false); //this causes ownerredraw to turn off.
           
            // get the file attributes for file or directory

            Icon ic;
       //     FileAttributes attr = File.GetAttributes(e.Item.Text);
            
            
         //   Console.WriteLine(e.Item.Text);
                //detect whether its a directory or file
                //if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                //    ic = Etier.IconHelper.IconReader.GetFileIcon(e.Item.Text, IconReader.IconSize.Small,true); //doesnt' work for folders and certain non-system icons
                //else
                    ic = Etier.IconHelper.IconReader.GetFileIcon(e.Item.Text, IconReader.IconSize.Small,false); //doesnt' work for folders and certain non-system icons

            
            


         //  
          

            e.Graphics.DrawIcon(ic, 0, e.Bounds.Top);//+ 20);
      
            

            var r = new Rectangle();

            r.X = e.Bounds.X + 20;
            r.Y = e.Bounds.Y;

            
            //var location = new PointF(e.Bounds.Location.X, e.Bounds.Location.Y);
            var location = new PointF(r.X, r.Y);

            string s,beg, mid, end;

            s = e.Item.Text;

            //temp
           // substr = "one";
            //s = "onetwothree";


            //first clear out whatever is already there
         
            SolidBrush white = new SolidBrush(fileList1.BackColor);
            var r2 = new Rectangle();
            r2.X = e.Bounds.X +20;
            r2.Y = e.Bounds.Y;
            r2.Height = e.Bounds.Height;
            r2.Width = e.Bounds.Width;
            e.Graphics.FillRectangle(white, r2);

            //end clear

      

            var loc = s.IndexOf(substr, StringComparison.CurrentCultureIgnoreCase);
            if (loc == -1) return;
            beg = s.Substring(0, loc);
            mid = s.Substring(loc,substr.Length);
            end = s.Substring(loc+substr.Length,  s.Length-(loc+substr.Length));

            Console.WriteLine("-------------{0}{1}{2}", beg, mid.ToUpper(), end);
        //    return;

            e.Graphics.DrawString(beg, f, Brushes.Black, location);
            
            var size = e.Graphics.MeasureString(beg, f);//best
           // var size = MeasureDisplayStringWidth2(e.Graphics, beg, f);
           // var size2 = MeasureDisplayStringWidth3(e.Graphics, f, e, s);

         //   var size = TextRenderer.MeasureText(beg, f, TextFormatFlags.NoPadding);

         //   location.X += size.Width;
            location.X +=size.Width-4;

          //  TextRenderer.DrawText(e.Graphics, s, Brushes.Red, location,);

            e.Graphics.DrawString(mid, boldFont, Brushes.Red, location);
          
            size = e.Graphics.MeasureString(mid, boldFont);
          //  size = MeasureDisplayStringWidth2(e.Graphics, mid, boldFont);
       //     TextRenderer.MeasureText(mid, boldFont); 
         //   location.X += size.Width;
            location.X += size.Width-4;


            SizeF size2 = e.Graphics.MeasureString(s, f);

            

            //kinda works. 
            if (size2.Width > fileList1.Columns[0].Width)
            {

                fileList1.Columns[0].Width = (int)size2.Width + 50;

            

            }

                e.Graphics.DrawString(end, f, Brushes.Black, location);



        }

        //This is really for drawing just the first item.  subitems have their own callback. 
        private void fileList1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
       //     var ic2 = Icon.ExtractAssociatedIcon(e.Item.Text); //this works!
         
            
            //turn this back on at some point
   //            e.DrawDefault = false;
      
            
            Console.WriteLine("{0} drawitem", count++);


            System.Windows.Controls.ToolTip tooltip = new System.Windows.Controls.ToolTipToolTip();
            tooltip.Placement =  System.Windows.Controlsk 
            tooltip.PlacementRectangle = new  System.Windows.Controls.ToolTip.Rect(50, 0, 0, 0);
            tooltip.HorizontalOffset = 10;
            tooltip.VerticalOffset = 20;


            var r =new Rectangle();

            r.X = e.Bounds.X+20;
            r.Y = e.Bounds.Y;

            var font = fileList1.Font;


           // e.DrawDefault = true;
            using (System.Drawing.StringFormat sf = new System.Drawing.StringFormat())
            {
                using (Font myTextFont = new Font(fileList1.Font.Name, fileList1.Font.Size, FontStyle.Bold))
                {

                    boldtest(myTextFont,textBox1.Text, e);
                    //e.Graphics.DrawString(e.Item.Text, myTextFont,
                      //  Brushes.Black, r, sf);
                }
    
            }

            e.DrawFocusRectangle();
            //e.DrawDefault = true;
            
        }
        


        private void fileList1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Console.WriteLine("draw column header");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
