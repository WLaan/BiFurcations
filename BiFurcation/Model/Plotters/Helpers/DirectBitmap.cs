using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace BiFurcation {

  public class DirectBitmap : IDisposable {
    public Bitmap Bitmap { get; set; }
    public Int32[] Bits { get; private set; }
    public ColorIndex[,] usedColorIndices;
    public bool Disposed { get; private set; }
    public int Height { get; private set; }
    public int Width { get; private set; }

    public List<SmoozeType> CalculatedTypes = new List<SmoozeType>();
    public bool Calced_CLR_Z = false;

    protected GCHandle BitsHandle { get; private set; }

    public DirectBitmap(int w, int h) {
      Width = w;
      Height = h;
      Bits = new Int32[Width * Height];
      usedColorIndices = new ColorIndex[w, h];
      BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
      Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
    }
    public DirectBitmap(int w, int h, bool linePlotUse) {
      Width = w;
      Height = h;
      Bits = new Int32[Width * Height];
      if (!linePlotUse)
        usedColorIndices = new ColorIndex[w, h];
      BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
      Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
    }

    public void SetPixel(int x, int y, Color colour) {
      int index = x + (y * Width);
      int col = colour.ToArgb();
      try {
        if (index>0 && index < Bits.Length)
          Bits[index] = col;
      }
      catch { }
    }
    public void SetLine(double xr0, double yr0, double Xr, double Yr, Color color) {
      SetPixel((int)xr0, (int)yr0, color);
      if (xr0 == Xr && yr0 == Yr) return;

      if (Math.Abs(Yr - yr0) < Math.Abs(Xr - xr0)) {
        double dy = 1.0 * (Yr - yr0) / (Xr - xr0);//dy=0 => horizontal line
        double signX = (Xr - xr0) / Math.Abs(xr0 - Xr);
        for (int dx = 1; dx< Math.Abs(xr0 - Xr) - 1; dx++) {
          double yi = yr0 + signX * dx *  dy;
          SetPixel((int)(xr0 + signX * dx), (int)yi, color);
        }
      }
      else {
        double dx = 1.0 * (Xr - xr0) / (Yr - yr0);//dx=0 => vertical line
        double signY = (Yr - yr0) / Math.Abs(yr0 - Yr);
        for (int dy = 1; dy< Math.Abs(yr0 - Yr) - 1; dy++) {
          double xi = xr0 + signY * dx * dy;
          SetPixel((int)xi, (int)(yr0 + signY * dy), color);
        }
      }
      SetPixel((int)Xr, (int)Yr, color);
    }

    public Color GetPixel(int x, int y) {
      int index = x + (y * Width);
      int col = Bits[index];
      Color result = Color.FromArgb(col);

      return result;
    }
    public void Reset() {
      if (usedColorIndices != null)
        usedColorIndices = new ColorIndex[Width, Height];
      CalculatedTypes.Clear();
      Calced_CLR_Z = false;
    }

    public void Dispose() {
      if (Disposed) return;
      Disposed = true;
      Bitmap.Dispose();
      BitsHandle.Free();
    }

  }

}
