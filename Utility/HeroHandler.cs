using System;
using System.Numerics;

namespace HellPie_Tools.Utility;

public class HeroHandler
{
    public static Vector3 GetCurrentCoords()
    {
        var posAddr = PointerCalculations.GetPointerAddress(0x4CB37A0, new[] { 0x3D8, 0x378, 0x130, 0x1D0 });
        ProcessHandler.TryRead(posAddr + 0x0, out float x, false, "X-Coord");
        ProcessHandler.TryRead(posAddr + 0x4, out float y, false, "Y-Coord");
        ProcessHandler.TryRead(posAddr + 0x8, out float z, false, "Z-Coord");
        return new Vector3(x, y, z);
    }

    public static void SetCoords(float x, float y, float z)
    {
        var posAddr = PointerCalculations.GetPointerAddress(0x4CB37A0, new[] { 0x3D8, 0x378, 0x130, 0x1D0 });
        ProcessHandler.WriteData(posAddr + 0x0, BitConverter.GetBytes(x), "X-Coord");
        ProcessHandler.WriteData(posAddr + 0x4, BitConverter.GetBytes(y), "Y-Coord");
        ProcessHandler.WriteData(posAddr + 0x8, BitConverter.GetBytes(z), "Z-Coord");
    }
}