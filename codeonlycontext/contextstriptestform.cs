using Everything;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using EvMenu;
using System.Drawing;
using System.Data;
using Etier.IconHelper;


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
            

            // loop through the results, adding each result to the listbox.
            for (i = 0; i < EverythingSearch.Everything_GetNumResults(); i++)
            {
                // get the result's full path and file name.
                EverythingSearch.Everything_GetResultFullPathNameW(i, buf, bufsize);
                fileList1.Add(buf.ToString());

                // add it to the list box				
         //       listBox1.Items.Insert(i, buf);
            }

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
        private void fileList1_DrawItem3(object sender,
    DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                // Draw the background for an unselected item. 
                using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                    new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.Orange,
                    Color.Maroon, System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }

            // Draw the item text for views other than the Details view. 
            if (fileList1.View != View.Details)
            {
                e.DrawText();
            }
        }

        static public int MeasureDisplayStringWidth2(Graphics graphics, string text,
                                            Font font)
                {
                    const int width = 32;

                    System.Drawing.Bitmap   bitmap = new System.Drawing.Bitmap (width, 1, 
                        graphics);
                    System.Drawing.SizeF    size   = graphics.MeasureString (text, font);
                    System.Drawing.Graphics anagra = System.Drawing.Graphics.FromImage(bitmap);

                    int measured_width = (int) size.Width;

                    if (anagra != null)
                    {
                        anagra.Clear (Color.White);
                        anagra.DrawString (text+"|", font, Brushes.Black,
                                           width - measured_width, -font.Height / 2);

                        for (int i = width-1; i >= 0; i--)
                        {
                            measured_width--;
                            if (bitmap.GetPixel (i, 0).R != 255)    // found a non-white pixel ?
                                break;
                        }
                    }

                    return measured_width;
                }


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


        public void MeasureDisplayStringWidth3(Graphics g, Font stringFont, DrawListViewItemEventArgs e, string measureString)
        {
            //
            // Get a more convenient graphics object.
  //          Graphics g = e.Graphics;

            // Set up string.
          //  string measureString = "This is a test string, will be printed at random offsets!";
            int numChars = measureString.Length;

            //
            // Set up the characted ranger array.
            CharacterRange[] characterRanges = new CharacterRange[numChars];
            for (int i = 0; i < numChars; i++)
                characterRanges[i] = new CharacterRange(i, 1);

            //
            // Set up the string format
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.NoClip;			// Make sure the characters are not clipped
            stringFormat.SetMeasurableCharacterRanges(characterRanges);

            //
            // Set up the array to accept the regions.
            Region[] stringRegions = new Region[numChars];

            //
            // The font to use.. 'using' will dispose of it for us
          //  using (Font stringFont = new Font("Times New Roman", 16.0F))
            {

                //
                // Get the max width.. for the complete length
                SizeF size = g.MeasureString(measureString, stringFont);

                //
                // Assume the string is in a stratight line, just to work out the 
                // regions. We will adjust the containing rectangles later.
                RectangleF layoutRect = new RectangleF(0.0f, 0.0f, size.Width, size.Height);

                //
                // Caluclate the regions for each character in the string.
                stringRegions = e.Graphics.MeasureCharacterRanges(
                    measureString,
                    stringFont,
                    layoutRect,
                    stringFormat);

                //
                // Some random offsets, uncomment the DrawRectagle if you want to see the bounding box.
                //Random rand = new Random();
                //for (int indx = 0; indx < numChars; indx++)
                //{
                //    Region region = stringRegions[indx] as Region;
                //    RectangleF rect = region.GetBounds(g);
                //    rect.Offset(0f, (float)rand.Next(100) / 10f);
                //    g.DrawString(measureString.Substring(indx, 1), stringFont, Brushes.Yellow, rect, stringFormat);
                //    // g.DrawRectangle( Pens.Red, Rectangle.Round( rect ));
                //}
            }
        }

  



        private void boldtest(Font f, string substr, DrawListViewItemEventArgs e)
        {
            
            var boldFont = new Font(f, FontStyle.Bold);

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

            e.Graphics.DrawString(end,f, Brushes.Black, location);
        }


        private void fileList1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

            e.DrawDefault = false;
 

            
            Console.WriteLine("{0} drawitem", count++);

            var ic = Etier.IconHelper.IconReader.GetFileIcon(e.Item.Text, IconReader.IconSize.Small, false);

            var r =new Rectangle();

            r.X = e.Bounds.X+20;
            r.Y = e.Bounds.Y;

            var font = fileList1.Font;


            e.Graphics.DrawIcon(ic, 0, e.Bounds.Top );//+ 20);
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
        
        
        private void fileList1_DrawItem2(object sender, DrawListViewItemEventArgs e)
        {

            var ic = Etier.IconHelper.IconReader.GetFileIcon(e.Item.Text, IconReader.IconSize.Small, false);

            Console.WriteLine("{0} drawitem", count++);
            //   e.DrawBackground();


            e.DrawDefault = false;

            Console.WriteLine("{1}\n{0}\n", e.Item.Text,count);
            count++;

         //   e.DrawBackground();

             var clsBrush=  new System.Drawing.SolidBrush(fileList1.ForeColor);

            //e.Graphics.DrawString(sPart1, ListView1.Font, clsBrush, e.Bounds.X, e.Bounds.Y);

            //e.Graphics.DrawString(sPart2, New Font(ListView1.Font, FontStyle.Underline Or FontStyle.Bold), _
            //            clsBrush, e.Bounds.X + e.Graphics.MeasureString(sPart1, ListView1.Font, _
            //            New SizeF(e.Bounds.Width, e.Bounds.Height)).Width, e.Bounds.Y)

            string s="booger!!!!!!!!!!!!!11";
         
           // e.Graphics.DrawIcon(ic, e.Bounds);

           e.Graphics.DrawIcon(ic, 3, e.Bounds.Top + 20);
           


             //e.Graphics.DrawString(s, fileList1.Font, clsBrush, e.Bounds.X +
             //            e.Graphics.MeasureString(s, fileList1.Font,
             //            new System.Drawing.SizeF(e.Bounds.Width, e.Bounds.Height)).Width, e.Bounds.Y);

           
            
            clsBrush.Dispose();
            e.DrawFocusRectangle();
        //      e.DrawBackground();
        //' extract the 3 parts to the text...
        //If e.Item.Text.Contains(m_sSearchString) Then
            //Console.WriteLine("drawitem"); //this is the one

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
