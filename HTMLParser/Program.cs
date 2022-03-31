using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _homeWork
{
    class Program
    {
        //執行Form2
        static void Main(string[] args)
        {
            Model1 model = new Model1();
            Model3 model3 = new Model3(model);
            PresentationModel pModel = new PresentationModel();
            PresentationOf3 pModel3 = new PresentationOf3();
            SetUpForm form = new SetUpForm(model, model3, pModel, pModel3);
            Application.Run(form);
        }
    }
}
