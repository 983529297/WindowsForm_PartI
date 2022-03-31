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
    public partial class SetUpForm : Form
    {
        private Model1 _model;
        private Model3 _model3;
        private PresentationModel _presentation;
        private PresentationOf3 _presentationOf3;
        public SetUpForm(Model1 model, Model3 model3, PresentationModel presentation, PresentationOf3 presentationOf3)
        {
            this._model = model;
            this._model3 = model3;
            this._presentation = presentation;
            this._presentationOf3 = presentationOf3;
            InitializeComponent();
            //_model.CreateSite();
        }
        //開啟選課的按鈕
        private void Button1Click(object sender, EventArgs e)
        {
            if (_model.copy.Count == 0)
                CreateSite();
            _button3.Enabled = false;
            //Model1 model = new Model1();
            Form1 dialog = new Form1(_model, _model3, _presentation, this);
            dialog.Show();
        }

        //開啟課程管理的按鈕
        private void Button2Click(object sender, EventArgs e)
        {
            if (_model.copy.Count == 0)
                CreateSite();
            _button4.Enabled = false;
            Form3 dialog = new Form3(this, _model, _model3, _presentationOf3);
            dialog.Show();
        }

        //建立SITE
        private void CreateSite()
        {
            _model.CreateSite();
        }

        //關閉視窗的按鈕
        private void Button3Click(object sender, EventArgs e)
        {
            Close();
        }

        //開啟button1
        public void SetButton1()
        {
            _button3.Enabled = true;
        }

        //開啟button2
        public void SetButton2()
        {
            _button4.Enabled = true;
        }
    }
}
