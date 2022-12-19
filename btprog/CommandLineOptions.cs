using CommandLine;

namespace btprog
{
    [Verb("gitinfo",HelpText = "Dump Gut workspace information into VCInfo.json")]
    public  class GitInfoOptions
    {
        public GitInfoOptions()
        {
            Directory = "";

        }
        [Option("directory", Required = true, HelpText = "Input filename.")]
        public string Directory { get; set; }
    }


    [Verb("writever", HelpText = "Dump Gut workspace information into VCInfo.json")]

    public class WriteVerOptions
    {
        [Option("directory", Required = false, HelpText = "Input filename.")]
        public string Directory { get; set; }

    }
}


