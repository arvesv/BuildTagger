using CommandLine;

namespace BuildTagger
{
    [Verb("gitinfo", HelpText = "Dump Gut workspace information into VCInfo.json")]
    public class GitInfoOptions
    {
        [Option(Required = true, HelpText = "Folder to analyze")]
        public string Directory { get; init; } = "";

        [Option(HelpText = "Input filename.")]
        public string FileName { get; init; } = "VCInfo";
    }


    [Verb("writever", HelpText = "Dump Gut workspace information into VCInfo.json")]

    public class WriteVerOptions
    {
        [Option("directory", Required = false, HelpText = "Input filename.")]
        public string Directory { get; set; } = "";

    }
}


