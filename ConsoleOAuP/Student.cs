using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Base
{
    class Student : Person, IDateAndCopy
    {

        private Education EducationInfo;
        private int GroupNumber;
        private System.Collections.ArrayList Test;
        private System.Collections.ArrayList Exam;
        private Person PersonInfo;


        public Student(Person personInfo, Education educationInfo, int groupNumber)
        {
            this.EducationInfo = educationInfo;
            this.GroupNumber = groupNumber;
            this.Test = new System.Collections.ArrayList();
            this.Exam = new System.Collections.ArrayList();
            this.PersonInfo = personInfo;

        }

        public Student()
        {
            this.EducationInfo = Education.Specialist;
            this.GroupNumber = 320;
            this.Test = new System.Collections.ArrayList();
            this.Exam = new System.Collections.ArrayList();
            this.PersonInfo = new Person();

        }

        public Education Educations
        {
            get { return EducationInfo; }
            set { EducationInfo = value; }
        }

        public int GroupNumbers
        {
            get { return GroupNumber; }
            set
            {
                if (value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Номер группы не из диапазона 100 - 599");
                }
                GroupNumber = value;
            }
        }

        public Person Persons
        {
            get { return PersonInfo; }
            set { PersonInfo = value; }
        }

        public System.Collections.ArrayList Exams
        {
            get { return Exam; }
            set { Exam = value; }
        }
        public System.Collections.ArrayList Tests
        {
            get { return Test; }
            set { Test = value; }
        }


        public double AverageEvaluation
        {
            get
            {
                int sum = 0;
                foreach (Exam Exam in Exam)
                {
                    sum = sum + Exam.Evaluation;
                }
                return (double)sum / Exam.Count;
            }
        }




        public void AddExams(params Exam[] Exam)
        {
            this.Exam.AddRange(Exam);
        }

        public void AddTests(params Test[] Test)
        {
            this.Test.AddRange(Test);
        }


        public override string ToString()
        {
            StringBuilder strineg = new StringBuilder();
            strineg.AppendFormat("{0} {1} {2}", base.ToString(), GroupNumber, EducationInfo);
            foreach (Exam exam in Exam)
                strineg.AppendLine(exam.ToString());
            foreach (Test test in Test)
                strineg.AppendLine(test.ToString());
            return strineg.ToString();
        }


        public override string ToShortString()
        {
            return
                base.ToShortString() +
                string.Format(
                "{0}, {1}, {2}, AVG Evaluation = {3}",
                Persons,
                Educations,
                GroupNumber,
                AverageEvaluation
            );
        }

        public override object DeepCopy()
        {
            var stud = new Student(PersonInfo, EducationInfo, GroupNumber);
            foreach (Exam exam in this.Exam)
            {
                stud.AddExams(exam);
            }
            foreach (Test test in this.Test)
            {
                stud.AddTests(test);
            }
            return stud;
        }

        public IEnumerable<object> GetResults()
        {
            foreach (var exam in Exam)
                yield return exam;
            foreach (var test in Test)
                yield return test;
        }


        public IEnumerable<Exam> ExamsOver(int minRate)
        {
            foreach (var exam in Exam)
            {
                Exam ex = (Exam)exam;
                if (ex.Evaluation > minRate)
                    yield return (Exam)exam;
            }
        }











        /*
        private Person Person;
        private Education Education;
        private int Group;
        private readonly List<Exam> exams = new List<Exam>();


        public Student(Person person, Education education, int group)
        {
            this.Person = person;
            this.Education = education;
            this.Group = group;
        }

        public Student()
        {
            this.Person = new Person();
            this.Education = Education.Specialist;
            this.Group = 320;
        }


        public Person Persons
        {
            get { return Person; }
            set { Person = value; }
        }

        public Education Educations
        {
            get { return Education; }
            set { Education = value; }
        }

        public int Groups
        {
            get { return Group; }
            set { Group = value; }
        }

        public Exam[] Exams
        {
            get { return exams.ToArray(); }

        }

        public double AvgEvaluation
        {
            get { return exams.Count > 0 ? exams.Average(p => p.Evaluation) : 0; }
        }

        public bool this[Education index]
        {
            get { return this.Education == index; }
        }

        public void AddExams(params Exam[] exams)
        {
            this.exams.AddRange(exams);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Person, Education, Group, string.Join(",", exams));
        }

        public string ToShortString()
        {
            return string.Format("{0} {1} {2} {3:0.00}", Person, Education, Group, AvgEvaluation);
        }
        */

    }

}


