namespace Lab9_10CSharpT
{
    public class PostfixToPrefixConverter1
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

            Stack<string> stack = new();
            string[] tokens = postfix.Split();

            foreach (string token in tokens)
            {
                if (token.Length == 1 && IsOperator(token[0]))
                {
                    if (stack.Count < 2)
                    {
                        Console.WriteLine("Error: Not enough operands in the expression.");
                        return;
                    }

                    string operand2 = stack.Pop();
                    string operand1 = stack.Pop();

                    string expression = token + " " + operand1 + " " + operand2;
                    stack.Push(expression);
                }
                else
                {
                    stack.Push(token);
                }
            }

            if (stack.Count != 1)
            {
                Console.WriteLine("Error: Invalid postfix expression.");
                return;
            }

            string prefix = stack.Pop();
            Console.WriteLine($"Prefix expression: {prefix}");
        }
    }
}
