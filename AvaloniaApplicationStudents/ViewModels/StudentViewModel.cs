using AvaloniaApplicationStudents.Models;

namespace AvaloniaApplicationStudents.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public Student Student { get; init; }

        public StudentViewModel(Student student)
        {
            this.Student = student;
        }

        public int Id => Student.Id;

        public string Name
        {
            get => Student.Name;
            set => SetProperty(Student.Name, value, Student, (m, v) => m.Name = v);
        }

        public int YearOfStudy
        {
            get => Student.YearOfStudy;
            set => SetProperty(Student.YearOfStudy, value, Student, (m, v) => m.YearOfStudy = v);
        }
    }
}
