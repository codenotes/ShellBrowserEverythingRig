using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using System;

using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using System.Diagnostics;



using System.Runtime.InteropServices;



    class FileList2: Jam.Shell.FileList
    {
        const int iconOffset = 20;
        public string SearchTerm;
        List<Rectangle> CurrentDrawn =new List<Rectangle>();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);


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
        static Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public static Color GetColorAt(Point location)
        {
            
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }
            return screenPixel.GetPixel(0, 0);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);


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
                        var brush =new SolidBrush( customColor);
                        Jam.Shell.FileListItem s=null;


                        for (int i = startCount; (i- startCount) < cnt; i++ )
                        {

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


                            //r.X += iconOffset;
                            //r.Width = ms;

                  //          this.getVisible();


//                            Graphics g (hdc);
//                            System.Drawing.SolidBrush brush(System.Drawing.Color(127 /*A*/, 0 /*R*/, 0 /*G*/, 255 /*B*/));
  //                          g.FillRectangle (&brush, 0, 0, width, height);

                            graphics.DrawRectangle(System.Drawing.Pens.Red, r);
//                            var p =new  Point(r.X, r.Y);
  //                          Console.WriteLine("Color:{0}",GetColorAt(p));

                           // graphics.FillRectangle( brush,r );


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




