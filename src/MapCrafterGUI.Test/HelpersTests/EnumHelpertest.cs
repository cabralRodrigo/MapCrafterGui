using MapCrafterGUI.Helpers;
using MapCrafterGUI.LanguageHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MapCrafterGUI.Test.HelpersTests
{
    [TestClass]
    public class EnumHelperTest
    {
        public EnumHelperTest()
        {
            var lang = new LanguageFile();

            lang.Fields["EnumTest.Element1"] = "First Element";
            lang.Fields["EnumTest.Element2"] = "Second Element";
            lang.Fields["EnumTest.Element3"] = "Third Element";

            LanguageFile.instance = lang;
        }

        private enum EnumTest
        {
            [System.ComponentModel.Description("The first element")]
            Element1,

            [System.ComponentModel.Description("The second element")]
            Element2,

            [System.ComponentModel.DefaultValue("The value of the third element")]
            Element3
        }

        [TestMethod]
        public void ConvertEnumToDictionaryTest()
        {
            Dictionary<int, string> success = new Dictionary<int, string>();
            success.Add(0, "Element1");
            success.Add(1, "Element2");
            success.Add(2, "Element3");

            var result = EnumHelper.ConvertEnumToDictionary<EnumTest>(false);

            CollectionAssert.AreEquivalent(success, result);
        }

        [TestMethod]
        public void ConvertEnumToDictionaryTest_Localized()
        {
            Dictionary<int, string> success = new Dictionary<int, string>();
            success.Add(0, "First Element");
            success.Add(1, "Second Element");
            success.Add(2, "Third Element");

            var result = EnumHelper.ConvertEnumToDictionary<EnumTest>(true);

            CollectionAssert.AreEquivalent(success, result);
        }

        [TestMethod]
        public void GetEnumDescriptionTest()
        {
            string success = "The second element";
            string result = EnumHelper.GetEnumDescription(EnumTest.Element2);

            Assert.AreEqual(success, result);
        }

        [TestMethod]
        public void GetEnumDescriptionTest_Null()
        {
            string result = EnumHelper.GetEnumDescription(EnumTest.Element3);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetEnumValue()
        {
            string success = "The value of the third element";
            string result = EnumHelper.GetEnumValue(EnumTest.Element3);

            Assert.AreEqual(success, result);
        }

        [TestMethod]
        public void GetEnumValue_Null()
        {
            string result = EnumHelper.GetEnumValue(EnumTest.Element1);

            Assert.AreEqual(null, result);
        }
    }
}
