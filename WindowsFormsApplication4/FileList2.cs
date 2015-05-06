using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;



    class FileList2: Jam.Shell.FileList
    {
        const int iconOffset = 20;

        static public int MeasureDisplayStringWidth(Graphics graphics, string text,
                                    Font font)
        {
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


            switch (m.Msg)
            {
                case 0x000F: //paint
                    {


                        var x = this.Items;
                        
                        System.Drawing.Graphics graphics = this.CreateGraphics();

                        foreach(Jam.Shell.FileListItem s in x)
                        {

                            var r = s.Bounds;
                            var f=System.IO.Path.GetFileName(s.Path);
                            var ms = MeasureDisplayStringWidth(this.CreateGraphics(), f, this.Font);

                            var r2 = findSubStr(f, "st");

                            r.X += r2.X + iconOffset;
                            r.Width = r2.Width;


                            //r.X += iconOffset;
                            //r.Width = ms;


                            
                            graphics.DrawRectangle(System.Drawing.Pens.Red, r);


                            Console.WriteLine("{0}:{1}", f, ms);
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




