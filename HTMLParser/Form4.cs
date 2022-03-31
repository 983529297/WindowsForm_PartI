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
    public partial class Form4 : Form
    {
        private Form1 _form;
        private Model1 _model;
        private Model3 _model3;
        private PresentationModel _presentation;
        const int THIRTEEN = 13;
        const int FOURTEEN = 14;
        const int FIFTEEN = 15;
        const int SEVENTEEN = 17;
        const int EIGHTEEN = 18;
        const int TWENTY = 20;
        const string HEAD = "退";
        const string NAME = "deleteColumn";
        const string TEXT = "退選";
        public Form4(Form1 form, Model1 model, Model3 model3, PresentationModel presentation)
        {
            this._model = model;
            this._model3 = model3;
            this._presentation = presentation;
            this._form = form;
            InitializeComponent();
            SetDataGridView();
            _model._changeModel += UpdateDataGridView;
        }
        
        //增加_datagridview3
        public void AddDataGridView()
        {
            if (_dataGridView3.ColumnCount >= 24)
                _dataGridView3.Columns.RemoveAt(0);
            SetDataGridView();
        }

        //設定_datagridview3
        public void SetDataGridView()
        {
            foreach (string[] rowArray in _model._dataGridView3temp)
                _dataGridView3.Rows.Add(rowArray);
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = HEAD;
            buttonColumn.Name = NAME;
            buttonColumn.Text = TEXT;
            buttonColumn.UseColumnTextForButtonValue = true;
            _dataGridView3.Columns.Insert(0, buttonColumn);
            _model._dataGridView3temp.Clear();
        }

        //按下退選按鈕
        private void UseDataGridView1CellContentClickSecond(object sender, DataGridViewCellEventArgs e)
        {
            _presentation.IsColumnIndex(e.ColumnIndex);
            if (_presentation._columnIndex)
            {
                string[] set = new string[_dataGridView3.ColumnCount - 1];
                for (int i = 0; i < _dataGridView3.ColumnCount - 1; i++)
                {
                    set[i] = _dataGridView3.Rows[e.RowIndex].Cells[i + 1].Value.ToString();
                }
                _model.delete = set;
                _dataGridView3.Rows.RemoveAt(e.RowIndex);
            }
            _form.AddData();
        }

        //form4關閉時的事件
        private void Form4FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
            _form.SetButton2();
            _presentation._isForm4 = false;
        }

        //儲存_model._dataGridView3
        private void Save()
        {
            _model._dataGridView3temp.Clear();
            for (int i = 0; i < _dataGridView3.RowCount; i++)
            {
                string[] set = new string[_dataGridView3.ColumnCount - 1];
                for (int j = 0; j < _dataGridView3.ColumnCount - 1; j++)
                {
                    set[j] = _dataGridView3.Rows[i].Cells[j + 1].Value.ToString();
                }
                _model._dataGridView3temp.Add(set);
            }
        }

        //更新datagridview
        private void UpdateDataGridView()
        {
            for (int i = 0; i < _dataGridView3.RowCount; i++)
            {
                if (_dataGridView3.Rows[i].Cells[1].Value.ToString() == _model.number)
                {
                    for (int c = 1; c < FOURTEEN; c++)
                    {
                        _dataGridView3.Rows[i].Cells[c].Value = GetContent(c);
                    }
                    _dataGridView3.Rows[i].Cells[SEVENTEEN].Value = _model.content[THIRTEEN];
                    _dataGridView3.Rows[i].Cells[EIGHTEEN].Value = _model.content[FOURTEEN];
                    _dataGridView3.Rows[i].Cells[TWENTY].Value = _model.content[FIFTEEN];
                }
            }
        }

        //取得資料
        private string GetContent(int first)
        {
            return _model.content[first - 1];
        }
    }
}
