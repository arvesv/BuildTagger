using System.Text.Json;
using LibGit2Sharp;

namespace BuildTagger
{
    public class VersionControlInfo
    {
        public string Folder { get; init; } = string.Empty;
        public string Commit { get; init; } = string.Empty;
        public string Branch { get; init; } = string.Empty;
    }


    public static class Util
    {
        public const string VCFileName = "VCInfo.json";

        public static int RunGitInfo(GitInfoOptions opts)
        {
            if (!Directory.Exists(opts.Directory))
            {
                Console.WriteLine($"Directory {opts.Directory} does not exist. Can't extract Git info");
                return 1;
            }

            using var repo = new Repository(opts.Directory);

            var x = new VersionControlInfo
            {
                Folder = GetBaseDirectoryName(opts.Directory),
                Commit = repo.Head.Tip.Id.ToString(7),
                Branch = RemoveLeadingPrefix(repo.Refs.Head.TargetIdentifier, "refs/heads/")
            };

            string s = JsonSerializer.Serialize(x);
            File.WriteAllText(Path.Join(opts.Directory, VCFileName), s);

            return 0;
        }


        public static int CreateVersionFile(WriteVerOptions c)
        {
            return 0;
        }

        public static string RemoveLeadingPrefix(string s, string prefix) => s.StartsWith(prefix) ? s[prefix.Length..] : s;

        public static string GetBaseDirectoryName(string path) => (new DirectoryInfo(path)).Name;

        public static string? FindParentFolder(string startFolder, Func<string, bool> check)
        {
            var dirInfo = new DirectoryInfo(startFolder);

            for (; ; )
            {
                if (check(dirInfo.FullName))
                {
                    return dirInfo.FullName;
                }

                dirInfo = dirInfo.Parent;

                if (dirInfo == null)
                {
                    return null;
                }
            }
        }

    }
}