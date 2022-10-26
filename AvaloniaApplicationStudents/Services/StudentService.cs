using AvaloniaApplicationStudents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaloniaApplicationStudents.Services
{

    public class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>()
            {
                new Student("Jiri", 1) { Id= 1 },
                new Student("Karel", 2) { Id= 2 },
                new Student("Pavla", 2) { Id= 3 },
            };
        }

        public async Task<List<Student>> GetAllAsync()
        {
            await Task.Delay(1000);
            return students;
        }

        public async Task AddStudent(Student student)
        {
            await Task.Delay(1000);
            student.Id = students.Max(x => x.Id) + 1;
            students.Add(student);
        }
    }
}
