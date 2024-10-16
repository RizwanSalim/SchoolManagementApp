using SchoolManagementApp.Models;
using System.Collections.Generic;

namespace SchoolManagementApp.Business
{
    public interface IStudentService
    {
        void RegisterStudent(Student student);
        List<Student> GetAllStudents();
       
    }
}
