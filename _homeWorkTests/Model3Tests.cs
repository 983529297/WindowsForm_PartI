using Microsoft.VisualStudio.TestTools.UnitTesting;
using _homeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _homeWork.Tests
{
    [TestClass()]
    public class Model3Tests
    {
        Model1 _model;
        Model3 _model3;

        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model1();
            _model3 = new Model3(_model);
        }

        //操作
        private void Use()
        {
            _model.CreateSite();
            _model3.Content = _model.copy[0][1];
            _model3.GetCourseName();
            _model3.Change();
        }
        //測試
        [TestMethod()]
        public void ChangeTest()
        {
            Use();
            Assert.AreEqual("291702", _model3.TextTextBox1);
            Assert.AreEqual("體育", _model3.TextTextBox2);
            Assert.AreEqual("*", _model3.TextTextBox3);
            Assert.AreEqual("5", _model3.TextTextBox4);
            Assert.AreEqual("0.0", _model3.TextTextBox5);
            Assert.AreEqual("", _model3.TextTextBox6);
            Assert.AreEqual("", _model3.TextTextBox7);
            Assert.AreEqual("", _model3.TextTextBox8);
        }

        //測試
        [TestMethod()]
        public void ResetAllTest()
        {
            Use();
            _model3.ResetAll();
            Assert.AreEqual("", _model3.TextTextBox1);
            Assert.AreEqual("", _model3.TextTextBox2);
            Assert.AreEqual("", _model3.TextTextBox3);
            Assert.AreEqual("", _model3.TextTextBox4);
            Assert.AreEqual("", _model3.TextTextBox5);
            Assert.AreEqual("", _model3.TextTextBox6);
            Assert.AreEqual("", _model3.TextTextBox7);
            Assert.AreEqual("", _model3.TextTextBox8);
        }

        //測試
        [TestMethod()]
        public void CheckModeTest()
        {
            Assert.AreEqual(true, _model3.CheckMode("儲存"));
            Assert.AreEqual(false, _model3.CheckMode("新增"));
        }

        //測試
        [TestMethod()]
        public void CountTest()
        {
            _model.CreateSite();
            _model3.Content = _model.copy[0][1];
            _model3.GetCourseName();
            Assert.AreEqual("2", _model3.Count());
        }

        //測試
        [TestMethod()]
        public void FindNumberTest()
        {
            _model.CreateSite();
            _model3.GetCourseName();
            _model3.FindNumber("1");
            Assert.AreEqual(_model.copy[0][1], _model3.Content);
        }

        //測試
        [TestMethod()]
        public void GetCourseNameTest()
        {
            _model.CreateSite();
            _model3.GetCourseName();
            Assert.AreEqual("291702", _model3.CourseName[0][1][0]);
            Assert.AreEqual("體育", _model3.CourseName[0][1][1]);
        }

        //測試
        [TestMethod()]
        public void GetNumberAndNameTest()
        {
            _model.CreateSite();
            Assert.AreEqual("291702", _model3.GetNumberAndName(0, 1)[0]);
            Assert.AreEqual("體育", _model3.GetNumberAndName(0, 1)[1]);
        }

        //測試
        [TestMethod()]
        public void CheckTimeTest()
        {
            _model.CreateSite();
            _model3.Content = _model.copy[0][1];
            Assert.AreEqual(false, _model3.CheckTime(7));
        }

        //測試
        [TestMethod()]
        public void UpdateCopyTest()
        {
            _model.CreateSite();
            string[] set = new string[] {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            _model3.UpdateCopy(set, "291702", "開課");
            Assert.AreEqual("", _model.copy[0][1][0]);
        }

        //測試
        [TestMethod()]
        public void CheckBooleanTest()
        {
            Assert.AreEqual(true, _model3.CheckBoolean(""));
            Assert.AreEqual(false, _model3.CheckBoolean("1"));
        }

        //測試
        [TestMethod()]
        public void AddNewCourseTest()
        {
            _model.CreateSite();
            string[] set = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            _model3.GetCourseName();
            _model3.AddNewCourse(set, "資工三");
            Assert.AreEqual("", _model3.CourseName[0][_model3.CourseName[0].Count - 1][0]);
            Assert.AreEqual("", _model3.CourseName[0][_model3.CourseName[0].Count - 1][1]);
        }

        //測試
        [TestMethod()]
        public void CheckClassTest()
        {
            _model.CreateSite();
            _model3.GetCourseName();
            Assert.AreEqual(11, _model3.CheckClass("資工三"));
            Assert.AreEqual(36, _model3.CheckClass("電子三甲"));
        }

        //測試
        [TestMethod()]
        public void CheckChangeTest()
        {
            _model.CreateSite();
            _model3.Content = _model.copy[0][1];
            _model3.GetCourseName();
            _model3.Change();
            string[] set = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            Assert.AreEqual(true, _model3.CheckChange(set));
        }

        //測試
        [TestMethod()]
        public void CheckSpaceTest()
        {
            _model.CreateSite();
            _model3.Content = _model.copy[0][1];
            _model3.GetCourseName();
            _model3.Change();
            string[] set = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            Assert.AreEqual(false, _model3.CheckSpace(set));
        }

        //測試
        [TestMethod()]
        public void CountTimeTest()
        {
            string[] set = new string[] { "", "", "", "", "", "", "" };
            Assert.AreEqual("0", _model3.CountTime(set));
        }
    }
}