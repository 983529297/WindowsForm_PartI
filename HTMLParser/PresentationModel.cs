using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _homeWork
{
    public class PresentationModel
    {
        //設置_button1
        public void SetButton(int count)
        {
            if (count > 0)
            {
                _button1Enable = true;
            }
            else
            {
                _button1Enable = false;
            }
        }

        //判斷ColumnIndex
        public void IsColumnIndex(int count)
        {
            if (count == 0)
            {
                _columnIndex = true;
            }
            else
            {
                _columnIndex = false;
            }
        }
        public bool _button1Enable
        {
            get; set;
        }
        public bool _isForm4
        {
            get; set;
        }
        public bool _columnIndex
        {
            get; set;
        }
    }
}
