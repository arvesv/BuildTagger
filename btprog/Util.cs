using LibGit2Sharp;

namespace btprog
{
    internal static class Util
    {
        internal static int RunGitInfo(GitInfoOptions opts)
        {
            using var repo = new Repository(opts.Directory);

            var sha = repo.Head.TrackedBranch.Tip.Id.ToString(7);
            var branch = repo.Head.TrackedBranch.FriendlyName;

            
 
            Console.WriteLine(opts.Directory);
            return 0;

        }



        internal static int CreateVersionFile(WriteVerOptions opts)
        {



            return 0;
        }
    }
}
