namespace Lab9_10CSharpT
{
    public class EmployeeSalaryFilter2
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

            List<Employee> lowSalaryQueue = new();
            List<Employee> highSalaryQueue = new();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: File not found at {filePath}");
                    return;
                }

                using (StreamReader reader = new(filePath))
                {
                    string? header = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(header))
                    {
                        Console.WriteLine("Error: Empty input.");
                        return;
                    }

                    while (!reader.EndOfStream)
                    {
                        string? line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            Console.WriteLine("Error: Empty input.");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] columns = line.Split(',');

                        if (columns.Length != 6)
                        {
                            Console.WriteLine($"Warning: Skipping invalid line: {line}");
                            continue;
                        }

                        string lastName = columns[0].Trim();
                        string firstName = columns[1].Trim();
                        string patronymic = columns[2].Trim();
                        string gender = columns[3].Trim();

                        if (!int.TryParse(columns[4], out int age))
                        {
                            Console.WriteLine($"Warning: Invalid age format in line: {line}");
                            continue;
                        }

                        if (!decimal.TryParse(columns[5], out decimal salary))
                        {
                            Console.WriteLine($"Warning: Invalid salary format in line: {line}");
                            continue;
                        }

                        Employee employee = new(lastName, firstName, patronymic, gender, age, salary);

                        if (salary < 10000)
                            lowSalaryQueue.Add(employee);
                        else
                            highSalaryQueue.Add(employee);
                    }
                }

                Console.WriteLine("\nEmployees with salary less than 10000:");
                if (lowSalaryQueue.Count == 0)
                    Console.WriteLine("None found.");
                else
                    foreach (var employee in lowSalaryQueue)
                    {
                        Console.WriteLine(employee);
                    }

                Console.WriteLine("\nOther employees:");
                if (highSalaryQueue.Count == 0)
                    Console.WriteLine("None found.");
                else
                    foreach (var employee in highSalaryQueue)
                    {
                        Console.WriteLine(employee);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing the file: {ex.Message}");
            }
        }
    }
}
