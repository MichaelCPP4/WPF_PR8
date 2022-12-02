using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{

    public class FatherStudent : Student
    {
        int _numChild;

        public int NumChild
        {
            get { return _numChild; }
            set
            {
                if (value > 0)
                {
                    _numChild = value;
                }
                else
                {
                    _numChild = 1;
                }
            }
        }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public FatherStudent() : base()
        {
            _numChild = 1;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="fio">ФИО</param>
        /// <param name="age">Возраст</param>
        public FatherStudent(string[] fio, int age, int kurs) : base(fio, age, kurs)
        {
            _numChild = 1;
            //Fio = fio;
        }

        public FatherStudent(string[] fio, int age, int kurs, int numChild) : base(fio, age, kurs)
        {
            _numChild = numChild;
            //Fio = fio;
        }

        /// <summary>
        /// Конструктор клонирования
        /// </summary>
        /// <param name="fatherStudent">Студент-отец семейства</param>
        public FatherStudent(FatherStudent fatherStudent)
        {
            Fio = fatherStudent.Fio;
            Age = fatherStudent.Age;
            Kurs = fatherStudent.Kurs;
            NumChild = fatherStudent.NumChild;
        }

        /// <summary>
        /// Метод для изменения информации о студенте-отце семейства
        /// </summary>
        /// <param name="fio">ФИО</param>
        /// <param name="age">Возраст</param>
        /// <param name="numChild">Кол-во детей у отца</param>
        public void SetInformation(string[] fio, int age, int kurs, int numChild)
        {
            Fio = fio;
            Age = age;
            Kurs = kurs;
            NumChild = numChild;
        }

        /// <summary>
        /// Переопределённый метод ля представления объекта класса в listBox
        /// </summary>
        /// <returns>Возвращает ФИО студента-отца семейства</returns>
        public override string ToString()
        {
            //return "Студент - " + this.Name;
            return "Студент-отец - " + $"{this.Fio[0]} {this.Fio[1]} {this.Fio[2]}";
        }

        /// <summary>
        /// Полное клонирование
        /// </summary>
        /// <returns>Возвращает склонированый объект</returns>
        public override object Clone()
        {
            FatherStudent fatherStudent = new FatherStudent();
            fatherStudent.Fio = this.Fio;
            fatherStudent.Age = this.Age;
            fatherStudent.NumChild = this.NumChild;
            fatherStudent.Kurs = this.Kurs;

            return fatherStudent;
        }

        override public string Info()
        {
            return $"ФИО: {Fio[0]} {Fio[1]} {Fio[2]} \nВозраст: {Age} \nКол-во детей: {NumChild} \nУчится на {Kurs} курсе";
        }
    }
}