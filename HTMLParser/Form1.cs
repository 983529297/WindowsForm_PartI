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
    public partial class Form1 : Form
    {
        const int WIDTH = 45;
        const string FIRST = "選";
        const int TWO = 2;
        const int FOUR = 4;
        const int FIVE = 5;
        const int SIX = 6;
        const int SEVEN = 7;
        const int FOURTEEN = 14;
        const int FIFTEEN = 15;
        const int SIXTEEN = 16;
        const int EIGHTEEN = 18;
        const int NINETEEN = 19;
        const int TWENTY1 = 21;
        private Model1 _model;
        private Model3 _model3;
        private PresentationModel _presentation;
        private SetUpForm _form;
        private Form4 _form4;
        private List<DataGridView> _allClass;
        private List<DataGridView> _totalData;

        public Form1(Model1 model, Model3 model3, PresentationModel presentation, SetUpForm form)
        {
            this._model = model;
            this._model3 = model3;
            this._presentation = presentation;
            this._form = form;
            InitializeComponent();
           
            _model._changeModel += UpdateDataGridView;
            _model._addCourse += AddNewCourse;
            _model._addClass += AddPageSet;
            DataGridView dataGridView4 = new DataGridView();
            DataGridView dataGridView5 = new DataGridView();
            DataGridView dataGridView6 = new DataGridView();
            DataGridView dataGridView7 = new DataGridView();
            _allClass = new List<DataGridView> 
            { 
                dataGridView4 , dataGridView5 , dataGridView6 , dataGridView7 };
            _totalData = new List<DataGridView> 
            { 
                _dataGridView1, _dataGridView2 };
            CreateDataGridView();
        }

        //創造datagridview
        private void CreateDataGridView()
        {
            int count = 0;
            foreach (DataGridView obj in _totalData)
            {
                List<string[]> set = new List<string[]>();
                set = _model.copy[count];
                foreach (string[] rowArray in set)
                    obj.Rows.Add(rowArray);
                CreateCheckBox(obj);
                count++;
            }
            if (_model.copy.Count == SIX)
            {
                AddPages("資工一", FOUR);
                AddPages("資工二", FIVE);
                AddPages("資工四", SIX);
                AddPages("資工所", SEVEN);
            }
        }

        //創造datagridview
        private void CreateDataGridView(DataGridView name, int count)
        {
            List<string[]> set = new List<string[]> ();
            set = _model.copy[count];
            foreach (string[] rowArray in set)
                name.Rows.Add(rowArray);
            CreateCheckBox(name);
        }

        //增加checkbox
        private void CreateCheckBox(DataGridView dataName)
        {
            DataGridViewColumn check = new DataGridViewCheckBoxColumn();
            check.Width = WIDTH;
            dataName.Columns.Insert(0, check);
            dataName.Columns[0].HeaderText = FIRST;
        }

        //判斷checkbox是否為true
        private void UseDataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = 0;
            /*List<DataGridView> totalData = new List<DataGridView> 
            { 
                _dataGridView1, _dataGridView2 };*/
            foreach (DataGridView obj in _totalData)
                for (int i = 0; i < obj.RowCount; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)obj.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.EditedFormattedValue);
                    a = _model.Flag(a, flag);
                }
            _presentation.SetButton(a);
            _button1.Enabled = _presentation._button1Enable;
        }

        //按下查看選課結果的事件
        private void Button2Click(object sender, EventArgs e)
        {
            _button2.Enabled = false;
            _presentation._isForm4 = true;
            Form4 dialog = new Form4(this, _model, _model3, _presentation);
            this._form4 = dialog;
            dialog.Show();
        }

        //按下確認送出的事件
        private void Button1Click(object sender, EventArgs e)
        {
            /*List<DataGridView> totalData = new List<DataGridView> 
            { 
                _dataGridView1, _dataGridView2 };*/
            List<string[]> data = new List<string[]> ();
            _model.receiveForm = GiveData(_totalData, data);
            _model.NameCheck();
            bool flag = _model.CanPass();
            if (flag)
                MessageBox.Show(_model.errorMessage);
            else
            {
                MessageBox.Show("加選成功");
                DeleteAndSet();
                _button1.Enabled = false;
            }
        }

        //刪除資料以及設定form4
        private void DeleteAndSet()
        {
            DeleteCourse();
            _model.AddDataGridView3();
            if (_presentation._isForm4)
            {
                _form4.AddDataGridView();
            }
        }

        //送資料給receiveForm
        private List<string[]> GiveData(List<DataGridView> totalData, List<string[]> data)
        {
            foreach (DataGridView obj in totalData)
                for (int i = 0; i < obj.RowCount; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)obj.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.EditedFormattedValue);
                    if (flag)
                    {
                        string[] set = { };
                        for (int j = 1; j < obj.ColumnCount; j++)
                        {
                            Array.Resize(ref set, set.Length + 1);
                            set[set.Length - 1] = obj.Rows[i].Cells[j].Value.ToString();
                        }
                        data.Add(set);
                    }
                }
            return data;
        }

        //刪除送出的課程
        private void DeleteCourse()
        {
            /*List<DataGridView> totalData = new List<DataGridView> 
            { 
                _dataGridView1, _dataGridView2 };*/
            foreach (DataGridView obj in _totalData)
            {
                for (int i = 0; i < obj.RowCount; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)obj.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.EditedFormattedValue);
                    if (flag)
                    {
                        DataGridViewRow row = obj.Rows[i];
                        obj.Rows.Remove(row);
                        i = i - 1;
                    }
                }
            }
        }

        //插入表格
        public void SetDataGridView1(string[] data)
        {
            _dataGridView1.Columns.RemoveAt(0);
            _dataGridView1.Rows.Add(data);
            DataGridViewColumn check = new DataGridViewCheckBoxColumn();
            check.Width = WIDTH;
            _dataGridView1.Columns.Insert(0, check);
            _dataGridView1.Columns[0].HeaderText = FIRST;
        }

        //將資料加入_datagridview2
        public void SetDataGridView2(string[] data)
        {
            _dataGridView2.Columns.RemoveAt(0);
            _dataGridView2.Rows.Add(data);
            DataGridViewColumn check = new DataGridViewCheckBoxColumn();
            check.Width = WIDTH;
            _dataGridView2.Columns.Insert(0, check);
            _dataGridView2.Columns[0].HeaderText = FIRST;
        }

        //回復刪除的資料
        public void AddData()
        {
            int position = _model.CheckDelete();
            string[] delete = _model.delete;
            switch (position)
            {
                case 0:
                    SetDataGridView1(delete);
                    break;

                case 1:
                    SetDataGridView2(delete);
                    break;

                default:
                    Console.WriteLine("error!");
                    break;
            }
        }

        //設定button1
        private void Form1FormClosed(object sender, FormClosedEventArgs e)
        {
            _form.SetButton1();
        }

        //設定button2
        public void SetButton2()
        {
            _button2.Enabled = true;
        }

        //更新datagridview
        private void UpdateDataGridView()
        {
            foreach (DataGridView obj in _totalData)
                for (int i = 0; i < obj.RowCount; i++)
                    if (obj.Rows[i].Cells[1].Value.ToString() == _model.number)
                    {
                        DataGridViewRow row = obj.Rows[i];
                        if (IsState("停課"))
                            obj.Rows.Remove(row);
                        else
                        {
                            for (int c = 1; c < FIFTEEN; c++)
                                obj.Rows[i].Cells[c].Value = GetContent(c);
                            obj.Rows[i].Cells[EIGHTEEN].Value = _model.content[FOURTEEN];
                            obj.Rows[i].Cells[NINETEEN].Value = _model.content[FIFTEEN];
                            obj.Rows[i].Cells[TWENTY1].Value = _model.content[SIXTEEN];
                        }
                    }
        }

        //確認flag
        private bool IsState(string name)
        {
            return _model.IsState(name);
        }

        //取得Content
        private string GetContent(int number)
        {
            return _model.content[number - 1];
        }

        //增加課程
        private void AddNewCourse()
        {
            if (_model.CheckClassName())
            {
                AddNewColumn(_dataGridView1);
            }
            else
            {
                AddNewColumn(_dataGridView2);
            }
        }

        //增加第一行
        private void AddNewColumn(DataGridView data)
        {
            data.Columns.RemoveAt(0);
            data.Rows.Add(_model.newCourse);
            DataGridViewColumn check = new DataGridViewCheckBoxColumn();
            check.Width = WIDTH;
            data.Columns.Insert(0, check);
            data.Columns[0].HeaderText = FIRST;
        }

        //呼叫其他函式
        private void AddPageSet()
        {
            AddPages(_model.name, _model.number1);
        }

        //增加page
        private void AddPages(string name, int number)
        {
            _tabControl1.TabPages.Add(name);
            for (int i = 1; i < 24; i++)
            {
                _allClass[number - FOUR].Columns.Add("Column", _dataGridView1.Columns[i].HeaderText);
            }
            _allClass[number - FOUR].Dock = DockStyle.Fill;
            _allClass[number - FOUR].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _allClass[number - FOUR].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _allClass[number - FOUR].RowHeadersVisible = false;
            _allClass[number - FOUR].AllowUserToAddRows = false;
            CreateDataGridView(_allClass[number - FOUR], number - TWO);
            _allClass[number - FOUR].Name = "_datagridview" + number.ToString();
            _tabControl1.TabPages[number - TWO].Controls.Add(_allClass[number - FOUR]);
            _totalData.AddRange(_allClass);
            _allClass[number - FOUR].CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UseDataGridView1CellContentClick);
        }
    }
}
