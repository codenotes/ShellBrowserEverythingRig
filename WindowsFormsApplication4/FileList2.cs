using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Everything;
using EvMenu;




    class FileList2: Jam.Shell.FileList
    {
        const int MARKER_COLOR = 0xFEFFFC; //was 0xEEBC1A

        const int iconOffset = 20;
        public string SearchTerm;
        public int NumResults = 0;
        private const int MY_REPLY_ID = 66;

         public bool MatchPath
            {
                get 
                    {
   
                        return Everything.EverythingSearch.Everything_GetMatchPath();
                    }
                set
                     {

                        Everything.EverythingSearch.Everything_SetMatchPath(value);
                     }
            }
        
        public bool MatchCase
         {
             get
             { 
                 return Everything.EverythingSearch.Everything_GetMatchCase(); 
             }
             set 
             {

                 Everything.EverythingSearch.Everything_SetMatchCase(value);
             }
         }

        public bool MatchWholeWord
        {
            get 
            {
                return Everything.EverythingSearch.Everything_GetMatchWholeWord(); 
            }
            set
            {
                Everything.EverythingSearch.Everything_SetMatchWholeWord(value);
            }
        }

        public int MaxResults
        {
            get 
            {
                return (int)Everything.EverythingSearch.Everything_GetMax();
            }
            set
            {
                Everything.EverythingSearch.Everything_SetMax(value); 
            }
        }

        public int Offset
        {
            get
            {
                return (int)Everything.EverythingSearch.Everything_GetOffset();
            }
            set
            {
                Everything.EverythingSearch.Everything_SetOffset(value);
            }
        }



        public bool RegEx
        {
            get 
            {
                return Everything.EverythingSearch.Everything_GetRegex() ; 
            }
            set 
            {
                Everything.EverythingSearch.Everything_SetRegex(value);
     
            }

        }



      //  Dictionary<int, Rectangle> CurrentlyDrawn =new Dictionary<int, Rectangle>();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("gdi32.dll")]
        static extern int GetPixel(IntPtr hDC, int x, int y);
        [DllImport("gdi32.dll")]
        static extern int SetPixel(IntPtr hDC, int x, int y, int color);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        private EvCustomContextMenu ev=new EvCustomContextMenu();

        public void Init()
        {
            contextMenuStrip1 = new ContextMenuStrip();
            oneToolStripMenuItem = new ToolStripMenuItem();
            twoToolStripMenuItem = new ToolStripMenuItem();
            threeToolStripMenuItem = new ToolStripMenuItem();
            
            //ev.InitMenu();

            this.ContextMenuStrip = ev.contextMenuStrip1;
            ev.SetHandler(0, new EvMenu.MenuStripCallback(CopyClipboard));
            ev.SetHandler(1, new EvMenu.MenuStripCallback(OpenPath));

     
           

        }

        public FileList2(): base()
        {
            Init();
            Console.WriteLine("Constructor for FileList2");

        

            

        }
        
        public void CopyClipboard(object data)
        {
           
            var f = this.SelectedItems;
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

            var d = System.IO.Path.GetDirectoryName(this.SelectedItems[0].Path);
            EvMenu.EvCustomContextMenu.ShellExecute(IntPtr.Zero, "open", "explorer.exe", d, "", EvMenu.EvCustomContextMenu.ShowCommands.SW_NORMAL);

        }

        private void PopulateResults()
        {
            int i;
            const int bufsize = 260;
            StringBuilder buf = new StringBuilder(bufsize);
            StringBuilder buf2 = new StringBuilder();

            NumResults = EverythingSearch.Everything_GetNumResults();

            string[] l = new string[NumResults];

            // loop through the results, adding each result to the listbox.

            for (i = 0; i < NumResults; i++)
            {
                // get the result's full path and file name.
                EverythingSearch.Everything_GetResultFullPathNameW(i, buf, bufsize);

                l[i] = buf.ToString();

            }

            this.AddStrings(l);

        }


        public void SearchEverything(string search, bool blocking=true)
        {
            this.Clear();



            // set the search
            EverythingSearch.Everything_SetSearchW(search);

            this.SearchTerm = search;

            // execute the query
            if (blocking)
            {
                EverythingSearch.Everything_QueryW(true);
                PopulateResults();
            }
            else
            {
                Everything.EverythingSearch.Everything_SetReplyWindow(this.Handle);

                //// set the reply id.
                Everything.EverythingSearch.Everything_SetReplyID(MY_REPLY_ID);
			
                EverythingSearch.Everything_QueryW(false);
            }

         



        }

        static public int MeasureDisplayStringWidth(Graphics graphics, string text,
                                    Font font)
        {
            if(text=="" || text ==null)
            {
                return 0;
            }

            System.Drawing.StringFormat format = new System.Drawing.StringFormat();
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0,
                                                                          1000, 1000);
            System.Drawing.CharacterRange[] ranges = 
                { new System.Drawing.CharacterRange(0, 
                                                                           text.Length) };
            System.Drawing.Region[] regions = new System.Drawing.Region[1];

            format.SetMeasurableCharacterRanges(ranges);

            regions = graphics.MeasureCharacterRanges(text, font, rect, format);
            rect = regions[0].GetBounds(graphics);

            return (int)(rect.Right + 1.0f);
        }


        public void getVisible()
        {

            ListViewItem top = this.TopItem;
            var cnt=(int)SendMessage(this.Handle, 0x1028, IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine("Number of lines in view is {0}, top item is {1}", cnt, top.Index);


        }

        private Rectangle findSubStr(string text, string substr)
        {
            string beg, mid, end;
            var r=new Rectangle();


            var loc = text.IndexOf(substr, StringComparison.CurrentCultureIgnoreCase);
            
            if (loc == -1) 
            {
                r.X=-1;r.Y=-1;
                return r;
            }
            
            beg = text.Substring(0, loc);
            mid = text.Substring(loc, substr.Length);
            end = text.Substring(loc + substr.Length, text.Length - (loc + substr.Length));

            int begMs, midMs, endMs;
            var g = this.CreateGraphics();
            var fnt = this.Font;

            begMs = MeasureDisplayStringWidth(g, beg,fnt);
            midMs = MeasureDisplayStringWidth(g, mid,fnt);
            endMs = MeasureDisplayStringWidth(g, end,fnt);

            //so, our rectagle needs to be at the end of begMs and go to the beginning of MidMs
            r.X = begMs;
            r.Width = midMs-3;

            return r;



        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);


            if (Everything.EverythingSearch.Everything_IsQueryReply(m.Msg, m.WParam, m.LParam, MY_REPLY_ID))
            {
                PopulateResults();

            }



            switch (m.Msg)
            {



                case 0x000F: //paint
                    {


                        //var x = this.Items;
                        var itemCnt = this.Items.Count;
                        
                        System.Drawing.Graphics graphics = this.CreateGraphics();


                        ListViewItem top = this.TopItem;
                        if (top == null) return;
                        
                        int startCount = top.Index;


                        var cnt = (int)SendMessage(this.Handle, 0x1028, IntPtr.Zero, IntPtr.Zero);

                        //now lets make sure we don't have fewer items than the control can see
                        //if it is, reduce cnt size to how many items there actually are
                        if (itemCnt < cnt)
                            cnt = itemCnt;


                        if (cnt == 0) return;
                        Color customColor = Color.FromArgb(50, Color.Blue);
                   //     Console.WriteLine("Custom color is:{0}", customColor);

                        var brush =new SolidBrush( customColor);
                        Jam.Shell.FileListItem s=null;


                        for (int i = startCount; (i- startCount) <cnt; i++ )
                        {

                           // if ((i - startCount == cnt) && itemCnt < cnt) continue;

                            try
                            {
                                s = this.Items[i];
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("exception, index is {0} cnt is {1} and exception:"+e.ToString(),i, cnt);

                            }
                            var r = s.Bounds;
                            var f = System.IO.Path.GetFileName(s.Path);
                            var ms = MeasureDisplayStringWidth(this.CreateGraphics(), f, this.Font);

                            var r2 = findSubStr(f, this.SearchTerm);

                            r.X += r2.X + iconOffset;
                            r.Width = r2.Width;


                            
                            
                            
                           //alpha channels keep adding and get darker with multiple repaints
                            //so I set a hidden stegenographic pixel to encode information.
                            IntPtr dc = GetDC(this.Handle);
                            int col=GetPixel(dc, r.X - 1, r.Y);

                            if (col != MARKER_COLOR)
                            {
                          //      graphics.DrawRectangle(System.Drawing.Pens.Red, r);

                                var cw = this.Columns[0].Width;

                                if( ! (r.X + r.Width >cw) ) //do not draw beyond the column width
                                    graphics.FillRectangle(brush, r);

                                SetPixel(dc, r.X - 1, r.Y, MARKER_COLOR);
                            }

                            ReleaseDC(this.Handle, dc);


                            //if (!CurrentlyDrawn.ContainsKey(i))
                            //{
                            //    Console.WriteLine("Paint:{0}", s.Path);
                            //    graphics.DrawRectangle(System.Drawing.Pens.Red, r);
                            //    graphics.FillRectangle(brush, r);
                            //    CurrentlyDrawn[i] = r;
                            //}
                            //else
                            //{
                            //    Console.WriteLine("!Paint:{0}", s.Path);
                            //}


                         //   Console.WriteLine("{0}:{1}", f, ms);
                        }

                       
                 //       System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
                    //    graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
                   





                       // Console.WriteLine("paint");
                        //Rectangle bmpRect = new Rectangle(0, 0, 640, 480);
                        //// Create a bitmap
                        //using (Bitmap bmp = new Bitmap(bmpRect.Width, bmpRect.Height))
                        //{
                        //    // Create a graphics context to draw to your bitmap.
                        //    using (Graphics gfx = Graphics.FromImage(bmp))
                        //    {
                        //        //Do some cool drawing stuff here
                        //        gfx.DrawEllipse(Pens.Red, bmpRect);
                        //    }

                        //    //and save it!
                        // //   bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MyBitmap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                        //}
                        break;

                    }

                case 0x0114: //HSCROLL


                    Console.WriteLine("hscroll");
                    this.Refresh();


                    break;
            }


            
        }

    }




