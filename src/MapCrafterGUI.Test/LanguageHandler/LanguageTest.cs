using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapCrafterGUI.LanguageHandler;
using System.Windows.Forms;

namespace MapCrafterGUI.Test.LanguageHandler
{
    [TestClass]
    public class LanguageTest
    {
        private enum EnumTest
        {
            [System.ComponentModel.Description("Description for item 1")]
            Item1,

            Item2,

            [System.ComponentModel.Description("Description for item 3")]
            Item3,

            Item4
        }

        public LanguageTest()
        {
            this.LanguageFileTeste = new LanguageFile();
            LanguageFileTeste.Fields.Add("frmMain.Text", "MapCrafter v{Version}");
            LanguageFileTeste.Fields.Add("frmMain.btnAddWorld.Text", "Add World");
            LanguageFileTeste.Fields.Add("frmMain.btnAddMap.Text", "Add Map nº {MapNumber}");
            LanguageFileTeste.Fields.Add("frmMain.Info.TestInfo", "This is a info for a test");
            LanguageFileTeste.Fields.Add("frmMain.Erro.ErroWithMetadata", "This is a error message.{LineBreak}Date: {Data}");
            LanguageFileTeste.Fields.Add("EnumTest.Item3", "Localized description for item 3");
            LanguageFileTeste.Fields.Add("EnumTest.Item4", "Localized description for item 4");
            LanguageFile.instance = this.LanguageFileTeste;

            this.FormTest = new Form() { Name = "frmMain" };
            this.ButtonAddWorld = new Button() { Name = "btnAddWorld", Parent = this.FormTest };
            this.ButtonAddMap = new Button() { Name = "btnAddMap", Parent = this.FormTest };
            this.ButtonAddTest = new Button() { Name = "btnTest", Parent = this.FormTest };
        }

        private LanguageFile LanguageFileTeste;
        private Form FormTest;
        private Button ButtonAddWorld;
        private Button ButtonAddMap;
        private Button ButtonAddTest;

        [TestMethod]
        public void GetLocalizedDescriptionForEnumTest()
        {
            string successResult = "Description for item 1";

            string result = Language.GetLocalizedDescriptionForEnum(EnumTest.Item1);

            Assert.AreEqual<string>(successResult, result);
        }
        [TestMethod]
        public void GetLocalizedDescriptionForEnumTest2()
        {
            string result = Language.GetLocalizedDescriptionForEnum(EnumTest.Item2);

            Assert.AreEqual<string>(string.Empty, result);
        }
        [TestMethod]
        public void GetLocalizedDescriptionForEnumTest3()
        {
            string successResult = "Localized description for item 3";
            string result = Language.GetLocalizedDescriptionForEnum(EnumTest.Item3);

            Assert.AreEqual<string>(successResult, result);
        }
        [TestMethod]
        public void GetLocalizedDescriptionForEnumTest4()
        {
            string successResult = "Localized description for item 4";
            string result = Language.GetLocalizedDescriptionForEnum(EnumTest.Item4);

            Assert.AreEqual<string>(successResult, result);
        }

        [TestMethod]
        public void GetLocalizedFieldForControlTest()
        {
            string successResult = "Add World";
            string result = Language.GetLocalizedFieldForControl(this.ButtonAddWorld, LanguageControlField.Text);

            Assert.AreEqual<string>(successResult, result);
        }
        [TestMethod]
        public void GetLocalizedFieldForControlTest_DefaultValue()
        {
            string defaultValue = "Default string loaded";
            string result = Language.GetLocalizedFieldForControl(new Control(), LanguageControlField.Text, defaultValue);

            Assert.AreEqual<string>(defaultValue, result);
        }
        [TestMethod]
        public void GetLocalizedFieldForControlTest_Metadata()
        {
            string successResult = "MapCrafter v0.1a";
            object metadata = new { Version = "0.1a" };

            string result = Language.GetLocalizedFieldForControl(this.FormTest, LanguageControlField.Text, metadata);

            Assert.AreEqual<string>(successResult, result);
        }
        [TestMethod]
        public void GetLocalizedFieldForControlTest_ControlNull()
        {
            string result = Language.GetLocalizedFieldForControl(null, LanguageControlField.Text);

            Assert.AreEqual<string>(string.Empty, result);
        }

        [TestMethod]
        public void GetLocalizedGenericFieldForControlTest()
        {
            string successResult = "This is a info for a test";

            string result = Language.GetLocalizedGenericFieldForControl(this.FormTest, LanguageGenericField.Info, "TestInfo");

            Assert.AreEqual<string>(successResult, result);
        }
        [TestMethod]
        public void GetLocalizedGenericFieldForControlTest_DefaultValue()
        {
            string defaultValue = "Erro default value";
            string result = Language.GetLocalizedGenericFieldForControl(this.FormTest, LanguageGenericField.Erro, "Erro1", defaultValue);

            Assert.AreEqual<string>(defaultValue, result);
        }
        [TestMethod]
        public void GetLocalizedGenericFieldForControlTest_Metadata()
        {
            string successResult = string.Format("This is a error message.{0}Date: {1}", Environment.NewLine, DateTime.Now.ToString("yyyy-MM-dd"));
            object metadata = new { LineBreak = Environment.NewLine, Data = DateTime.Now.ToString("yyyy-MM-dd") };

            string result = Language.GetLocalizedGenericFieldForControl(this.FormTest, LanguageGenericField.Erro, "ErroWithMetadata", metadata);
        }
        [TestMethod]
        public void GetLocalizedGenericFieldForControlTest_ControlNull()
        {
            string result = Language.GetLocalizedGenericFieldForControl(null, LanguageGenericField.Info, "TestIfno");

            Assert.AreEqual<string>(string.Empty, result);
        }

        [TestMethod]
        public void SetLocalizedField()
        {
            string successResult = "Add World";
            this.ButtonAddWorld.SetLocalizedField(LanguageControlField.Text);

            Assert.AreEqual<string>(successResult, this.ButtonAddWorld.Text);
        }
        [TestMethod]
        public void SetLocalizedField_DefaultValue()
        {
            string successResult = "Default value";

            this.ButtonAddTest.SetLocalizedField(LanguageControlField.Text, successResult);

            Assert.AreEqual<string>(this.ButtonAddTest.Text, successResult);
        }
        [TestMethod]
        public void SetLocalizedField_Metadata()
        {
            string successResult = "Add Map nº 15";
            object metadata = new { MapNumber = 15 };

            this.ButtonAddMap.SetLocalizedField(LanguageControlField.Text, metadata);

            Assert.AreEqual<string>(successResult, this.ButtonAddMap.Text);
        }
        [TestMethod]
        public void SetLocalizedField_ControlNull()
        {
            Language.SetLocalizedField(null, LanguageControlField.Text);
        }
    }
}
