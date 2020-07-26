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
    Bitmap SetFunctionImage {
      set;
      get;
    }

    void ShowNumber(int num, decimal x, List<DiagramSet> diagram);
    void SetCurrentIteration(int t);

  }

}
