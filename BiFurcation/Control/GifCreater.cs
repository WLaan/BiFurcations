using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace BiFurcation {

  public class GifCreater {

    #region gif-creation
    private byte[] GifAnimation = { 33, 255, 11, 78, 69, 84, 83, 67, 65, 80, 69, 50, 46, 48, 3, 1, 0, 0, 0 };
    private byte[] Delay = { 255, 0 };
    public List<Image> images = new List<Image>();
    public bool AddReverse = false;
    #endregion

    public GifCreater() {
    }

    private void WriteGifImg(byte[] B, BinaryWriter BW) {
      B[785] = Delay[0]; //5 secs delay
      B[786] = Delay[1];
      B[798] = (byte)(B[798] | 0X87);
      BW.Write(B, 781, 18);
      BW.Write(B, 13, 768);
      BW.Write(B, 799, B.Length - 800);
    }

    public void create(int delay, string fileName) {
      if (images.Count == 0 || images[0] == null) return;
      string path = StaticFormsCalls.StartupPath;
      Delay[0] = (byte)((delay * 5) % 256);
      Delay[1] = (byte)((delay * 5) / 256);
      int gif = fileName.ToUpper().IndexOf(".GIF");//Constants.GIFFilename
      if (gif > 0) {
        fileName = fileName.Substring(0, gif);
      }
      try {
        string GifFile = path + fileName + ".GIF";
        if (File.Exists(GifFile))
          File.Delete(GifFile);
        MemoryStream MS = new MemoryStream();
        BinaryReader BR = new BinaryReader(MS);
        BinaryWriter BW = new BinaryWriter(new FileStream(GifFile, FileMode.Create));
        images[0].Save(MS, ImageFormat.Gif);
        byte[] B = MS.ToArray();
        B[10] = (byte)(B[10] & 0X78); //No global color table.
        BW.Write(B, 0, 13);
        BW.Write(GifAnimation);
        WriteGifImg(B, BW);
        for (int I = images.Count - 2; I > 1; I--) {
          MS.SetLength(0);
          images[I].Save(MS, ImageFormat.Gif);
          B = MS.ToArray();
          WriteGifImg(B, BW);
        }
        if (AddReverse)
          for (int I = 2; I < images.Count - 1; I++) {
            MS.SetLength(0);
            images[I].Save(MS, ImageFormat.Gif);
            B = MS.ToArray();
            WriteGifImg(B, BW);
          }
        BW.Write(B[B.Length - 1]);
        BW.Close();
        MS.Dispose();
        StaticFormsCalls.ShowMessage("Created animated gif at: " + GifFile);
        System.Diagnostics.Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", GifFile);
        while (images.Count > 0) {
          Image im = images[0];
          images.RemoveAt(0);
          im.Dispose();
        }
        GC.Collect();
      }
      catch { }
      finally { }
    }

  }

}
