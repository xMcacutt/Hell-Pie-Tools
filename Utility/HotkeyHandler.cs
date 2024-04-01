using System;
using System.Windows;
using System.Windows.Input;
using NHotkey;
using NHotkey.Wpf;

namespace HellPie_Tools.Utility;

public class HotkeyHandler
{
    public static void SetupHotkeys()
    {
        #pragma warning disable CA1416
        try
        {
            HotkeyManager.Current.AddOrReplace("getPos", Key.G, ModifierKeys.Alt, OnKeyPress);
            HotkeyManager.Current.AddOrReplace("setPos", Key.P, ModifierKeys.Alt, OnKeyPress);
        }
        catch
        {
            MessageBox.Show(
                @"Global hotkeys may be disabled due to conflicts. Check running apps for conflicting global hotkeys.");
        }
        #pragma warning restore CA1416
    }

    private static void OnKeyPress(object sender, HotkeyEventArgs e)
    {
        switch (e.Name)
        {
            case "getPos":
                try
                {
                    (Application.Current.MainWindow.DataContext as PositionStuffVM).GetCoords();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case "setPos":
                (Application.Current.MainWindow.DataContext as PositionStuffVM).SetCoords();
                break;
        }
    }
}