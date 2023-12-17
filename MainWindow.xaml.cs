using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Grade> DatabaseGrades { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var courseName = CourseNameTextBox.Text;
                var courseGrade = CourseGradeTextBox.Text;

                if (courseName != null && courseGrade != null)
                {
                    context.Grades.Add(new Grade() { CourseName = courseName, CourseGrade = courseGrade });
                    context.SaveChanges();
                }

                
            }
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseGrades = context.Grades.ToList();
                ItemList.ItemsSource = DatabaseGrades;


            }
        }
        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Grade selectedGrade = ItemList.SelectedItem as Grade;

                if (selectedGrade != null)
                {
                    Grade grade = context.Grades.Find(selectedGrade.Id);

                    

                    context.Remove(grade);
                    context.SaveChanges();

                }


            }
        }
        public void Update()
        {
            using (DataContext context = new DataContext())
            {
                Grade selectedGrade = ItemList.SelectedItem as Grade;

                var courseName = CourseNameTextBox.Text;
                var courseGrade = CourseGradeTextBox.Text;

                if (courseName != null && courseGrade != null)
                {
                    Grade grade = context.Grades.Single(x=> x.Id == selectedGrade.Id);

                    grade.CourseName = courseName;
                    grade.CourseGrade = courseGrade;

                    context.SaveChanges();

                }


            }
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            ItemList.Items.Clear();

        }
    }   
}