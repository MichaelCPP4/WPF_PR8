using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WPF_PR7;

namespace Lib
{
    public class Student : IHuman, ICloneable, IComparable
    {
        string[] _fio;
        int _age;
        int _kurs;

        public string[] Fio
        {
            get => _fio;
            set { _fio = value; }
        }

        public int Age
        {
            get =>_age;
            set
            {
                if (value > 0)
                    _age = value;
                else
                    _age = 1;
            }
        }

        public int Kurs
        {
            get => _kurs;
            set
            {
                if (value > 0)
                    _kurs = value;
                else
                    _kurs = 1;
            }
        }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Student()
        {
            Fio = new string[3];

            Fio[0] = "Имя";
            Fio[1] = "Фамилия";
            Fio[2] = "Отчество";

            Age = 1;
            Kurs = 1;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="fio">ФИО</param>
        /// <param name="age">Возраст</param>
        /// <param name="kurs">Курс</param>
        public Student(string[] fio, int age, int kurs)
        {
            Fio = fio;
            Age = age;
            Kurs=kurs;
        }

        /// <summary>
        /// Конструктор клонирования 
        /// </summary>
        /// <param name="student">Объект для клонирования</param>
        public Student(Student student)
        {
            Fio = student.Fio;
            Age = student.Age;
            Kurs = student.Kurs;
        }

        /// <summary>
        /// Метод для изменения информации о студенте-отце семейства
        /// </summary>
        /// <param name="fio">ФИО</param>
        /// <param name="age">Возраст</param>
        /// <param name="kurs">Курс</param>
        public void SetInformation(string[] fio, int age, int kurs)
        {
            Fio = fio;
            Age = age;
            Kurs = kurs;
        }
        /// <summary>
        /// Переопределённый метод ля представления объекта класса в listBox
        /// </summary>
        /// <returns>Возвращает ФИО студента</returns>
        public override string ToString() => "Студент - " + $"{this.Fio[0]} {this.Fio[1]} {this.Fio[2]}";

        /// <summary>
        /// Поверхностное клонирование
        /// </summary>
        /// <returns>Склонированый объект</returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ShallowClone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Полное клонирование
        /// </summary>
        /// <returns>Возвращает склонированый объект</returns>
        public virtual object Clone()
        {
            Student student = new Student();

            student.Fio = this.Fio;

            student.Age = this.Age;

            student.Kurs = this.Kurs;  
            return student;
        }

        /// <summary>
        /// Сравнение по фамилии
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Результат сравнения</returns>
        public int CompareTo(object obj) => String.Compare(this.ToString(), obj.ToString());

        /// <summary>
        /// Информация о студенте
        /// </summary>
        /// <returns>Возаращает строку</returns>
        virtual public string Info() => $"ФИО: {Fio[0]} {Fio[1]} {Fio[2]} \nВозраст: {Age} \nУчится на {Kurs} курсе";

        /// <summary>
        /// ФИО студента
        /// </summary>
        /// <returns>Возвращает строку</returns>
        public string OnlyName() => $"{Fio[0]} {Fio[1]} {Fio[2]}";
    }
}