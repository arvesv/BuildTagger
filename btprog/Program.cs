using BuildTagger;
using CommandLine;

return Parser.Default.ParseArguments<GitInfoOptions, WriteVerOptions>(args).MapResult(
    (GitInfoOptions opts) => Util.RunGitInfo(opts),
    (WriteVerOptions opts) => Util.CreateVersionFile(opts),
    _ => 1);