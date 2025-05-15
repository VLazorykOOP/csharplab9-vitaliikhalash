namespace Lab9_10CSharpT
{
    public class PostfixToPrefixConverter2
    {
        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        public static void Task()
        {
            Console.Write("Enter a postfix expression: ");
            string? postfix = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(postfix))
            {
                Console.WriteLine("Error: Empty input.");
                return;
            }

            List<string> stack = [];
            string PopFromList()
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("Error: Stack underflow.");
                    return string.Empty;
                }
                string ret = stack[^1];
                stack.RemoveAt(stack.Count - 1);
                return ret;
            }

            foreach (char c in postfix)
            {
                if (char.IsWhiteSpace(c))
                    continue;

                if (IsOperator(c))
                {
                    string operand2 = PopFromList();
                    string operand1 = PopFromList();

                    string expression = $"{c} {operand1} {operand2}";
                    stack.Add(expression);
                }
                else
                {
                    stack.Add(c.ToString());
                }
            }

            if (stack.Count != 1)
            {
                Console.WriteLine("Error: Invalid postfix expression.");
                return;
            }

            string prefix = stack[0];
            Console.WriteLine("Prefix expression: " + prefix);
        }
    }
}
