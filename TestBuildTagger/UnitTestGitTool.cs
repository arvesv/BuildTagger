using System.Diagnostics;
using btprog;
using Microsoft.VisualBasic.CompilerServices;

namespace TestBuildTagger
{
    [TestClass]
    public class TestGitTool
    {
        [TestMethod]
        public void TestGetShaForDirectory()
        {
            // A little 'hacky' way for finding the root Git folder for this project,
            var gitDir = Util.FindParentFolder(
                Directory.GetCurrentDirectory(),
                d => Directory.Exists(Path.Join(d, ".git")));


            // Delete any previous runs
            if(File.Exists(Path.Join(gitDir, Util.VCFileName)))
                Directory.Delete(Util.VCFileName);

            // Should return 0 if no errors
            Assert.AreEqual(0, Util.RunGitInfo(new GitInfoOptions { Directory = gitDir }));



        }
    }
}