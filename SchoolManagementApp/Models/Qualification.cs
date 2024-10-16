using System;

namespace SchoolManagementApp.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public double Percentage { get; set; }
        public int YearOfPassing { get; set; }

        public string University {  get; set; }
    }
}
