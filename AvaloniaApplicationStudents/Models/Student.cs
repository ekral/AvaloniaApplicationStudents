namespace AvaloniaApplicationStudents.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfStudy { get; set; }

        public Student(string name, int yearOfStudy)
        {
            Name = name;
            YearOfStudy = yearOfStudy;
        }
    }
}
