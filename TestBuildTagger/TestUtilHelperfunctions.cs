using BuildTagger;

namespace TestBuildTagger
{
    [TestClass]
    public class TestUtil
    {
        [TestMethod]
        public void TestRemovePrefix()
        {
            string s = Util.RemoveLeadingPrefix("kakemonster", "kake");

            Assert.AreEqual("monster", s);
        }

        [TestMethod]
        public void TestRemovePrefixDontRemove()
        {
            string s = Util.RemoveLeadingPrefix("kakemonster", "kaka");

            Assert.AreEqual("kakemonster", s);
        }

        [TestMethod]
        public void TestGetBaseDirectoryName()
        {
            string dir = Util.GetBaseDirectoryName(@"c:\andeby\beboer");

            Assert.AreEqual("beboer", dir);


        }

    

    }
}