using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _homeWork
{
    public partial class Form5 : Form
    {
        private Model1 _model;
        private Model3 _model3;
        private Form3 _form;
        private List<int> _set;
        const string CLASS1 = "資工一";
        const string CLASS2 = "資工二";
        const string CLASS3 = "資工四";
        const string CLASS4 = "資工所";
        const string WAIT = "正在載入課程...";
        const int ZERO = 0;
        const int TWO = 2;
        const int FOUR = 4;
        const int TEN = 10;
        const int TWENTY5 = 25;
        const int TWENTY6 = 26;
        const string SITE1 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2676";
        const string SITE2 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2550";
        const string SITE3 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2314";
        const string SITE4 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2701";
        public Form5(Form3 form, Model1 model, Model3 model3)
        {
            _model = model;
            _model3 = model3;
            _form = form;
            InitializeComponent();
        }

        //開啟後執行
        private void ShowForm5(object sender, EventArgs e)
        {
            _set = new List<int> ();
            _set.Add(FOUR);
            _set.Add(ZERO);
            _set.Add(TWENTY6);
            AddClass(SITE1, CLASS1, _set);
            AddClass(SITE2, CLASS2, _set);
            AddClass(SITE3, CLASS3, _set);
            AddClass(SITE4, CLASS4, _set);
            _form.SetButton6();
            _form.AddListBox1();
            this.Close();
        }

        //更新label
        private void ChangeLabel1Text(object sender, EventArgs e)
        {
            _label1.Update();
        }

        //增加課程
        private void AddClass(string site, string name, List<int> set)
        {
            _model.AddNewClass(site, name, set[0]);
            _form.AddClass(name);
            for (int i = set[1]; i < set[TWO]; i++)
            {
                _progressBar1.Value = i;
                _label1.Text = WAIT + i.ToString();
                Thread.Sleep(TEN);
            }
            set[0] = set[0] + 1;
            set[1] = set[TWO];
            set[TWO] = set[TWO] + TWENTY5;
        }
    }
}

