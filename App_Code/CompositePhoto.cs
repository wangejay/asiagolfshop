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
using System.Drawing.Imaging;
using System.Drawing;

/// <summary>
/// Summary description for CompositePhoto
/// </summary>
public class CompositePhoto
{
	public CompositePhoto()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void DoCompositePic(Bitmap blade, Bitmap newpic, int startX, int startY)
    {
        #region 合成
        //Color pixel, userpixel;
        int A, R, G, B;
        int UserR = 0, UserG = 0, UserB = 0;
        double alpha;
        #region USE POINT
        //Step 1: 鎖住 Bitmap 整個影像內容

        BitmapData newbmData = newpic.LockBits(new Rectangle(0, 0, newpic.Width, newpic.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        BitmapData bladeData = blade.LockBits(new Rectangle(0, 0, blade.Width, blade.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);


        // 計算每一行後面幾個 Padding bytes

        int ByteOfSkipNewpic = newbmData.Stride - newpic.Width * 4;
        int ByteOfSkipBlade = bladeData.Stride - blade.Width * 4;

        unsafe
        {//可以改成 one loop


            byte* newbp = (byte*)(void*)newbmData.Scan0;
            newbp = newbp + startY * newbmData.Stride + startX * 4;
            byte* bladep = (byte*)(void*)bladeData.Scan0;

            for (int y = 0; y < blade.Height; y++)
            {
                for (int x = 0; x < blade.Width; x++)
                {
                    //int x1,int y1,int x2,int y2


                    //取得每個pixel的資料
                    // A = newbp[3]; //0-255: 0 全透明, 255 不透明


                    A = bladep[3];

                    bladep = bladep + 4;




                    //將合成的RGB存入新圖 新圖 fmt = 24bpp
                    if (A >50)
                    {
                        newbp[0] = bladep[0];
                        newbp[1] = bladep[1];
                        newbp[2] = bladep[2];
                        newbp[3] = bladep[3];
                    }
                    newbp = newbp + 4;


                }

                //newbp += ByteOfSkipNewpic;
                newbp = (byte*)(void*)newbmData.Scan0 + (startY + y) * newbmData.Stride + startX * 4;
                bladep += ByteOfSkipBlade;
                //tempbp += ByteOfSkipTemp2;

            }


        }
        //最後別忘了解開記憶體鎖 

        newpic.UnlockBits(newbmData);
        blade.UnlockBits(bladeData);
        #endregion

        #endregion
    }
    public void DoCompositePicSubBG(Bitmap blade, Bitmap newpic, int startX, int startY)
    {
        #region 合成
        //Color pixel, userpixel;
        int A, R, G, B;
        int UserR = 0, UserG = 0, UserB = 0;
        double alpha;
        #region USE POINT
        //Step 1: 鎖住 Bitmap 整個影像內容

        BitmapData newbmData = newpic.LockBits(new Rectangle(0, 0, newpic.Width, newpic.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        BitmapData bladeData = blade.LockBits(new Rectangle(0, 0, blade.Width, blade.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);


        // 計算每一行後面幾個 Padding bytes

        int ByteOfSkipNewpic = newbmData.Stride - newpic.Width * 4;
        int ByteOfSkipBlade = bladeData.Stride - blade.Width * 4;

        unsafe
        {//可以改成 one loop


            byte* newbp = (byte*)(void*)newbmData.Scan0;
            
            byte* bladep = (byte*)(void*)bladeData.Scan0;
            bladep = bladep + startY * bladeData.Stride + startX * 4;
            for (int y = 0; y < newpic.Height; y++)
            {
                for (int x = 0; x < newpic.Width; x++)
                {
                    //int x1,int y1,int x2,int y2


                    //取得每個pixel的資料
                    // A = newbp[3]; //0-255: 0 全透明, 255 不透明


                    

                    bladep = bladep + 4;


                    A = newbp[3];

                    //將合成的RGB存入新圖 新圖 fmt = 24bpp
                    if (A > 0)
                    {
                        newbp[0] = bladep[0];
                        newbp[1] = bladep[1];
                        newbp[2] = bladep[2];
                      
                    }
                    
                    newbp = newbp + 4;


                }

                //newbp += ByteOfSkipNewpic;
                //newbp = (byte*)(void*)newbmData.Scan0 + (startY + y) * newbmData.Stride + startX * 4;
                //bladep += ByteOfSkipBlade;

              
                bladep = (byte*)(void*)bladeData.Scan0 + (startY + y) * bladeData.Stride + startX * 4;

                newbp += ByteOfSkipNewpic;
                //tempbp += ByteOfSkipTemp2;

            }


        }
        //最後別忘了解開記憶體鎖 

        newpic.UnlockBits(newbmData);
        blade.UnlockBits(bladeData);
        #endregion

        #endregion
    }
}
