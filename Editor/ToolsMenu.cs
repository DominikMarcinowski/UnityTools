using UnityEditor;

namespace dm
{
    public static class ToolsMenu
    {
        #region Setup

        [MenuItem("Tools/Setup/Create Default Folders", priority = 0)]
        public static void SetupDirectories()
        {
            Directories.CleanAssets();
            Directories.CreateDirectories("_Project", "Scripts", "Art", "Scenes");
            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/Setup/Replace Manifest", priority = 1)]
        public static async void SetupReplaceManifest() => await Packages.ReplacePackagesFromGist("6c43fe96d9f614c0817ee0240b4affc9");

        [MenuItem("Tools/Setup/Packages/New Input System")]
        public static void AddNewInputSystem() => Packages.InstallUnityPackage("inputsystem");

        [MenuItem("Tools/Setup/Packages/Post Processing")]
        public static void AddPostProcessing() => Packages.InstallUnityPackage("inputsystem");

        [MenuItem("Tools/Setup/Packages/Cinemashine")]
        public static void AddCinemashine() => Packages.InstallUnityPackage("cinemashine");

        #endregion
    }
}
