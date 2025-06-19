using BepInEx;
using EntityStates.Chef;
using System.Diagnostics;

namespace FixYesChef
{
  [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
  public class Main : BaseUnityPlugin
  {
    public const string PluginGUID = PluginAuthor + "." + PluginName;
    public const string PluginAuthor = "Nuxlar";
    public const string PluginName = "FixYesChef";
    public const string PluginVersion = "1.0.0";

    internal static Main Instance { get; private set; }
    public static string PluginDirectory { get; private set; }

    public void Awake()
    {
      Instance = this;

      Stopwatch stopwatch = Stopwatch.StartNew();

      Log.Init(Logger);

      On.EntityStates.Chef.IceCube.OnEnter += ReplaceState;

      stopwatch.Stop();
      Log.Info_NoCallerPrefix($"Initialized in {stopwatch.Elapsed.TotalSeconds:F2} seconds");
    }

    private void ReplaceState(On.EntityStates.Chef.IceCube.orig_OnEnter orig, IceCube self)
    {
      self.outer.SetState(new IceBox());
    }

  }
}