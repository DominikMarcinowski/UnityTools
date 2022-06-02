using System.IO;
using UnityEditor;
using UnityEngine;

namespace dm
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Packages/3d")]
        public static async void SetupPackages3d() => await Packages.ReplacePackagesFromGist("6c43fe96d9f614c0817ee0240b4affc9");

        [MenuItem("Tools/Setup/Packages/2d")]
        public static async void SetupPackages2d() => await Packages.ReplacePackagesFromGist("6c43fe96d9f614c0817ee0240b4affc9");

        [MenuItem("Tools/Setup/Directories")]
        public static void SetupDirectories()
        {
            // Remove everything inside project
            var directory = new DirectoryInfo(Application.dataPath);
            foreach (var file in directory.EnumerateFiles()) file.Delete();
            foreach (var dir in directory.EnumerateDirectories()) dir.Delete(true);

            // Create basic directory structure
            CreateDirectories("_Project", "Scripts", "Art", "Scenes");
            AssetDatabase.Refresh();
        }

        public static void CreateDirectories(string root, params string[] directories)
        {
            var fullPath = Path.Combine(Application.dataPath, root);
            foreach (string directory in directories)
                Directory.CreateDirectory(Path.Combine(fullPath, directory));
        }
    }
}
