using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvMenu;
using System.Drawing;
using Etier.IconHelper;

namespace Jam.Greg
{
    class FileList2: Jam.Shell.FileList
    {
    //    public string mSearch="";


        FileList2()
        {

  //         // DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(DrawColumnHeader);
  ////          DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(_DrawItem);
  //  //        DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(_DrawSubItem);
            
            

        }


        //private void whiteout(int x, int y, int width, int height, DrawListViewItemEventArgs e)
        //{
        //    //   SolidBrush white = new SolidBrush(this.BackColor);
        //    SolidBrush white = new SolidBrush(this.BackColor);
        //    var r2 = new Rectangle();
        //    r2.X = x;
        //    r2.Y = y;
        //    r2.Height = height;
        //    r2.Width = width;
        //    e.Graphics.FillRectangle(white, r2);


        //}

        //private void _DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        //{
        //    Console.WriteLine("drawsubitem:{0}", e.SubItem.Text);

        //    if (e.ColumnIndex > 0)
        //        using (System.Drawing.StringFormat sf = new System.Drawing.StringFormat())
        //        {
        //            using (Font myTextFont = new Font(this.Font.Name,
        //                this.Font.Size, FontStyle.Bold))
        //            {
        //                e.Graphics.DrawString(e.SubItem.Text, myTextFont,
        //                    Brushes.Black, e.Bounds, sf);
        //            }

        //        }




        //}


        //private void boldtest(Font f, string substr, DrawListViewItemEventArgs e)
        //{

        //    var boldFont = new Font(f, FontStyle.Bold);


        //    //   whiteout(e.Bounds.X,e.Bounds.Y,20, e.Bounds.Height,e);


        //    var ic = Etier.IconHelper.IconReader.GetFileIcon(e.Item.Text, IconReader.IconSize.Small, false);
        //    e.Graphics.DrawIcon(ic, 0, e.Bounds.Top);//+ 20);



        //    var r = new Rectangle();

        //    r.X = e.Bounds.X + 20;
        //    r.Y = e.Bounds.Y;


        //    //var location = new PointF(e.Bounds.Location.X, e.Bounds.Location.Y);
        //    var location = new PointF(r.X, r.Y);

        //    string s, beg, mid, end;

        //    s = e.Item.Text;

        //    //temp
        //    // substr = "one";
        //    //s = "onetwothree";


        //    //first clear out whatever is already there

        //    SolidBrush white = new SolidBrush(this.BackColor);
        //    var r2 = new Rectangle();
        //    r2.X = e.Bounds.X + 20;
        //    r2.Y = e.Bounds.Y;
        //    r2.Height = e.Bounds.Height;
        //    r2.Width = e.Bounds.Width;
        //    e.Graphics.FillRectangle(white, r2);

        //    //end clear



        //    var loc = s.IndexOf(substr, StringComparison.CurrentCultureIgnoreCase);
        //    if (loc == -1) return;
        //    beg = s.Substring(0, loc);
        //    mid = s.Substring(loc, substr.Length);
        //    end = s.Substring(loc + substr.Length, s.Length - (loc + substr.Length));

        //    Console.WriteLine("-------------{0}{1}{2}", beg, mid.ToUpper(), end);
        //    //    return;

        //    e.Graphics.DrawString(beg, f, Brushes.Black, location);

        //    var size = e.Graphics.MeasureString(beg, f);//best
        //    // var size = MeasureDisplayStringWidth2(e.Graphics, beg, f);
        //    // var size2 = MeasureDisplayStringWidth3(e.Graphics, f, e, s);

        //    //   var size = TextRenderer.MeasureText(beg, f, TextFormatFlags.NoPadding);

        //    //   location.X += size.Width;
        //    location.X += size.Width - 4;

        //    //  TextRenderer.DrawText(e.Graphics, s, Brushes.Red, location,);

        //    e.Graphics.DrawString(mid, boldFont, Brushes.Red, location);

        //    size = e.Graphics.MeasureString(mid, boldFont);
        //    //  size = MeasureDisplayStringWidth2(e.Graphics, mid, boldFont);
        //    //     TextRenderer.MeasureText(mid, boldFont); 
        //    //   location.X += size.Width;
        //    location.X += size.Width - 4;

        //    e.Graphics.DrawString(end, f, Brushes.Black, location);




        //}

        ////This is really for drawing just the first item.  subitems have their own callback. 
        //private void _DrawItem(object sender, DrawListViewItemEventArgs e)
        //{

        //    e.DrawDefault = false;



        ////    Console.WriteLine("{0} drawitem", count++);


        //    var r = new Rectangle();

        //    r.X = e.Bounds.X + 20;
        //    r.Y = e.Bounds.Y;

        //    var font = this.Font;


        //    // e.DrawDefault = true;
        //    using (System.Drawing.StringFormat sf = new System.Drawing.StringFormat())
        //    {
        //        using (Font myTextFont = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold))
        //        {

        //            boldtest(myTextFont, mSearch, e);
        //            //e.Graphics.DrawString(e.Item.Text, myTextFont,
        //            //  Brushes.Black, r, sf);
        //        }

        //    }

        //    e.DrawFocusRectangle();
        //    //e.DrawDefault = true;

        //}
        



    }
}
