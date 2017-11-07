using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMarkReportConsoleApp
{

    public class StudentDetails
    {
        public string StudentName { get; set; }
        public int[] studentMarks = new int[5];
        public int TotalMarks { get; set; }
    }

    public class Student
    {
        public static List<StudentDetails> studentList = new List<StudentDetails>();

        public int AddRecord(string name, int[] marks)
        {
            StudentDetails sd = new StudentDetails();
            sd.StudentName = name;
            sd.studentMarks = marks;
            sd.TotalMarks = 0;

            for (int i = 0; i < 5; i++)
            {
                sd.TotalMarks += sd.studentMarks[i];
            }
            studentList.Add(sd);

            return 1;
        }

        public static void ViewRecords()
        {

            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("SNo Student Name        ENG   MATH   PHY    CHE    BIO     Total");
            Console.WriteLine("_______________________________________________________________");
            for (int i = 0; i < studentList.Count; i++)
            {
                Console.Write("{0, -5}", i + 1);
                Console.Write("{0, -19}", studentList[i].StudentName);
                Console.Write("{0, -7}", studentList[i].studentMarks[0]);
                Console.Write("{0, -7}", studentList[i].studentMarks[1]);
                Console.Write("{0, -7}", studentList[i].studentMarks[2]);
                Console.Write("{0, -7}", studentList[i].studentMarks[3]);
                Console.Write("{0, -7}", studentList[i].studentMarks[4]);
                Console.Write("{0, -7}\n", studentList[i].TotalMarks);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {         
            Console.WriteLine("------------Student Marklist Application------------");
            Console.Write("Enter the total number of students: ");

            int noOfStudents = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < noOfStudents; i++)
            {
                Console.WriteLine("\nEnter the Information of student no {0}",(i+1).ToString());
                InputRecords();
            }

            //This below invocation will call the View Records method and publish the Student marklist report
            Student.ViewRecords();
        }

        public static void InputRecords()
        {
            Student s = new Student();
            Console.Write("Enter the Student Name: ");
            string name = Console.ReadLine();

            int[] marks = new int[5];

            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write("Enter Sub {0} Mark: ", (i + 1).ToString());
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            s.AddRecord(name, marks);
        }
    }
}
