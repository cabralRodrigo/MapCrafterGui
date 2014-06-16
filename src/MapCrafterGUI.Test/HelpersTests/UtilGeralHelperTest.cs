using MapCrafterGUI.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapCrafterGUI.Test.HelpersTests
{
    [TestClass]
    public class UtilHelperTest
    {
        [TestMethod]
        public void StringReplaceWithMetadataTest()
        {
            string pattern = "This is a {NameOfObject}. This is a {NameOfAction}. I can replace integers too, look: {IntValue}";
            object patternFiller = new { NameOfObject = "string", NameOfAction = "test", IntValue = 15 };

            string successresult = "This is a string. This is a test. I can replace integers too, look: 15";

            string result = UtilHelper.StringReplaceWithMetadata(pattern, patternFiller);

            Assert.AreEqual<string>(result, successresult);
        }
    }
}
