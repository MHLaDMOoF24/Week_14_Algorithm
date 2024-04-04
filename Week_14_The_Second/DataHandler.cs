using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Week_14_The_Second
{
    public class DataHandler
    {
        private string _dataFileName = "students.txt";
        private string docPath = Environment.CurrentDirectory;

        public string DataFileName
        {
            get { return _dataFileName; }
        }

        public DataHandler(string dataFileName)
        {
            _dataFileName = dataFileName;
        }


        public Student LoadStudent()
        {

            using (StreamReader sr = new StreamReader(Path.Combine(docPath,DataFileName)))
            {

                string line = sr.ReadLine();

                string[] parts = line.Split(';');


                if (parts.Length != 2)
                {
                    throw new InvalidDataException("Dataformat in file not correct");
                }

                Student student = new Student(parts[0], int.Parse(parts[1]));
                return student;
            }


        }

        public Student[] LoadStudents()
        {
            List<Student> students = new List<Student>();

            using (StreamReader sr = new StreamReader(Path.Combine(docPath, DataFileName)))
            {
                foreach (string line in sr.ReadToEnd().Trim().Split('\n'))
                {
                    string[] parts = line.Trim().Split(',');

                    if (parts.Length != 2)
                    {
                        throw new InvalidDataException("Dataformat in file not correct");
                    }

                    Student student = new Student(parts[0], int.Parse(parts[1]));
                    students.Add(student);
                }

            }
            return students.ToArray();
        }

        public void SavePerson(Student student)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(docPath, DataFileName)))
            {
                sw.WriteLine(student.MakeStudent());
            }

        }

        public void SavePersons(Student[] student)
        {

            using (StreamWriter sw = new StreamWriter(Path.Combine(docPath, DataFileName)))
            {
                for (int i = 0; i < student.Length; i++)
                {
                    sw.WriteLine(student[i].MakeStudent());
                }

            }
        }


    }
}
