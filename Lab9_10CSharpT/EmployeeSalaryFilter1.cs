namespace Lab9_10CSharpT
{
    public class EmployeeSalaryFilter1
    {
        public static void Task()
        {
            Console.Write("Enter the file: ");
            string? filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Error: Empty input.");
                return;
            }

            if (!File.Exists(filePath))
            {
                string directory = Path.GetDirectoryName(filePath) ?? filePath;
                string fileName = "data.txt";
                string fullPath = Path.Combine(directory, fileName);

                if (!File.Exists(fullPath))
                {
                    Console.WriteLine($"Error: File does not exist.");
                    return;
                }

                filePath = fullPath;
            }

            Queue<Employee> lowSalaryQueue = new();
            Queue<Employee> highSalaryQueue = new();
            string[] lines;

            try
            {
                lines = File.ReadAllLines(filePath);

                if (lines.Length <= 1)
                {
                    Console.WriteLine("Error: File is empty or contains only headers.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }

            Console.WriteLine($"Processing {lines.Length - 1} employee records...");

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] columns = line.Split(',');

                if (columns.Length != 6)
                {
                    Console.WriteLine($"Warning: Line {i + 1} has incorrect format. Expected 6 columns, got {columns.Length}.");
                    continue;
                }

                string lastName = columns[0].Trim();
                string firstName = columns[1].Trim();
                string patronymic = columns[2].Trim();
                string gender = columns[3].Trim();

                if (!int.TryParse(columns[4], out int age))
                {
                    Console.WriteLine($"Warning: Line {i + 1} has invalid age format.");
                    continue;
                }

                if (!decimal.TryParse(columns[5], out decimal salary))
                {
                    Console.WriteLine($"Warning: Line {i + 1} has invalid salary format.");
                    continue;
                }

                Employee employee = new()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    FathersName = patronymic,
                    Gender = gender,
                    Age = age,
                    Salary = salary
                };

                if (salary < 10000)
                    lowSalaryQueue.Enqueue(employee);
                else
                    highSalaryQueue.Enqueue(employee);
            }

            Console.WriteLine($"\nEmployees with salary less than 10000 ({lowSalaryQueue.Count}):");
            if (lowSalaryQueue.Count == 0)
            {
                Console.WriteLine("None found.");
            }
            else
            {
                while (lowSalaryQueue.Count > 0)
                    Console.WriteLine(lowSalaryQueue.Dequeue());
            }

            Console.WriteLine($"\nOther employees ({highSalaryQueue.Count}):");
            if (highSalaryQueue.Count == 0)
            {
                Console.WriteLine("None found.");
            }
            else
            {
                while (highSalaryQueue.Count > 0)
                    Console.WriteLine(highSalaryQueue.Dequeue());
            }
        }
    }
}
