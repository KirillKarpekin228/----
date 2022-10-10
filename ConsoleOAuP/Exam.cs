namespace Base
{
    class Exam : IDateAndCopy
    {
        public string NameSubject { get; set; }
        public int Evaluation { get; set; }

        public System.DateTime ExamOfDate { get; set; }


        public Exam(string nameSubject, int evaluation, DateTime examOfDate)
        {
            this.NameSubject = nameSubject;
            this.Evaluation = evaluation;
            this.ExamOfDate = examOfDate;
        }


        public Exam()
        {
            this.NameSubject = "ru";
            this.Evaluation = 3;
            this.ExamOfDate = new DateTime(2022, 09, 27);
        }


        public override string ToString()
        {
            return NameSubject + " " + Evaluation + " " + ExamOfDate;
        }

        public object DeepCopy()
        {
            return new Exam(NameSubject, Evaluation, ExamOfDate);
        }

        DateTime IDateAndCopy.Date
        {
            get { return ExamOfDate; }
            set { ExamOfDate = value; }

        }
    }

}


