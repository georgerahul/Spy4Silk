using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K2L.Spy.Framework.UT
{
    [TestClass]
    public class K2LSpyFramework_UT
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new Analyzer("OptoLyzer Studio.//WPFControl[@automationId='F4C2C53C-BB92-47CC-97E1-2FB7DB92DB5A']");
            var x1 = test.GetProperties();
            var x = test.GetMethods();
        }
    }
}