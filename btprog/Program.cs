

using btprog;
using CommandLine;

return CommandLine.Parser.Default.ParseArguments<GitInfoOptions, WriteVerOptions>(args).MapResult(
    
    (GitInfoOptions opts) => Util.RunGitInfo(opts),
        (WriteVerOptions opts) => Util.WriteVerOptions(opts),
    _ => 1);



