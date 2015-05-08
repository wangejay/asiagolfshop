using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Globalization;
using System.Collections;
using System.IO;
using System.Drawing.Text;

/// <summary>
/// Summary description for MakeText
/// </summary>
public class MakeText
{
    public class TextInfo
    {
        public string text;
        //int fontsize;
        //color font color;
    }
	public MakeText()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Bitmap maketextpiconBG(string mystring, int colorR, int colorG, int colorB, int zoneW, int fontsizeSet, int fontSpace, Bitmap BG,
            int left, int top,int line)
    {
       // string Session = "text";
        ArrayList myarray = new ArrayList();
        TextInfo myText = new TextInfo();
        //string despath = GetSaveFilePath(Session) + "/text.jpg";
        string[] tmp = new string[myarray.Count];
        int i = 0;
        mystring=mystring.Replace("\r", "");
        mystring = mystring.Replace("\n", "");
        while (mystring.Length > zoneW && i < line)
        {
            TextInfo mytemp = new TextInfo();
            int idx = 0;
            int change = 0;
            if (mystring.IndexOf("\n") < zoneW && mystring.IndexOf("\n")>0)
            {
                idx= mystring.IndexOf("\n");
                change = 1;
            }
            else
            {
                idx = zoneW;
            }
            mytemp.text = mystring.Substring(0, idx);
            myarray.Add(mytemp);
            if (change==1)
                idx++;
            mystring = mystring.Substring(idx);
            i++;
        }
        myText.text = mystring;
        if (i == line)
        { }
        else if (myText.text.Length == 0) { }
        else if (myText.text.Length < zoneW)
        {
            myText.text = mystring.Substring(0, myText.text.Length);
            myarray.Add(myText);
        }
        else
        {
            myText.text = mystring.Substring(0, zoneW);
            myarray.Add(myText);
        }
        
       // if (myText.text.Length != 0)
        //    myarray.Add(myText);

        //f.Dispose();
        return WritetextJpgONBG(myarray, colorR, colorG, colorB, fontsizeSet, fontSpace, BG, left, top);
    }
    public Bitmap WritetextJpgONBG(ArrayList Text, int colorR, int colorG, int colorB, int fontsizeSet,
        int fontSpace, Bitmap BG, int left, int top)
    {
        int big = 1;
        string returnvalue = Guid.NewGuid().ToString();
        //int wordnum = 0, maxwidth=0;
        Bitmap b = null;
        try
        {
            int fontsize = fontsizeSet * big; //ie 12個pixel
            int Space = fontSpace * big - fontsizeSet * big;

            int width = 0, height = 0;

            //string text = "";
            int xpos = 0, ypos = 0;

            PrivateFontCollection privateFontCollection = new PrivateFontCollection();

            // Add three font files to the private collection.
            // privateFontCollection.AddFontFile("D:\\systemroot\\Fonts\\WCL-09.ttf");
             privateFontCollection.AddFontFile(HttpContext.Current.Server.MapPath("~/font/") + "font.ttc");
            //privateFontCollection.AddFontFile(fontpath);

            // Get the array of FontFamily objects.
            FontFamily[] fontFamilies = privateFontCollection.Families;
            string familyName = fontFamilies[0].Name;

            //先定義Font 大小
            FontFamily fontFamily = new FontFamily("新細明體");
            Font f = new Font(
               familyName,
               fontsize,
               FontStyle.Regular,
               GraphicsUnit.Pixel);


            //Font f = new Font("Arial Narrow Italic", fontsize, GraphicsUnit.Pixel);


            //算出圖的height
            height = (int)(Text.Count * (f.Height + Space));
            string[] tmp = new string[Text.Count];
            int i = 0;
            Bitmap a = new Bitmap(5, 5);
            Graphics h = Graphics.FromImage(a);
            foreach (TextInfo textinfo in Text)
            {
                tmp[i] = textinfo.text;
                //算width               
                //width = (int)g.MeasureString(tmp[i], f).Width;
                width = ((int)h.MeasureString(tmp[i], f).Width > width) ? (int)h.MeasureString(tmp[i], f).Width : width;
                i++;
            }
            h.Dispose();
            a.Dispose();

            //根據width, height 做一張bitmap
            //b = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(BG);
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // g.Clear(Color.Transparent);

            // SolidBrush blackBrush = new SolidBrush(Color.White);
            Color customColor = Color.FromArgb(colorR, colorG, colorB);
            SolidBrush blackBrush = new SolidBrush(customColor);
            // g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //開始把每一行的text 貼上位置
            foreach (string t in tmp)
            {
                g.DrawString(t, f, blackBrush, left + xpos, top + ypos);
                ypos = ypos + f.Height + Space;
            }

            //b.Save(SavePathFilename);


        }
        catch (Exception e)
        {
            returnvalue = e.Message;

        }
        return b;
    }
    private string GetSaveFilePath(string Folder)
    {
        String picPath = HttpContext.Current.Server.MapPath("~/Edit/");

        try
        {
            //    DateTime dateTime = DateTime.Now;

            string Path = picPath + Folder;
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            return Path;
        }
        catch
        {

            return string.Empty;
        }
    }
}
