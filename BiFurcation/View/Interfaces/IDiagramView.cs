using System.Drawing;
using System.Collections.Generic;

namespace BiFurcation {

  public interface IDiagramView: IView {

    string Parameter {
      set;
    }
    string FunctionText {
      set;
    }
    Bitmap setFunctionImage {
      set;
      get;
    }

    void showNumber(int num, decimal x, List<DiagramSet> diagram);
    void setCurrentIteration(int t);

  }

}
