using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using StudentRepository;


namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.Title = "Student Information System";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var currentChild in mainGrid.Children)
            {
                if (currentChild is TextBox)
                {
                    ((TextBox)currentChild).Text = Environment.NewLine;

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Student student = StudentData.TestStudents[0];
            firstName.Text = student.Name;
            surName.Text = student.SecondName;
            lastName.Text = student.ThirdName;
            faculty.Text = student.Faculty;
            specialty.Text = student.Specialty;
            degree.Text = student.Degree;
            status.Text = student.Status.ToString();
            facultyNumber.Text = student.FacultyNumber;
            course.Text = student.Course.ToString();
            flow.Text = student.Stream.ToString();
            group.Text = student.Group.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (var currentChild in mainGrid.Children)
            {
                if (currentChild is TextBox)
                {
                    ((TextBox)currentChild).IsEnabled = false;

                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            foreach (var currentChild in mainGrid.Children)
            {
                if (currentChild is TextBox)
                {
                    ((TextBox)currentChild).IsEnabled = true;

                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (File.Exists("test.txt") == true)
            {
                string s;
                s = File.ReadAllText("test.txt");
                Listbox.Items.Add(s);

            }
        }
    }
}
