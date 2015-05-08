<%@ WebHandler Language="C#" Class="MakePhoto" %>

using System;
using System.Web;
using System.Drawing;

public class MakePhoto : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string message = context.Request.Form["message"];
        string number = context.Request.Form["n"];
        string slice = context.Request.Form["s"];
        string myname = context.Request.Form["myname"];
        string toname = context.Request.Form["toname"];
        string BGPath = HttpContext.Current.Server.MapPath("~/images/") + "card-0" + number + ".png";
        string ID = Guid.NewGuid().ToString();
        string SaveFolder=HttpContext.Current.Server.MapPath("~/edit/") + ID + "/";
        string FinishPath = SaveFolder + "complete_noline.jpg";
        string FinishPathwithpuzzleLine = SaveFolder + "complete.jpg";
        if (!System.IO.Directory.Exists(SaveFolder))
        {
            System.IO.Directory.CreateDirectory(SaveFolder);
        }
        int ColorR = 0; int ColorG = 0; int ColorB = 0; int zoneW = 20; int fonsizeSet = 20; int fontSpace = 10; int left = 187; int top = 911;
        int fromLeft = 0; int fromTop = 0; int toLeft = 0; int toTop = 0;
        int line = 3;
        switch (number)
        {
            case "1":
                ColorR = 0; ColorG = 0; ColorB = 0; zoneW = 18; fonsizeSet = 20; fontSpace = 20; left = 62; top = 300;
                fromLeft = 80; fromTop = 40; toLeft = 320; toTop = 400; line = 3;
                break;
            case "2":
                ColorR = 0; ColorG = 0; ColorB = 0; zoneW = 10; fonsizeSet = 20; fontSpace = 20; left = 150; top = 206;
                fromLeft = 70; fromTop = 18; toLeft = 227; toTop = 374; line = 5;
                break;
            case "3":
                ColorR = 0; ColorG = 0; ColorB = 0; zoneW = 14; fonsizeSet = 20; fontSpace = 20; left = 110; top = 107;
                fromLeft = 55; fromTop = 18; toLeft = 266; toTop = 204; line = 4;
                break;
            case "4":
                ColorR = 0; ColorG = 0; ColorB = 0; zoneW = 9; fonsizeSet = 20; fontSpace = 20; left = 175; top = 110;
                fromLeft = 61; fromTop = 16; toLeft = 220; toTop = 304; line = 8;
                break;
            case "5":
                ColorR = 255; ColorG = 255; ColorB = 255; zoneW = 13; fonsizeSet = 20; fontSpace = 20; left = 195; top = 75;
                fromLeft = 57; fromTop = 35; toLeft = 300; toTop = 394; line = 4;
                break;
            case "6":
                ColorR = 255; ColorG = 255; ColorB = 255; zoneW = 10; fonsizeSet = 18; fontSpace = 20; left = 150; top = 260;
                fromLeft = 53; fromTop = 22; toLeft = 325; toTop = 423; line = 5;
                break;
        }
        Bitmap BG = new Bitmap(BGPath);
        MakeText myMakeText = new MakeText();
        myMakeText.maketextpiconBG(message, ColorR, ColorG, ColorB, zoneW, fonsizeSet, fontSpace, BG, left, top, line);
       
        //if (myname.Length < 5)
        //{
        //    myname = myname.PadLeft((5 - myname.Length) * 4);
        //}
        toLeft = toLeft + ((5 - myname.Length) * fonsizeSet);
        myMakeText.maketextpiconBG(toname , 23, 18, 15, zoneW, fonsizeSet, fontSpace, BG, fromLeft, fromTop, line);
        myMakeText.maketextpiconBG(myname, 23, 18, 15, zoneW, fonsizeSet, fontSpace, BG, toLeft, toTop, line);
        BG.Save(FinishPath);
        CompositePhoto Composite = new CompositePhoto();


        if (slice == "9")
        {
            for (int i = 1; i <= 9; i++)
            {
                Bitmap SubPuzzleBG = new Bitmap(HttpContext.Current.Server.MapPath("~/images/") + "puzzle-0" + i + ".png");
                Bitmap SubPuzzle = (Bitmap)SubPuzzleBG.Clone();

                switch (i)
                {
                    case 1:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 0);

                        break;
                    case 2:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 161, 0);

                        break;
                    case 3:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 274, 0);

                        break;
                    case 4:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 110);

                        break;
                    case 5:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 107, 158);

                        break;
                    case 6:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 327, 110);

                        break;
                    case 7:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 327);

                        break;
                    case 8:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 107, 277);

                        break;
                    case 9:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 327, 327);

                        break;
                }

                SubPuzzle.Save(HttpContext.Current.Server.MapPath("~/edit/") + ID + "/" + "sub_0" + i + ".png");
                SubPuzzle.Dispose();
            }
            Bitmap PuzzleBG = new Bitmap(HttpContext.Current.Server.MapPath("~/images/") + "puzzleplate-01.png");
            Composite.DoCompositePic(PuzzleBG, BG, 0, 0);
            PuzzleBG.Dispose();
        } // if slice == "9"

        if (slice == "12")
        {
            for (int i = 1; i <= 12; i++)
            {
                Bitmap SubPuzzleBG = new Bitmap(HttpContext.Current.Server.MapPath("~/images/puzzle-12/") + "puzzle12-0" + i + ".png");
                Bitmap SubPuzzle = (Bitmap)SubPuzzleBG.Clone();

                switch (i)
                {
                    case 1:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 0);

                        break;
                    case 2:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 120, 0);

                        break;
                    case 3:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 205, 0);

                        break;
                    case 4:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 370, 0);

                        break;
                    case 5:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 123);

                        break;
                    case 6:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 80, 161);

                        break;
                    case 7:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 245, 123);

                        break;
                    case 8:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 330, 161);

                        break;
                    case 9:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 327);

                        break;
                    case 10:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 80, 289);

                        break;
                    case 11:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 245, 327);

                        break;
                    case 12:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 330, 289);

                        break;
                }
                SubPuzzle.Save(HttpContext.Current.Server.MapPath("~/edit/") + ID + "/" + "sub_0" + i + ".png");
                SubPuzzle.Dispose();
               
                //SubPuzzle.Save(HttpContext.Current.Server.MapPath("~/edit/") + ID + "_0" + i + ".png");
            }
            Bitmap PuzzleBG = new Bitmap(HttpContext.Current.Server.MapPath("~/images/") + "puzzleplate-02.png");
            Composite.DoCompositePic(PuzzleBG, BG, 0, 0);
            PuzzleBG.Dispose();
        } // if slice == "12"

        if (slice == "16")
        {
            for (int i = 1; i <= 16; i++)
            {
                Bitmap SubPuzzleBG = new Bitmap(HttpContext.Current.Server.MapPath("~/images/puzzle-16/") + "puzzle16-0" + i + ".png");
                Bitmap SubPuzzle = (Bitmap)SubPuzzleBG.Clone();

                switch (i)
                {
                    case 1:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 0);

                        break;
                    case 2:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 120, 0);

                        break;
                    case 3:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 205, 0);

                        break;
                    case 4:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 370, 0);

                        break;
                    case 5:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 80);

                        break;
                    case 6:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 80, 121);

                        break;
                    case 7:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 245, 80);

                        break;
                    case 8:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 330, 121);

                        break;
                    case 9:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 246);

                        break;
                    case 10:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 120, 205);

                        break;
                    case 11:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 205, 246);

                        break;
                    case 12:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 370, 205);

                        break;
                    case 13:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 0, 330);

                        break;
                    case 14:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 80, 370);

                        break;
                    case 15:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 245, 330);

                        break;
                    case 16:
                        Composite.DoCompositePicSubBG(BG, SubPuzzle, 330, 370);

                        break;
                }
                SubPuzzle.Save(HttpContext.Current.Server.MapPath("~/edit/") + ID + "/" + "sub_0" + i + ".png");
                SubPuzzle.Dispose();
                //SubPuzzle.Save(HttpContext.Current.Server.MapPath("~/edit/") + ID + "_0" + i + ".png");
            }
           
            
            Bitmap PuzzleBG = new Bitmap(HttpContext.Current.Server.MapPath("~/images/") + "puzzleplate-03.png");
            Composite.DoCompositePic(PuzzleBG, BG, 0, 0);
            PuzzleBG.Dispose();
        } // if slice == "16"
        BG.Save(FinishPathwithpuzzleLine);
        
        BG.Dispose();
        
        context.Response.Write(ID);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}