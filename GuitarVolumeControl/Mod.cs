using GDWeave;
using GuitarVolumeControl.Scripts;

namespace GuitarVolumeControl;

public class Mod : IMod
{
    public Config Config;
    private IModInterface modInterface;

    public Mod(IModInterface modInterface)
    {
        // init
        this.modInterface = modInterface;
        this.Config = modInterface.ReadConfig<Config>();

        // register script
        this.modInterface.RegisterScriptMod(new OptionsMenuScript());
        this.modInterface.RegisterScriptMod(new UserSaveScript());

        Log("general", "Loaded stedee.GuitarVolumeControl!");
    }

    public void Log(string name, string data)
    {
        this.modInterface.Logger.Information($"[GuitarVolumeControl.{name}] {data}");
    }

    public void Dispose()
    {
        // Cleanup anything you do here
    }
}
