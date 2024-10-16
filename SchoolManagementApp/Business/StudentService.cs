using System.Collections.Generic;
using SchoolManagementApp.Models;
using SchoolManagementApp.DataAccess;

namespace SchoolManagementApp.Business
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void RegisterStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetStudents();
        }

       
    }
}
