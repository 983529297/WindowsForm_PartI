using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _homeWork
{
    public partial class Form3 : Form
    {

        private SetUpForm _form;
        private Model1 _model;
        private Model3 _model3;
        private PresentationOf3 _presentationOf3;
        private string _number;
        private int _index;
        const string SAVE = "儲存";
        const string ADD = "新增";
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int FIVE = 5;
        const int SIX = 6;
        const int SEVEN = 7;
        const int FOURTEEN = 14;

        public Form3(SetUpForm form, Model1 model, Model3 model3, PresentationOf3 presentationOf3)
        {
            this._form = form;
            this._model = model;
            this._model3 = model3;
            this._presentationOf3 = presentationOf3;
            InitializeComponent();
            _button1.Enabled = true;
            _button2.Enabled = false;
            for (int i = 1; i < 10; i++)
            {
                int a = i;
                _dataGridView4.Rows.Add(a.ToString());
            }
            _model3.GetCourseName();
            RefreshEnable();
            for (int i = 0; i < _model3.CourseName.Count; i++)
                for (int j = 0; j < _model3.CourseName[i].Count; j++)
                    _listBox1.Items.Add(_model3.CourseName[i][j][1]);
            for (int i = 0; i < _model3.ClassName.Count; i++)
                _listBox2.Items.Add(_model3.ClassName[i]);
            _model3.ClassNameSet = _model3.ClassName;
            _button2.Enabled = false;
            this.ImeMode = ImeMode.Alpha;
        }

        //form3關閉時的事件
        private void Form3FormClosed(object sender, FormClosedEventArgs e)
        {
            _form.SetButton2();
        }

        //更新內容
        public void RefreshText()
        {
            _comboBox1.Text = _model3.TextComboBox1;
            _comboBox2.Text = _model3.TextComboBox2;
            _comboBox3.Text = _model3.TextComboBox3;
            _comboBox4.Text = _model3.TextComboBox4;
            _textBox1.Text = _model3.TextTextBox1;
            _textBox2.Text = _model3.TextTextBox2;
            _textBox3.Text = _model3.TextTextBox3;
            _textBox4.Text = _model3.TextTextBox4;
            _textBox5.Text = _model3.TextTextBox5;
            _textBox6.Text = _model3.TextTextBox6;
            _textBox7.Text = _model3.TextTextBox7;
            _textBox8.Text = _model3.TextTextBox8;
            _button5.Text = _presentationOf3.TextButton5;
            //RefreshDataGridView();
        }

        //更新Enable
        public void RefreshEnable()
        {
            _comboBox1.Enabled = _presentationOf3.IsComboBox1;
            _comboBox2.Enabled = _presentationOf3.IsComboBox2;
            _comboBox3.Enabled = _presentationOf3.IsComboBox3;
            _comboBox4.Enabled = _presentationOf3.IsComboBox4;
            _textBox1.Enabled = _presentationOf3.IsTextBox1;
            _textBox2.Enabled = _presentationOf3.IsTextBox2;
            _textBox3.Enabled = _presentationOf3.IsTextBox3;
            _textBox4.Enabled = _presentationOf3.IsTextBox4;
            _textBox5.Enabled = _presentationOf3.IsTextBox5;
            _textBox6.Enabled = _presentationOf3.IsTextBox6;
            _textBox7.Enabled = _presentationOf3.IsTextBox7;
            _textBox8.Enabled = _presentationOf3.IsTextBox8;
            _button4.Enabled = _presentationOf3.IsButton4;
            _button5.Enabled = _presentationOf3.IsButton5;
        }

        //選擇課程名稱
        private void SelectedIndexChangedListBox1(object sender, EventArgs e)
        {
            _groupBox1.Text = "編輯課程";
            this._index = 0;
            _presentationOf3.ChangeAll();
            _presentationOf3.ChangeButton4FromList();
            RefreshEnable();
            _model3.FindNumber(_listBox1.SelectedIndex.ToString());
            _model3.Change();
            RefreshText();
            this._number = _textBox1.Text;
            this._index++;
            RefreshDataGridView();
        }

        //重設datagridview
        private void ResetDataGridView()
        {
            for (int i = 1; i < _dataGridView4.ColumnCount; i++)
                for (int j = 0; j < _dataGridView4.RowCount; j++)
                    _dataGridView4.Rows[j].Cells[i].Value = false;
        }

        //datagridview 使用
        private void RefreshDataGridView()
        {
            ResetDataGridView();
            for (int i = SEVEN; i < FOURTEEN; i++)
            {
                if (_model3.CheckTime(i))
                    for (int j = 0; j < _model3.Content[i].Length; j = j + 1 + 1)
                    {
                        Int32.TryParse(_model3.Content[i][j].ToString(), out int s);
                        _dataGridView4.Rows[s - 1].Cells[i - SIX].Value = true;
                    }
            }
        }

        //按下_button4的情況
        private void ClickButton4(object sender, EventArgs e)
        {
            _groupBox1.Text = "新增課程";
            _presentationOf3.ChangeButton4();
            _presentationOf3.ChangeAll();
            ResetDataGridView();
            RefreshEnable();
            _model3.ResetAll();
            RefreshText();
        }

        //按下_button5的情況
        private void ClickButton5(object sender, EventArgs e)
        {
            if (_model3.CheckMode(_button5.Text))
            {
                string[] date = CheckDate();
                string[] set = new string[] { _textBox1.Text, _textBox2.Text, _textBox4.Text, _textBox5.Text, _comboBox2.Text, _comboBox4.Text, _textBox6.Text, date[0], date[1], date[TWO], date[THREE], date[FOUR], date[FIVE], date[SIX], _textBox8.Text, _textBox7.Text, _textBox3.Text };
                UpdateCopy(set, this._number, this._comboBox1.Text);
                RefreshListBox1();
                ChangeButton5();
                this._number = _textBox1.Text;
            }
            else
            {
                string[] date = CheckDate();
                string[] set = new string[] { _textBox1.Text, _textBox2.Text, _textBox4.Text, _textBox5.Text, _comboBox2.Text, _comboBox4.Text, _textBox6.Text, date[0], date[1], date[TWO], date[THREE], date[FOUR], date[FIVE], date[SIX], _textBox8.Text, _textBox7.Text, _textBox3.Text };
                AddNewCourse(set, _comboBox3.Text);
                _listBox1.Items.Insert(_model3.CheckClass(_comboBox3.Text), _textBox2.Text);
                ChangeButton5();
            }
        }

        //更新listBox1
        private void RefreshListBox1()
        {
            _listBox1.Items.Clear();
            for (int i = 0; i < GetCourseName(); i++)
                for (int j = 0; j < GetCourseNameNumber(i); j++)
                    _listBox1.Items.Add(_model3.CourseName[i][j][1]);
        }

        //更新listBox1
        public void AddListBox1()
        {
            _model3.GetCourseName();
            _listBox1.Items.Clear();
            for (int i = 0; i < _model3.CourseName.Count; i++)
            {
                int number = GetNumber(i);
                for (int j = 0; j < number; j++)
                    AddList(i, j);
            }
        }

        //查詢數量
        private int GetNumber(int first)
        {
            return _model3.CourseName[first].Count;
        }

        //增加listbox
        private void AddList(int first, int second)
        {
            _listBox1.Items.Add(_model3.CourseName[first][second][1]);
        }

        //改變button5
        private void ChangeButton5()
        {
            _presentationOf3.IsButton5 = false;
            _button5.Enabled = IsButton5();
        }

        //增加課程
        private void AddNewCourse(string[] set, string text)
        {
            _model3.AddNewCourse(set, text);
        }

        //計算班級數量
        private int GetCourseName()
        {
            return _model3.CourseName.Count;
        }

        //計算課程數量
        private int GetCourseNameNumber(int first)
        {
            return _model3.CourseName[first].Count;
        }

        //更新資料
        private void UpdateCopy(string[] set, string number, string state)
        {
            _model3.UpdateCopy(set, number, state);
        }

        //確認日期
        private string[] CheckDate()
        {
            string[] set = new string[7];
            for (int i = 1; i < _dataGridView4.ColumnCount; i++)
            {
                string s = "";
                for (int j = 0; j < _dataGridView4.RowCount; j++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)_dataGridView4.Rows[j].Cells[i];
                    Boolean flag = Convert.ToBoolean(checkCell.EditedFormattedValue);
                    if (flag)
                        if (_model3.CheckBoolean(s))
                            s = s + (j + 1).ToString();
                        else
                            s = s + " " + (j + 1).ToString();
                }
                set[i - 1] = s;
            }
            return set;
        }

        //限制輸入
        private void PressTextBox1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //確認儲存的enable
        private void CheckButton5()
        {
            string[] set = new string[] { _comboBox1.Text, _comboBox2.Text, _comboBox3.Text, _comboBox4.Text, _textBox1.Text, _textBox2.Text, _textBox3.Text, _textBox4.Text, _textBox5.Text, _textBox6.Text, _textBox7.Text, _textBox8.Text };
            if (_model3.CheckChange(set))
            {
                _presentationOf3.IsChange = true;
            }
            else
            {
                _presentationOf3.IsChange = false;
            }
        }

        //檢查空白
        private void CheckSpace()
        {
            string[] set = new string[] { _textBox1.Text, _textBox2.Text, _textBox4.Text, _textBox5.Text, _textBox6.Text, _comboBox2.Text, _comboBox3.Text, _comboBox4.Text };
            if (_model3.CheckSpace(set))
            {
                _presentationOf3.IsSpace = true;
            }
            else
            {
                _presentationOf3.IsSpace = false;
            }
        }

        //判斷是否更動
        private void SelectedIndexChangedComboBox1(object sender, EventArgs e)
        {
            if (_button5.Text == SAVE && this._index != 0)
            {
                CheckButton5();
                CheckSpace();
                CheckTime();
                CheckThreeCondition();
            }
            else if (_button5.Text == ADD)
            {
                CheckSpace();
                CheckTime();
                CheckTwoCondition();
            }
        }

        //當datagridview有更動
        private void ClickCellContentDataGridView4(object sender, DataGridViewCellEventArgs e)
        {
            if (_button5.Text == SAVE && this._index != 0)
            {
                CheckTime();
                CheckThreeCondition();
            }
            else if (_button5.Text == ADD)
            {
                CheckTime();
                CheckTwoCondition();
            }
        }

        //確認時間
        private void CheckTime()
        {
            string[] set = CheckDate();
            string count = _model3.CountTime(set);
            if (count == _comboBox2.Text)
            {
                _presentationOf3.IsDate = true;
                //_presentationOf3.IsChange = true;
            }
            else
            {
                //CheckButton5();
                _presentationOf3.IsDate = false;
                
            }
        }

        //確認3個條件
        private void CheckThreeCondition()
        {
            if (_presentationOf3.CheckCondition(0))
            {
                _presentationOf3.IsButton5 = true;
                _button5.Enabled = IsButton5();
            }
            else
            {
                _presentationOf3.IsButton5 = false;
                _button5.Enabled = IsButton5();
            }
        }

        //取得IsButton5
        private bool IsButton5()
        {
            return _presentationOf3.IsButton5;
        }

        //更改按鈕
        public void SetButton6()
        {
            _button6.Enabled = true;
        }

        //確認2個條件
        private void CheckTwoCondition()
        {
            if (_presentationOf3.CheckCondition(1))
            {
                _presentationOf3.IsButton5 = true;
                _button5.Enabled = IsButton5();
            }
            else
            {
                _presentationOf3.IsButton5 = false;
                _button5.Enabled = IsButton5();
            }
        }

        //按下_button6之功能
        private void ClickButton6(object sender, EventArgs e)
        {
            if (_model.copy.Count != 6)
            {
                Form5 dialog = new Form5(this, _model, _model3);
                _button6.Enabled = false;
                dialog.ShowDialog();
            }
        }

        //增加class
        public void AddClass(string name)
        {
            _comboBox3.Items.Add(name);
        }

        //點擊_listBox2
        private void SelectedIndexChangedListBox2(object sender, EventArgs e)
        {
            _button1.Enabled = true;
            _button2.Enabled = false;
            _textBox9.Text = _model3.ClassNameSet[_listBox2.SelectedIndex];
            _listBox3.Items.Clear();
            if (_listBox2.SelectedIndex < 2)
                for (int i = 0; i < _model3.CourseName[_listBox2.SelectedIndex].Count; i++)
                    _listBox3.Items.Add(_model3.CourseName[_listBox2.SelectedIndex][i][1]);
        }

        //按_button1
        private void ClickButton1(object sender, EventArgs e)
        {
            _button1.Enabled = false;
            _textBox9.Text = "";
            _listBox3.Items.Clear();
        }

        //輸入班級
        private void ChangedTextBox9(object sender, EventArgs e)
        {
            if (_button1.Enabled == false)
                if (_textBox9.Text == "")
                    _button2.Enabled = false;
                else
                    _button2.Enabled = true;
        }

        //點擊新增
        private void ClickButton2(object sender, EventArgs e)
        {
            _model3.ClassNameSet.Add(_textBox9.Text);
            _listBox2.Items.Add(_textBox9.Text);
            _listBox3.Items.Clear();
            _button1.Enabled = true;
            _button2.Enabled = false;
            _textBox9.Text = "";
        }
    }
}
