using System.Drawing;

namespace BiFurcation {

  public interface ICombined:IView {

    void rescanExamples();
    void presetType();
    void addExampleImage(int num, Bitmap map, string name, ExampleGroups group);

  }

}
