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
    public class Model1Tests
    {
        Model1 _model;

        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model1();
        }

        //測試
        [TestMethod()]
        public void FlagTest()
        {
            int test1 = _model.Flag(1, false);
            int test2 = _model.Flag(2, true);
            Assert.AreEqual(1, test1);
            Assert.AreEqual(3, test2);
        }

        //測試
        [TestMethod()]
        public void CreateCopyTest()
        {
            _model.CreateSite();
            Assert.AreEqual(2, _model.copy.Count);
        }

        //測試
        [TestMethod()]
        public void NameCheckTest()
        {
            _model.NameCheck();
            Assert.AreEqual("", _model.nameError);
        }

        //測試
        [TestMethod()]
        public void DateCheckTest()
        {
            _model.DateCheck();
            Assert.AreEqual("", _model.dateError);
        }

        //測試
        [TestMethod()]
        public void CanPassTest()
        {
            _model.nameError = "";
            _model.dateError = "";
            Assert.AreEqual(false, _model.CanPass());
            _model.nameError = "e";
            Assert.AreEqual(true, _model.CanPass());
        }

        //測試
        [TestMethod()]
        public void AddDataGridView3Test()
        {
            _model.CreateSite();
            _model.receiveForm.Add(_model.copy[0][0]);
            _model.AddDataGridView3();
            Assert.AreEqual(1, _model._dataGridView3temp.Count);
        }

        //測試
        [TestMethod()]
        public void CheckDeleteTest()
        {
            _model.CreateSite();
            _model.delete = new string[] { "291702" };
            Assert.AreEqual(0, _model.CheckDelete());
            _model.delete = new string[] { "291502" };
            Assert.AreEqual(1, _model.CheckDelete());
            _model.delete = new string[] { "55" };
            Assert.AreEqual(-1, _model.CheckDelete());
        }

        //測試
        [TestMethod()]
        public void FindNumberTest()
        {
            _model.CreateSite();
            string[] error = new string[1] { "ERROR" };
            Assert.AreEqual(_model.copy[0][1], _model.FindNumber("291702"));
        }

        //測試
        [TestMethod()]
        public void UpdateCopyTest()
        {
            _model.CreateSite();
            string[] set = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            _model.UpdateCopy(set, "291702", "開課");
            Assert.AreEqual("", _model.copy[0][1][0]);
        }

        //測試
        [TestMethod()]
        public void AddNewCourseTest()
        {
            _model.CreateSite();
            string[] set = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            _model.AddNewCourse(set, "資工三");
            Assert.AreEqual("", _model.copy[0][_model.copy[0].Count - 1][0]);
            _model.AddNewCourse(set, "電子三甲");
            Assert.AreEqual("", _model.copy[1][_model.copy[1].Count - 1][0]);
        }

        //測試
        [TestMethod()]
        public void CheckClassNameTest()
        {
            _model.className = "資工三";
            Assert.AreEqual(true, _model.CheckClassName());
            _model.className = "電子三甲";
            Assert.AreEqual(false, _model.CheckClassName());
        }

        //測試
        [TestMethod()]
        public void GetNumberAndNameTest()
        {
            _model.CreateSite();
            string[] set = new string[] { _model.copy[0][1][0], _model.copy[0][1][1] };
            Assert.AreEqual(set[0], _model.GetNumberAndName(0, 1)[0]);
            Assert.AreEqual(set[1], _model.GetNumberAndName(0, 1)[1]);
        }

        //測試
        [TestMethod()]
        public void AddNewClassTest()
        {
            _model.CreateSite();
            _model.AddNewClass("https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2676", "資工一", 2);
            Assert.AreEqual(3, _model.copy.Count);
        }
    }
}