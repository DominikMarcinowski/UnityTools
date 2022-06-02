using System.IO;
using UnityEngine;

namespace dm
{
    public static class Directories
    {
        public static void CleanAssets()
        {
            var directory = new DirectoryInfo(Application.dataPath);
            foreach (var file in directory.EnumerateFiles()) file.Delete();
            foreach (var dir in directory.EnumerateDirectories()) dir.Delete(true);
        }

        public static void CreateDirectories(string root, params string[] directories)
        {
            var fullPath = Path.Combine(Application.dataPath, root);
            foreach (string directory in directories)
                Directory.CreateDirectory(Path.Combine(fullPath, directory));
        }
    }

}
