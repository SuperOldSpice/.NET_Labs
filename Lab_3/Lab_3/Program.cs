using UniversityLibrary;
namespace Lab_3
{
    class Program
    {
        static public void Main()
        {
            var student1 = new Student(name: "Mark Tyson", email: "mark@yahoo.com", 
                phone: "+380123123123", new BudgetForm(0, 13500), 
                new BachelorsDegree(new DateTime(2021, 09, 1), group: "ІС-01", 8));
            Console.WriteLine(student1.GetDegree());

            student1.FinishSession(passedAllSubjects: true);
            Console.WriteLine(student1.GetDegree());

            student1.FinishSession(passedAllSubjects: false);
            student1.DepositFunds(8000);
            student1.RestoreStudent(8000);
            Console.WriteLine(student1.GetEducationForm());

            for(int i = 0; i < 6; i++)
            {
                student1.DepositFunds(12000);
                student1.DepositFunds(1500);
                student1.FinishSession(passedAllSubjects: true);
            }

            Console.WriteLine(student1.GetDegree());
        }
    }
}
