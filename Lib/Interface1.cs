using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PR7
{
    internal interface IHuman
    {
        string[] Fio { get; set; }
        //string Name { get; set; }
        int Age { get; set; }

        int Kurs { get; set; }

        string Info();

        string OnlyName();

        void SetInformation(string[] fio, int age, int kurs);
    }
}
