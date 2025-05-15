namespace Lab9_10CSharpT
{
    public class Employee
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? FathersName { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public Employee(string lastName, string firstName, string fathersName, string gender, int age, decimal salary)
        {
            LastName = lastName;
            FirstName = firstName;
            FathersName = fathersName;
            Gender = gender;
            Age = age;
            Salary = salary;
        }

        public Employee() { }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {FathersName}, " +
                   $"{Gender}, {Age} years old, salary: {Salary} USD";
        }
    }
}
