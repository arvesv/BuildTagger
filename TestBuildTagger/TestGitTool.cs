using BuildTagger;

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


            var vcinfopath = Path.Join(gitDir, Util.VCFileName);


            // Delete any previous runs
            if (File.Exists(vcinfopath)) File.Delete(vcinfopath);

            // Should return 0 if no errors
            Assert.AreEqual(0, Util.RunGitInfo(new GitInfoOptions { Directory = gitDir }));



        }
    }
}