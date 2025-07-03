using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace _homeWork
{
    class CourseData
    {
        const int NUMBER = 0;
        const int NAME = 1;
        const int STAGE = 2;
        const int CREDIT = 3;
        const int HOUR = 4;
        const int REQUIRED = 5;
        const int TEACHER = 6;
        const int SUNDAY = 7;
        const int MONDAY = 8;
        const int TUESDAY = 9;
        const int WEDNESDAY = 10;
        const int THURSDAY = 11;
        const int FRIDAY = 12;
        const int SATURDAY = 13;
        const int CLASSROOM = 14;
        const int STUDENT = 15;
        const int OUT = 16;
        const int ASSISTANT = 17;
        const int LANGUAGE = 18;
        const int OUTLINE = 19;
        const int NOTE = 20;
        const int OTHER = 21;
        const int EXPERIMENT = 22;
        //爬蟲程式
        public static List<Course> GetCourseInfo(string site)
        {
            //const string SITE = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
            const string POSITION = "//body/table";
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = null;
            HtmlAgilityPack.HtmlDocument document = webClient.Load(site);
            List<Course> course = new List<Course>();
            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(POSITION);
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;
            Remove(nodeTableRow);
            foreach (var node in nodeTableRow)
            {
                HtmlNodeCollection nodeTableDatas = node.ChildNodes;
                // 移除 #text
                nodeTableDatas.RemoveAt(0);
                course = CourseAdd(nodeTableDatas, course);
            }
            return course;
        }

        //移除資料
        private static void Remove(HtmlNodeCollection nodeTableRow)
        {
            // 移除 tbody
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>資工三
            nodeTableRow.RemoveAt(0);
            // 移除 table header
            nodeTableRow.RemoveAt(0);

            // 移除 <tr>小計
            nodeTableRow.RemoveAt(nodeTableRow.Count - 1);
        }

        //輸入資料
        private static List<Course> CourseAdd(HtmlNodeCollection nodeTableDatas, List<Course> course)
        {
            course.Add(//      number                              name                                stage
                    new Course(nodeTableDatas[NUMBER].InnerText.Trim(), nodeTableDatas[NAME].InnerText.Trim(), nodeTableDatas[STAGE].InnerText.Trim(),
                        //credit                            hour                                required/elective
                        nodeTableDatas[CREDIT].InnerText.Trim(), nodeTableDatas[HOUR].InnerText.Trim(), nodeTableDatas[REQUIRED].InnerText.Trim(),
                        //teacher
                        nodeTableDatas[TEACHER].InnerText.Trim(),
                        new List<string>//classTime
                        {
                            nodeTableDatas[SUNDAY].InnerText.Trim(), nodeTableDatas[MONDAY].InnerText.Trim(), nodeTableDatas[TUESDAY].InnerText.Trim(),
                            nodeTableDatas[WEDNESDAY].InnerText.Trim(), nodeTableDatas[THURSDAY].InnerText.Trim(), nodeTableDatas[FRIDAY].InnerText.Trim(), nodeTableDatas[SATURDAY].InnerText.Trim()},
                        //classroom                          //numberOfStudent                    //numberOfDropStudent                                                     //TA                                 //language                           //syllubus
                        nodeTableDatas[CLASSROOM].InnerText.Trim(), nodeTableDatas[STUDENT].InnerText.Trim(), nodeTableDatas[OUT].InnerText.Trim(), nodeTableDatas[ASSISTANT].InnerText.Trim(), nodeTableDatas[LANGUAGE].InnerText.Trim(), nodeTableDatas[OUTLINE].InnerText.Trim(),
                        //note                               //audit                              // experiment
                        nodeTableDatas[NOTE].InnerText.Trim(), nodeTableDatas[OTHER].InnerText.Trim(), nodeTableDatas[EXPERIMENT].InnerText.Trim()));
            return course;
        }
    }
}
