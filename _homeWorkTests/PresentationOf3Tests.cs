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
    public class PresentationOf3Tests
    {
        PresentationOf3 _presentation;

        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _presentation = new PresentationOf3();
        }

        //測試
        [TestMethod()]
        public void ChangeButton4Test()
        {
            _presentation.ChangeButton4();
            Assert.AreEqual(false, _presentation.IsButton4);
            Assert.AreEqual("新增", _presentation.TextButton5);
        }

        //測試
        [TestMethod()]
        public void ChangeButton4FromListTest()
        {
            _presentation.ChangeButton4FromList();
            Assert.AreEqual(true, _presentation.IsButton4);
            Assert.AreEqual("儲存", _presentation.TextButton5);
        }

        //測試
        [TestMethod()]
        public void CheckConditionTest()
        {
            _presentation.IsSpace = true;
            _presentation.IsChange = false;
            _presentation.IsDate = true;
            Assert.AreEqual(false, _presentation.CheckCondition(0));
            Assert.AreEqual(true, _presentation.CheckCondition(1));
        }
    }
}