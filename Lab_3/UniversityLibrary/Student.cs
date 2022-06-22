namespace UniversityLibrary
{
    public class Student
    {
        private string _name;
        private string _email;
        private string _phone;
        private EducationForm _form;
        private Degree _degree;
        private bool _expelled = false;
        public Student(string name, string email, string phone, 
            EducationForm form, Degree degree)
        {
            this._name = name;
            this._email = email;
            this._phone = phone;
            this._form = form;
            this._degree = degree;
        }
        public void ExpellStudent()
        {
            this._expelled = true;
        }

        public void RestoreStudent(decimal price)
        {
            if (this._form.score >= price) 
            {
                this._form.Pay(price);
                this._expelled = false;
                this._form = new ContractForm(_form.score, _form.contractPrice);
            }
        }

        public void DepositFunds(decimal sum)
        {
            this._form.DepositFunds(sum);
        }

        public void MoveToBudget()
        {
            this._form = new BudgetForm(_form.score, _form.contractPrice);
        }

        public void FinishSession(bool passedAllSubjects)
        {
            if (!this._form.CheckPayment() || !passedAllSubjects)
            {
                this.ExpellStudent();
            }
            else
            {
                uint semester = this._degree.FinishSession();
                switch (semester)
                {
                    case 9:
                        _degree = new MastersDegree(_degree.startDate, _degree.group,
                            _degree.semester);
                        break;
                    case 15:
                        _degree = new PhDDegree(_degree.startDate, _degree.group,
                            _degree.semester);
                        break;
                    default:
                        break;
                }
            }
        }

        public string GetDegree()
        {
            return this._degree.GetType().Name;
        }

        public string GetEducationForm()
        {
            return this._form.GetType().Name;
        }
    }
}