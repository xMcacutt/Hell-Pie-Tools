using System.Linq;
using System.Numerics;
using HellPie_Tools.Utility;
using PropertyChanged;

namespace HellPie_Tools;

[AddINotifyPropertyChangedInterface]
public class PositionStuffVM
{
    public string AbsoluteXString { get; set; }
    public string AbsoluteYString { get; set; }
    public string AbsoluteZString { get; set; }
    
    public string RelativeXString { get; set; }
    public string RelativeYString { get; set; }
    public string RelativeZString { get; set; }

    public PositionStuffVM()
    {
        AbsoluteXString = "0.0";
        AbsoluteYString = "0.0";
        AbsoluteZString = "0.0";
        RelativeXString = "0.0";
        RelativeYString = "0.0";
        RelativeZString = "0.0";
    }

    public void GetCoords()
    {
        var coords = HeroHandler.GetCurrentCoords();
        AbsoluteXString = coords.X.ToString();
        AbsoluteYString = coords.Y.ToString();
        AbsoluteZString = coords.Z.ToString();
    }

    public void SetCoords()
    {
        var b = new bool[6];
        b[0] = float.TryParse(AbsoluteXString, out var absX);
        b[1] = float.TryParse(AbsoluteYString, out var absY);
        b[2] = float.TryParse(AbsoluteZString, out var absZ);
        b[3] = float.TryParse(RelativeXString, out var relX);
        b[4] = float.TryParse(RelativeYString, out var relY);
        b[5] = float.TryParse(RelativeZString, out var relZ);
        if (b.Any(x => !x))
            return;
        HeroHandler.SetCoords(absX + relX, absY + relY, absZ + relZ);
    }
    
}