using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib;

namespace WPF_PR7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxAgeStudent.Text, out int age) && textBoxNameStudent.Text != String.Empty && int.TryParse(textBoxKursStudent.Text, out int kurs))
                {
                    string[] fio = textBoxNameStudent.Text.Split(new char[] { ' ' });
                    Student student = new Student(fio, age, kurs);
                    listBox.Items.Add(student);
                }
                else
                {
                    MessageBox.Show("Введены не все данные или введены некоректно.");
                    textBoxNameStudent.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonCreateFatherStudent_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxAgeFatherStudent.Text, out int age) && textBoxNameFatherStudent.Text != String.Empty && int.TryParse(textBoxNumChieldFatherStudent.Text, out int numChield) && int.TryParse(textBoxKursFatherStudent.Text, out int kurs))
            {
                string[] fio = textBoxNameFatherStudent.Text.Split(new char[] { ' ' });
                if (fio.Length == 3)
                {
                    FatherStudent fatherStudent = new FatherStudent(fio, age, kurs, numChield);
                    listBox.Items.Add(fatherStudent);
                }
                else
                {
                    MessageBox.Show("Введены не все данные или введены некоректно.", "Error");
                    textBoxNameFatherStudent.Focus();
                }
            }
            else
            {
                MessageBox.Show("Введены не все данные или введены некоректно.", "Error");
            }
        }

        private void ButtonClon_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem.GetType() == typeof(Student))
            {
                Student student = listBox.SelectedItem as Student;
                listBox.Items.Add(student.Clone());
            }
            else
            {
                FatherStudent fatherStudent = listBox.SelectedItem as FatherStudent;
                listBox.Items.Add(fatherStudent.Clone());
            }
        }

        private void ButtonVivod_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem.GetType() == typeof(Student))
            {
                Student student = listBox.SelectedItem as Student;
                infoHuman.Text = student.Info();
            }
            else
            {
                FatherStudent fatherStudent = listBox.SelectedItem as FatherStudent;
                infoHuman.Text = fatherStudent.Info();
            }
        }

        private void ButtonV1_Click(object sender, RoutedEventArgs e)
        {
            if(listBox.SelectedItem == null)
            {
                MessageBox.Show("Выберете студента в из списка.","Error");
            }
            else if (listBox.SelectedItem.GetType() == typeof(Student))
            {
                Student student = listBox.SelectedItem as Student;
                textBoxSrav1.Text = student.OnlyName();
            }
            else
            {
                FatherStudent fatherStudent = listBox.SelectedItem as FatherStudent;
                textBoxSrav1.Text = fatherStudent.OnlyName();
            }
        }

        private void ButtonV2_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("Выберете студента в из списка.", "Error");
            }
            else if (listBox.SelectedItem.GetType() == typeof(Student))
            {
                Student student = listBox.SelectedItem as Student;
                textBoxSrav2.Text = student.OnlyName();
            }
            else
            {
                FatherStudent fatherStudent = listBox.SelectedItem as FatherStudent;
                textBoxSrav2.Text = fatherStudent.OnlyName();
            }
        }

        private void ButtonU1_Click(object sender, RoutedEventArgs e)
        {
            textBoxSrav1.Clear();
        }

        private void ButtonU2_Click(object sender, RoutedEventArgs e)
        {
            textBoxSrav2.Clear();
        }

        private void ButtonSrav_Click(object sender, RoutedEventArgs e)
        {
            string[] fio1 = textBoxSrav1.Text.Split(new char[] { ' ' });
            string[] fio2 = textBoxSrav2.Text.Split(new char[] { ' ' });

            if (fio1[0] == String.Empty && fio2[0] == String.Empty)
            {
                MessageBox.Show("Выберете студуентов для сравнения.");
            }
            else if (String.Equals(fio1[0], fio2[0]))
            {
                textBoxResult.Text = "У этих студентов одинаковые фамилии.";
            }
            else
            {
                textBoxResult.Text = "У этих студентов разные фамилии.";
            }
        }
        private void MenuItemInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создать интерфейс - человек. Создать классы – студент и студент-отец семейства.\r\nКлассы должны включать конструкторы, функцию для формирования строки\r\nинформации о студенте. Сравнение производить по фамилии.\nРеализовал Иванов Михаил ИСП-31", "О программе");
        }
    }
}