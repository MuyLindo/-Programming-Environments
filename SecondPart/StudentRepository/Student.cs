using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
   public class Student
    {
        public String Name { get; set; }
        public String SecondName { get; set; }
        public String ThirdName { get; set; }
        public String Faculty { get; set; }
        public String Specialty { get; set; }
        public String Degree { get; set; }
        public Status Status { get; set; }
        public String FacultyNumber { get; set; }
        public Int32 Course { get; set; }
        public Int32 Stream { get; set; }
        public Int32 Group { get; set; }
        public DateTime LastAuthentDate { get; set; }
        public DateTime LastPaymentDate { get; set; }

        public Student(String Name, String SecondName, String ThirdName, String Faculty, String Specialty,
            String Degree, Status Status, String FacultyNumber, Int32 Course, Int32 Stream, Int32 Group)
        {
            this.Name = Name;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.Faculty = Faculty;
            this.Specialty = Specialty;
            this.Degree = Degree;
            this.Status = Status;
            this.FacultyNumber = FacultyNumber;
            this.Course = Course;
            this.Stream = Stream;
            this.Group = Group;
        }

        public Student(String Name, String SecondName, String ThirdName, String Faculty, String Specialty,
           String Degree, Status Status, String FacultyNumber, Int32 Course, Int32 Stream, Int32 Group, 
           DateTime LastAuthentDate, DateTime LastPaymentDate)
        {
            this.Name = Name;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.Faculty = Faculty;
            this.Specialty = Specialty;
            this.Degree = Degree;
            this.Status = Status;
            this.FacultyNumber = FacultyNumber;
            this.Course = Course;
            this.Stream = Stream;
            this.Group = Group;
        }

    }
}
