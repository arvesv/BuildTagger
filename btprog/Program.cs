

using btprog;
using CommandLine;

return CommandLine.Parser.Default.ParseArguments<GitInfoOptions, WriteVerOptions>(args).MapResult(
    
    (GitInfoOptions opts) => Util.RunGitInfo(opts),
    _ => 1);



