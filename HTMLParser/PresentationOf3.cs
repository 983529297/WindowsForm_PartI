using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _homeWork
{
    public class PresentationOf3
    {
        const string SAVE = "儲存";
        const string ADD = "新增";

        public PresentationOf3()
        {
            IsComboBox1 = false;
            IsComboBox2 = false;
            IsComboBox3 = false;
            IsComboBox4 = false;
            IsTextBox1 = false;
            IsTextBox2 = false;
            IsTextBox3 = false;
            IsTextBox4 = false;
            IsTextBox5 = false;
            IsTextBox6 = false;
            IsTextBox7 = false;
            IsTextBox8 = false;
            IsButton4 = true;
            IsButton5 = false;
            TextButton5 = SAVE;
            IsChange = false;
            IsDate = true;
            IsSpace = false;
        }

        public bool IsComboBox1
        {
            get;set;
        }
        public bool IsComboBox2
        {
            get; set;
        }
        public bool IsComboBox3
        {
            get; set;
        }
        public bool IsComboBox4
        {
            get; set;
        }
        public bool IsTextBox1
        {
            get; set;
        }
        public bool IsTextBox2
        {
            get; set;
        }
        public bool IsTextBox3
        {
            get; set;
        }
        public bool IsTextBox4
        {
            get; set;
        }
        public bool IsTextBox5
        {
            get; set;
        }
        public bool IsTextBox6
        {
            get; set;
        }
        public bool IsTextBox7
        {
            get; set;
        }
        public bool IsTextBox8
        {
            get; set;
        }
        public bool IsButton5
        {
            get; set;
        }
        public bool IsButton4
        {
            get; set;
        }
        public string TextButton5
        {
            get; set;
        }
        public bool IsSpace
        {
            get; set;
        }
        public bool IsDate
        {
            get; set;
        }
        public bool IsChange
        {
            get; set;
        }

        //更改Enable
        public void ChangeAll()
        {
            IsComboBox1 = true;
            IsComboBox2 = true;
            IsComboBox3 = true;
            IsComboBox4 = true;
            IsTextBox1 = true;
            IsTextBox2 = true;
            IsTextBox3 = true;
            IsTextBox4 = true;
            IsTextBox5 = true;
            IsTextBox6 = true;
            IsTextBox7 = true;
            IsTextBox8 = true;
            IsButton5 = false;
        }

        //改變_button4
        public void ChangeButton4()
        {
            IsButton4 = !IsButton4;
            TextButton5 = ADD;
        }

        //改變_button4當按List
        public void ChangeButton4FromList()
        {
            IsButton4 = true;
            TextButton5 = SAVE;
        }

        //檢查條件
        public bool CheckCondition(int mode)
        {
            switch (mode)
            {
                case 0:
                    return IsSpace && IsChange && IsDate;
                case 1:
                    return IsSpace && IsDate;
                default:
                    return false;
            }
        }
    }
}
