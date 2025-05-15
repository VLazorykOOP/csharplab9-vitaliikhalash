namespace Lab9_10CSharpT
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Enter option 1-4: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 4;

            while (!isValid)
            {
                Console.Write("Please enter a valid option. Enter option 1-4: ");
                isValid = int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 4;
            }

            switch (option)
            {
                case 1: PostfixToPrefixConverter1.Task(); break;
                case 2: EmployeeSalaryFilter1.Task(); break;
                case 3: PostfixToPrefixConverter2.Task(); EmployeeSalaryFilter2.Task(); break;
                case 4: MusicManager.Task(); break;
            }
        }
    }
}
