using System.Collections.Generic;

namespace BiFurcation {

  public interface IFunctionsView: IView {

    void fillXValues(List<decimal> points);
    Control4FunctionsView Control4FunctionsView {
      set;
    }

  }

}
