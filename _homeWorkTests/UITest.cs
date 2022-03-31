using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace _homeWork.Tests
{
    [TestClass()]
    public class UItest
    {
        private Robot _robot;
        private const string APP_NAME = "D:/Mydata/視窗程式設計/copy/_homeWork/_homeWorkTests/bin/Debug/_homeWork.exe";
        private const string START_UP_FORM = "SetUpForm";

        // init
        [TestInitialize]
        public void Initialize()
        {
            //var projectName = "HTMLParser";
            //string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "D:\\Mydata\\視窗程式設計\\_homeWork - 複製\\"));
            //targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "_homeWork.exe");
            _robot = new Robot(APP_NAME, START_UP_FORM);

        }

        //關閉
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        //test
        [TestMethod()]
        public void FirstTest()
        {
            _robot.ClickButton("Course Selecting System");
            _robot.Sleep(1);
            _robot.SwitchTo("Form1");
            _robot.ClickButton("查看選課結果");
            _robot.SwitchTo("Form1");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 11, "選");
            _robot.Sleep(0.5);
            _robot.ClickTabControl("電子三甲");
            _robot.Sleep(0.5);
            _robot.ClickDataGridViewCellBy("_dataGridView2", 22, "選");
            _robot.ClickButton("確認送出");
            _robot.Sleep(2);
            _robot.CloseMessageBox();
            _robot.SwitchTo("Form4");
            _robot.ClickDataGridViewCellBy("_dataGridView3", 0, "退");
            _robot.ClickDataGridViewCellBy("_dataGridView3", 0, "退");
            _robot.SwitchTo("Form1");
            _robot.ClickTabControl("資工三");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 4, "選");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "選");
            _robot.ClickTabControl("電子三甲");
            _robot.ClickDataGridViewCellBy("_dataGridView2", 20, "選");
            _robot.ClickButton("確認送出");
            _robot.Sleep(2);
            _robot.CloseMessageBox();
            _robot.ClickTabControl("資工三");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 4, "選");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "選");
            _robot.ClickTabControl("電子三甲");
            _robot.ClickDataGridViewCellBy("_dataGridView2", 20, "選");
            _robot.ClickTabControl("資工三");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 2, "選");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 3, "選");
            _robot.ClickButton("確認送出");
            _robot.Sleep(2);
            _robot.CloseMessageBox();
        }

        //operation
        private void ChangeTest()
        {
            _robot.SwitchTo("Form3");
            _robot.Sleep(2);
            _robot.ClickListBox("_listBox1", "視窗程式設計");
            //_robot.ChangeText("_textBox1", "hi");
            _robot.ChangeText("_textBox1", "270915");
            _robot.ChangeText("_textBox5", "2");
            _robot.ChangeText("_comboBox2", "2");
            _robot.ChangeText("_comboBox3", "電子三甲");
            _robot.ChangeText("_textBox2", "物件導向分析與設計");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 2, "四");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 3, "四");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 5, "四");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 2, "一");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 2, "二");
        }

        //operation
        private void OpenTest()
        {
            _robot.ClickButton("Course Selecting System");
            _robot.Sleep(0.5);
            _robot.SwitchTo("SetUpForm");
            _robot.ClickButton("Course Management System");
        }

        //test
        [TestMethod()]
        public void SecondTest()
        {
            _robot.ClickButton("Course Management System");
            _robot.Sleep(2);
            _robot.SwitchTo("Form3");
            _robot.Sleep(0.5);
            _robot.ClickListBox("_listBox1", "視窗程式設計");
            _robot.ChangeText("_textBox6", "hi");
            _robot.AssertEnable("儲存", true);
            _robot.ChangeText("_textBox6", "");
            _robot.AssertEnable("儲存", false);
            _robot.ChangeText("_textBox6", "陳偉凱");
            _robot.ClickListBox("_listBox1", "視窗程式設計");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 5, "四");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 4, "四");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 5, "四");
            _robot.AssertEnable("儲存", false);
            _robot.SwitchTo("Form2");
            _robot.ClickButton("Course Selecting System");
            ChangeTest();
        }

        //test
        [TestMethod()]
        public void SecondToFourTest()
        {
            _robot.ClickButton("Course Selecting System");
            _robot.Sleep(0.5);
            _robot.SwitchTo("Form1");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 9, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            _robot.ClickButton("查看選課結果");
            _robot.SwitchTo("SetUpForm");
            _robot.ClickButton("Course Management System");
            _robot.Sleep(2);
            ChangeTest();
            _robot.ClickButton("儲存");
            _robot.SwitchTo("Form4");
            _robot.Sleep(3);
        }

        //test
        [TestMethod()]
        public void ThirdTest()
        {
            OpenTest();
            _robot.SwitchTo("Form3");
            _robot.ClickButton("新增課程");
            _robot.ChangeText("_textBox6", "陳偉凱");
            _robot.ChangeText("_comboBox1", "開課");
            _robot.ChangeText("_textBox1", "55");
            _robot.ChangeText("_textBox2", "555");
            _robot.ChangeText("_textBox4", "3");
            _robot.ChangeText("_textBox5", "3");
            _robot.ChangeText("_comboBox4", "○");
            _robot.ChangeText("_comboBox2", "2");
            _robot.ChangeText("_comboBox3", "資工三");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 4, "四");
            _robot.ClickDataGridViewCellBy("_dataGridView4", 5, "四");
            _robot.ClickButton("新增");
            _robot.AssertEnable("新增課程", true);
            _robot.SwitchTo("Form1");
            _robot.Sleep(2);
        }
        //test
        [TestMethod()]
        public void FourTest()
        {
            OpenTest();
            _robot.SwitchTo("Form3");
            _robot.ClickButton("匯入資工系全部課程");
            _robot.Sleep(5);
            _robot.SwitchTo("Form1");
            _robot.Sleep(5);
        }
    }
}
