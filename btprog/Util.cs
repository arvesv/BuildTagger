using System.Text.Json;
using System.Text.Json.Serialization;
using LibGit2Sharp;

namespace btprog
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
                Folder = opts.Directory,
                Commit = repo.Head.TrackedBranch.Tip.Id.ToString(7),
                Branch = repo.Head.TrackedBranch.FriendlyName

            };


            string s = JsonSerializer.Serialize(x);
            File.WriteAllText(Path.Join(opts.Directory, VCFileName), s);

            
            return 0;
        }


        public static string? FindParentFolder(string startFolder, Func<string, bool> check)
        {

            var dirInfo = new DirectoryInfo(startFolder);

            do
            {
                if (check(dirInfo.FullName))
                {
                    return dirInfo.FullName;
                }

                if (dirInfo.Parent == null)
                {
                    return null;
                }
                else
                {
                    dirInfo = dirInfo.Parent;
                }
            } while (true);
        }


        internal static int CreateVersionFile(WriteVerOptions opts)
        {
            return 0;
        }
    }
}