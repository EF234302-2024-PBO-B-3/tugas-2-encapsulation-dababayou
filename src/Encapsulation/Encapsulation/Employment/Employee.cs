namespace Encapsulation.Employment
{
    public class Employee
    {
        private string _firstName;
        private string _lastName;
        private double _monthlySalary;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _firstName = "Unknown";
                }
                else
                {
                    _firstName = value;
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _lastName = "Unknown";
                }
                else
                {
                    _lastName = value;
                }
            }
        }

        public double MonthlySalary
        {
            get { return _monthlySalary; }
            set
            {
                if (value >= 0)
                {
                    _monthlySalary = value;
                }
            }
        }

        public Employee(string firstName, string lastName, double monthlySalary)
        {
            FirstName = firstName; 
            LastName = lastName; 
            MonthlySalary = monthlySalary >= 0 ? monthlySalary : 0.0;
        }

        public void RaiseSalary(int raisePercentage)
        {
            if (raisePercentage > 0 && raisePercentage <= 20)
            {
                _monthlySalary += _monthlySalary * raisePercentage / 100.0;
            }
        }

        public double GetYearlySalary()
        {
            return _monthlySalary * 12;
        }
    }
}
