using System.Drawing;

namespace BiFurcation {

  public interface IDefineColors {

    Size GetSpreadImageSize {
      get;
    }
    void SetSpreadImage(Bitmap im);

  }

}
