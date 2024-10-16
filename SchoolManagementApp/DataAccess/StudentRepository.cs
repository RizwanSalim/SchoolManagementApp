using SchoolManagementApp.Models;
using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess
{
    public class StudentRepository : IStudentRepository
    {
        private static List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            student.StudentId = _students.Count + 1; 
            _students.Add(student);

        }

        public List<Student> GetStudents()
        {
            return _students;
        }

       
    }
}
