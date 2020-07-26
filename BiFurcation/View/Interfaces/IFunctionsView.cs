using System.Collections.Generic;

namespace BiFurcation {

  public interface IFunctionsView: IView {

    void FillXValues(List<decimal> points);
    Control4FunctionsView Control4FunctionsView {
      set;
    }

  }

}
