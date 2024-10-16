using SchoolManagementApp.Models;
using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetStudents();
    }
}
