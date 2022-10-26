using BepInEx;
using Kitchen;
using LiveSplit;
using System.Text;
using Unity.Entities;


namespace RemovePrepTime
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

        }
        private void Update()
        {
            bool liveSplitOn = Preferences.Get<bool>(Pref.LiveSplitEnabled);
            if (!liveSplitOn)
            {
                return;
            }
            if (plateupSystemBase == null)
            {
                plateupSystemBase =  World.DefaultGameObjectInjectionWorld.GetExistingSystem<GenericSystemBase>();
                if (plateupSystemBase == null)
                {
                    return;
                }
                Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is ready for game time!");
            }
            if (!plateupSystemBase.HasSingleton<SDay>())
            {
                return;
            }
            SDay sday = plateupSystemBase.GetSingleton<SDay>();

            bool endDay = plateupSystemBase.HasSingleton<SIsNightFirstUpdate>();
            if (endDay)
            {
                Send("pausegametime");
                return;
            }
            bool startDay = plateupSystemBase.HasSingleton<SIsDayFirstUpdate>();
            if (startDay)
            {
                if (sday.Day==1)
                {
                    Send("setgametime 0.0");
                }
                // else
                {
                    Send("unpausegametime");
                }
            }
        }
        private void Send(string message)
        {
            bool flag = !LiveSplit.LiveSplit.IsConnected;
            if (!flag)
            {
                try
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(message + "\r\n");
                    LiveSplit.LiveSplit.Socket.Send(bytes);
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    bool flag2 = LiveSplit.LiveSplit.Socket != null;
                    if (flag2)
                    {
                        LiveSplit.LiveSplit.Disconnect(true);
                    }
                    Logger.LogWarning(ex.ErrorCode);
                }
            }
        }
        private static GenericSystemBase plateupSystemBase = null;
    }
}
