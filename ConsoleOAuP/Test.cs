namespace Base
{
    public class Test
    {
        public string NameSubject { get; set; }
        public bool PassedOrNot { get; set; }


        public Test(string nameSubject, bool passedOrNot)
        {
            NameSubject = nameSubject;
            PassedOrNot = passedOrNot;
        }

        public Test()
        {
            NameSubject = "OAiP";
            PassedOrNot = true;
        }

        public override string ToString()
        {
            return String.Format("Subject = {0}, PassedOrNot = {1}", NameSubject, PassedOrNot);
        }
    }
}


