using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _homeWork
{
    public class Model3
    {
        private Model1 _model;
        const string OPEN = "開課";
        const string SAVE = "儲存";
        const string CLASS1 = "資工三";
        const string CLASS2 = "電子三甲";
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
        const int FOURTEEN = 14;
        const int SEVENTEEN = 17;
        const int EIGHTEEN = 18;
        const int TWENTY = 20;

        public Model3(Model1 model)
        {
            this._model = model;
            this.CourseName = new List<List<string[]>>();
            this.ClassName = new List<string>
            {
                CLASS1, CLASS2 };
            this.ClassNameSet = new List<string>();
        }
        public string TextComboBox1
        {
            get; set;
        }
        public string TextComboBox2
        {
            get; set;
        }
        public string TextComboBox3
        {
            get; set;
        }
        public string TextComboBox4
        {
            get; set;
        }
        public string TextTextBox1
        {
            get; set;
        }
        public string TextTextBox2
        {
            get; set;
        }
        public string TextTextBox3
        {
            get; set;
        }
        public string TextTextBox4
        {
            get; set;
        }
        public string TextTextBox5
        {
            get; set;
        }
        public string TextTextBox6
        {
            get; set;
        }
        public string TextTextBox7
        {
            get; set;
        }
        public string TextTextBox8
        {
            get; set;
        }
        public string[] Content
        {
            get; set;
        }
        public string OpenClass
        {
            get; set;
        }

        public List<List<string[]>> CourseName
        {
            get; set;
        }
        public List<string> ClassName
        {
            get; set;
        }
        public List<string> ClassNameSet
        {
            get; set;
        }

        //更新內容
        public void Change()
        {
            TextComboBox1 = OpenClass;
            TextComboBox2 = Count();
            TextComboBox3 = Class();
            TextComboBox4 = Content[FIVE];
            TextTextBox1 = Content[0];
            TextTextBox2 = Content[1];
            TextTextBox3 = Content[TWENTY];
            TextTextBox4 = Content[TWO];
            TextTextBox5 = Content[THREE];
            TextTextBox6 = Content[SIX];
            TextTextBox7 = Content[EIGHTEEN];
            TextTextBox8 = Content[SEVENTEEN];
        }

        //重設所有
        public void ResetAll()
        {
            TextComboBox1 = "";
            TextComboBox2 = "";
            TextComboBox3 = "";
            TextComboBox4 = "";
            TextTextBox1 = "";
            TextTextBox2 = "";
            TextTextBox3 = "";
            TextTextBox4 = "";
            TextTextBox5 = "";
            TextTextBox6 = "";
            TextTextBox7 = "";
            TextTextBox8 = "";
        }

        //查看mode
        public bool CheckMode(string mode)
        {
            if (mode == SAVE)
                return true;
            else
                return false;
        }

        //計算時數
        public string Count()
        {
            int set = 0;
            for (int i = SEVEN; i < FOURTEEN; i++)
                if (Content.Length > SEVEN)
                    if (Content[i].Length != 0)
                        set = set + (Content[i].Length / TWO) + 1;
            return set.ToString();
        }

        //確認班級
        private string Class()
        {
            for (int i = 0; i < CourseName.Count; i++)
                for (int j = 0; j < CourseName[i].Count; j++)
                    if (CourseName[i][j][0] == Content[0])
                        switch (i)
                        {
                            case 0:
                                return CLASS1;

                            case 1:
                                return CLASS2;

                            default:
                                return ERROR;
                        }
            return ERROR;
        }

        //尋找課號
        public void FindNumber(string name)
        {
            List<string> number = GetNumber(name);
            OpenClass = number[1];
            Content = _model.FindNumber(number[0]);
        }

        //尋找課號
        private List<string> GetNumber(string number)
        {
            List<string> output = new List<string>();
            int set = -1;
            for (int i = 0; i < CourseName.Count; i++)
                for (int j = 0; j < CourseName[i].Count; j++)
                {
                    set++;
                    if (set.ToString() == number)
                    {
                        output.Add(CourseName[i][j][0]);
                        output.Add(CourseName[i][j][TWO]);
                        return output;
                    }
                }
            List<string> error = new List<string>();
            error.Add(ERROR);
            return error;
        }

        //取得課程名稱
        public void GetCourseName()
        {
            this.CourseName.Clear();
            for (int i = 0; i < _model.copy.Count; i++)
            {
                List<string[]> set = new List<string[]>();
                for (int j = 0; j < GetNumber(i); j++)
                    //string[] temp = new string[TWO] { _model.copy[i][j][0], _model.copy[i][j][1] };
                    set.Add(GetNumberAndName(i, j));
                CourseName.Add(set);
            }
        }

        //取得資訊
        public string[] GetNumberAndName(int first, int second)
        {
            return _model.GetNumberAndName(first, second);
        }

        //取得數字
        private int GetNumber(int first)
        {
            return _model.copy[first].Count;
        }

        //確認課程時間
        public bool CheckTime(int count)
        {
            if (Content[count] != "")
                return true;
            else
                return false;
        }

        //更新copy
        public void UpdateCopy(string[] set, string number, string state)
        {
            for (int i = 0; i < CourseName.Count; i++)
                for (int j = 0; j < CourseName[i].Count; j++)
                    if (CourseName[i][j][0] == number)
                    {
                        CourseName[i][j][0] = set[0];
                        CourseName[i][j][1] = set[1];
                        CourseName[i][j][TWO] = state;
                    }
            _model.UpdateCopy(set, number, state);
        }

        //確認位置
        public bool CheckBoolean(string set)
        {
            if (set == "")
                return true;
            else
                return false;
        }

        //增加新的課程
        public void AddNewCourse(string[] course, string className)
        {
            string[] set = new string[TWO] { course[0], course[1] };
            if (className == CLASS1)
                CourseName[0].Add(set);
            else
                CourseName[1].Add(set);
            _model.AddNewCourse(course, className);
        }

        //確認加入位置
        public int CheckClass(string className)
        {
            if (className == CLASS1)
                return CourseName[0].Count - 1;
            else
                return CourseName[0].Count + CourseName[1].Count - 1;
        }

        //確認改變
        public bool CheckChange(string[] set)
        {
            if (set[0] != OpenClass || set[1] != Count() || set[TWO] != Class() || set[THREE] != Content[FIVE] || set[FOUR] != Content[0] || set[FIVE] != Content[1] || set[SIX] != Content[TWENTY] || set[SEVEN] != Content[TWO] || set[EIGHT] != Content[THREE] || set[NINE] != Content[SIX] || set[TEN] != Content[EIGHTEEN] || set[ELEVEN] != Content[SEVEN])
                return true;
            else
                return false;
        }

        //確認空白
        public bool CheckSpace(string[] set)
        {
            if (set[0] == "" || set[1] == "" || set[TWO] == "" || set[THREE] == "" || set[FOUR] == "" || set[FIVE] == "" || set[SIX] == "" || set[SEVEN] == "")
                return false;
            else
                return true;
        }

        //計算時間
        public string CountTime(string[] date)
        {
            int set = 0;
            for (int i = 0; i < SEVEN; i++)
                if (date[i].Length != 0)
                    set = set + (date[i].Length / TWO) + 1;
            return set.ToString();
        }
    }
}
