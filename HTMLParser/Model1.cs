using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace _homeWork
{
    public class Model1
    {
        public event ModelChangedEventHandler _changeModel;
        public event ModelChangedEventHandler _addCourse;
        public event ModelChangedEventHandler _addClass;
        public delegate void ModelChangedEventHandler();
        const string UP = " 「";
        const string DOWN = "」";
        const string OPEN = "開課";
        const string WORD = "e";
        const string NAME1 = "加選失敗\n\n";
        const string NAME2 = "課程名稱重複: ";
        const string NAME3 = "\n衝堂: ";
        const string CLASS1 = "資工三";
        const string ERROR = "error";
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int FIVE = 5;
        const int SIX = 6;
        const int SEVEN = 7;
        const int EIGHT = 8;
        const int NINE = 9;
        const int TEN = 10;
        const int ELEVEN = 11;
        const int TWELVE = 12;
        const int THIRTEEN = 13;
        const int FOURTEEN = 14;
        const int FIFTEEN = 15;
        const int SIXTEEN = 16;
        const int SEVENTEEN = 17;
        const int EIGHTEEN = 18;
        const int NINETEEN = 19;
        const int TWENTY = 20;
        const int TWENTY3 = 23;
        const string SITE1 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
        const string SITE2 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2423";

        public Model1()
        {
            this.receiveForm = new List<string[]> ();
            this.copy = new List<List<string[]>> ();
            this._dataGridView3temp = new List<string[]> ();
        }

        //創造網址
        public void CreateSite()
        {
            CreateCopy(SITE1);
            CreateCopy(SITE2);
        }

        //Observer提醒
        void NotifyObserverForModelChange()
        {
            if (_changeModel != null)
                _changeModel();
        }

        //Observer提醒
        void NotifyObserverForAddNewCourse()
        {
            if (_addCourse != null)
                _addCourse();
        }

        //Observer提醒
        void NotifyObserverForAddNewClass()
        {
            if (_addClass != null)
                _addClass();
        }

        //Flag 確認是否勾選
        public int Flag(int count, bool flag)
        {
            if (flag == true)
                count++;
            return count;
        }

        //確定flag
        public bool IsState(string name)
        {
            if (name != OPEN)
                return true;
            return false;
        }

        public List<string[]> receiveForm
        {
            get;set;
        }
        public List<string[]> _dataGridView3temp
        {
            get; set;
        }
        public List<List<string[]>> copy
        {
            get; set;
        }
        public string nameError
        {
            get; set;
        }
        public string dateError
        {
            get; set;
        }

        public string errorMessage
        {
            get; set;
        }
        public string[] delete
        {
            get; set;
        }

        public string[] newCourse
        {
            get; set;
        }
        public string[] content
        {
            get; set;
        }
        public string number
        {
            get; set;
        }

        public string className
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public int number1
        {
            get; set;
        }
        public string state
        {
            get; set;
        }

        //創造copy
        public void CreateCopy(string address)
        {
            List<Course> courseInfo = CourseData.GetCourseInfo(address);
            List<string[]> rows = new List<string[]>();
            for (int i = 0; i < courseInfo.Count; i++)
            {
                string[] row = new string[TWENTY3];
                row = courseInfo[i].GetArray();
                rows.Add(row);
            }
            copy.Add(rows);
        }

        //檢測名稱
        public void NameCheck()
        {
            nameError = "";
            string set;
            for (int i = 0; i < receiveForm.Count(); i++)
            {
                set = receiveForm[i][1];
                for (int j = i + 1; j < receiveForm.Count(); j++)
                    if (set == receiveForm[j][1])
                        nameError = nameError + UP + receiveForm[i][0] + set + DOWN + UP + receiveForm[j][0] + receiveForm[j][1] + DOWN;
            }
            DateCheck();
        }

        //檢測衝堂
        public void DateCheck()
        {
            const int SEVEN = 7;
            const int FOURTEEN = 14;
            dateError = "";
            for (int i = 0; i < receiveForm.Count(); i++)
                for (int j = SEVEN; j < FOURTEEN; j++)
                {
                    string set = receiveForm[i][j];
                    if (receiveForm[i][j] != "")
                        for (int x = i + 1; x < receiveForm.Count(); x++)
                            if (receiveForm[x][j] != "")
                                for (int s = 0; s < set.Length; s = s + 1 + 1)
                                    if (receiveForm[x][j].Contains(set[s]) && !set[s].ToString().Contains(WORD))
                                    {
                                        dateError = dateError + UP + receiveForm[i][0] + receiveForm[i][1] + DOWN + UP + receiveForm[x][0] + receiveForm[x][1] + DOWN;
                                        break;
                                    }
                }
        }

        //錯誤訊息
        public bool CanPass()
        {
            if (nameError == "" && dateError == "")
                return false;
            else
            {
                SetErrorMessage();
                return true;
            }
        }

        //增加datagridview4
        public void AddDataGridView3()
        {
            for (int i = 0; i < receiveForm.Count; i++)
                this._dataGridView3temp.Add(receiveForm[i]);
        }

        //判斷errormessage
        private void SetErrorMessage()
        {
            if (nameError != "" && dateError != "")
                errorMessage = NAME1 + NAME2 + nameError + NAME3 + dateError;
            else if (nameError != "")
                errorMessage = NAME1 + NAME2 + nameError;
            else
                errorMessage = NAME1 + NAME3 + dateError;
        }

        //確認該課程所屬
        public int CheckDelete()
        {
            for (int i = 0; i < copy[0].Count; i++)
                if (this.delete[0] == copy[0][i][0])
                    return 0;
            for (int i = 0; i < copy[1].Count; i++)
                if (this.delete[0] == copy[1][i][0])
                    return 1;
            return -1;
        }

        //回傳string[]
        public string[] FindNumber(string name)
        {
            string[] error = new string[1] { ERROR };
            for (int i = 0; i < copy.Count; i++)
                for (int j = 0; j < copy[i].Count; j++)
                    if (copy[i][j][0] == name)
                        return copy[i][j];
            return error;
        }

        //更新copy
        public void UpdateCopy(string[] content, string number, string state)
        {
            this.number = number;
            this.content = content;
            this.state = state;
            for (int i = 0; i < copy.Count; i++)
                for (int j = 0; j < copy[i].Count; j++)
                    if (copy[i][j][0] == number)
                    {
                        for (int c = 0; c < FOURTEEN; c++)
                            copy[i][j][c] = content[c];
                        copy[i][j][SEVENTEEN] = content[FOURTEEN];
                        copy[i][j][EIGHTEEN] = content[FIFTEEN];
                        copy[i][j][TWENTY] = content[SIXTEEN];
                    }
            NotifyObserverForModelChange();
        }

        //增加新的課程
        public void AddNewCourse(string[] course, string className)
        {
            this.className = className;
            string[] set = new string[] { course[0], course[1], course[TWO], course[THREE], course[FOUR], course[FIVE], course[SIX], course[SEVEN], course[EIGHT], course[NINE], course[TEN], course[ELEVEN], course[TWELVE], course[THIRTEEN], "", "", "", course[FOURTEEN], course[FIFTEEN], "", course[SIXTEEN], "", "" };
            this.newCourse = set;
            if (className == CLASS1)
                copy[0].Add(set);
            else
                copy[1].Add(set);
            NotifyObserverForAddNewCourse();
        }

        //確認班級
        public bool CheckClassName()
        {
            if (this.className == CLASS1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //取得學號與名稱
        public string[] GetNumberAndName(int first, int second)
        {
            string[] set = new string[] { copy[first][second][0], copy[first][second][1], OPEN };
            return set;
        }
        
        //增加新的班級
        public void AddNewClass(string site, string name, int number)
        {
            CreateCopy(site);
            this.name = name;
            this.number1 = number;
            NotifyObserverForAddNewClass();
        }
    }
}
