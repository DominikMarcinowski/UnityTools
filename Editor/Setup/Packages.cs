using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace dm
{
    public static class Packages
    {
        public static async Task ReplacePackagesFromGist(string id, string user = "DominikMarcinowski")
        {
            var url = GetGistUrl(id, user);
            var content = await GetGistContents(url);
            ReplacePackageFile(content);
        }

        public static void InstallUnityPackage(string packageName) =>
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");

        private static void ReplacePackageFile(string contents)
        {
            var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }

        private static string GetGistUrl(string id, string user = "DominikMarcinowski") =>
            $"https://gist.githubusercontent.com/{user}/{id}/raw";

        private static async Task<string> GetGistContents(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}