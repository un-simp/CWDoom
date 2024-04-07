using System.Collections;
using BepInEx;
using BepInEx.Logging;
using CWDoom.Hooks;
using On.Zorro.Recorder;

namespace CWDoom
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class CWDoom : BaseUnityPlugin
    {
        public static CWDoom Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;

        private void Awake()
        {
            Logger = base.Logger;
            Instance = this;

            Hook();

            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
        }

        internal static void Hook()
        {
            Logger.LogDebug("Hooking...");

            /*
             *  Subscribe with 'On.Class.Method += CustomClass.CustomMethod;' for each method you're patching.
             */
            On.Zorro.Recorder.FfmpegEncoder.RunFfmpeg += FFmpegHook.FfmpegEncoderOnRunFfmpeg;

            Logger.LogDebug("Finished Hooking!");
        }
        



        internal static void Unhook()
        {
            Logger.LogDebug("Unhooking...");

            /*
             *  Unsubscribe with 'On.Class.Method -= CustomClass.CustomMethod;' for each method you're patching.
             */
            

            Logger.LogDebug("Finished Unhooking!");
        }
    }
}
