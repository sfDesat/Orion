using BepInEx;
using System.IO;
using System;

namespace Orion
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static string PluginPath { get; }

        public void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            // Locate Plugin Directory
            string appPath = System.IO.Path.GetDirectoryName(Info.Location);
            string appPathMinus20 = appPath.Remove(appPath.Length - 20);

            Logger.LogInfo($"The appPath is {appPath}");
            Logger.LogInfo($"The appPathMinus20 is {appPathMinus20}");

            // Duplicate Orion file to Expansion
            string sourceFile = appPathMinus20 + @"\sfDesat-Orion\orion\orion";
            string destinationFile = appPathMinus20 + @"\HolographicWings-LethalExpansion\LethalExpansion\Modules\orion";

            Logger.LogInfo($"The sourceFile is {sourceFile}");
            Logger.LogInfo($"The destinationFile is {destinationFile}");

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                Logger.LogInfo(iox.Message);
            }

            // Remove Template file from Expansion
            string deleteFile = appPathMinus20 + @"\HolographicWings-LethalExpansion\LethalExpansion\Modules\";
            string authorsFile = "templatemod";

            try
            {
                // Check if file exists with its full path
                if (File.Exists(Path.Combine(deleteFile, authorsFile)))
                {
                    // If file found, delete it
                    File.Delete(Path.Combine(deleteFile, authorsFile));
                    Logger.LogInfo($"templatemod File deleted.");
                }
                else Logger.LogInfo($"templatemod File not found");
            }
            catch (IOException ioExp)
            {
                Logger.LogInfo(ioExp.Message);
            }

            Console.ReadKey();
        }


    }
}
