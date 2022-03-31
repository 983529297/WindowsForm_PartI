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
    public class PresentationModelTests
    {
        PresentationModel _presentation;

        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _presentation = new PresentationModel();
        }

        //測試
        [TestMethod()]
        public void SetButtonTest()
        {
            _presentation.SetButton(0);
            Assert.AreEqual(false, _presentation._button1Enable);
            _presentation.SetButton(1);
            Assert.AreEqual(true, _presentation._button1Enable);
        }

        //測試
        [TestMethod()]
        public void IsColumnIndexTest()
        {
            _presentation.IsColumnIndex(0);
            Assert.AreEqual(true, _presentation._columnIndex);
            _presentation.IsColumnIndex(1);
            Assert.AreEqual(false, _presentation._columnIndex);
        }
    }
}