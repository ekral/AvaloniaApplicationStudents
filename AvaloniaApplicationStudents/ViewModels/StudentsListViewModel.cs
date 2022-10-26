using AvaloniaApplicationStudents.Models;
using AvaloniaApplicationStudents.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AvaloniaApplicationStudents.ViewModels
{
    public class StudentsListViewModel : ViewModelBase
    {

        private readonly StudentService studentService;

        private ObservableCollection<StudentViewModel> students = new ObservableCollection<StudentViewModel>();

        public ObservableCollection<StudentViewModel> Students
        {
            get => students;
            private set => SetProperty(ref students, value);
            
        }

        private StudentViewModel? selectedStudent;
        public StudentViewModel? SelectedStudent
        {
            get => selectedStudent;
            set => SetProperty(ref selectedStudent, value);
        }

        private StudentViewModel newStudent = new StudentViewModel(new Student("Novy", 1));
        public StudentViewModel NewStudent
        {
            get => newStudent;
            set => SetProperty(ref newStudent, value);
        }

        public StudentsListViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public async Task LoadStudentsAsync()
        {
            List<Student> students = await studentService.GetAllAsync();

            var studentViewModels = students.Select(x => new StudentViewModel(x));
            Students = new ObservableCollection<StudentViewModel>(studentViewModels);

            SelectedStudent = Students.FirstOrDefault();
        }

        public async Task AddNewStudentAsync()
        {   
            // TODO osetrit pridavani vice studentu
            await studentService.AddStudent(NewStudent.Student);
            Students.Add(NewStudent);
        }
    }
}
