using System;

namespace LogicalFunctionProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Introduction of logical functions
            Console.WriteLine("Enter expression using reverse Polish notation");
            string expression = Console.ReadLine();
            int result = EvaluateExpression(expression);
            Console.WriteLine("Result = {0}", result);

            // Writing and reading from a file
            string fileName = "expression.txt";
            WriteToFile(fileName, expression);
            string expressionFromFile = ReadFromFile(fileName);
            Console.WriteLine("Expression from file = {0}", expressionFromFile);

            // Solving a function for given parameters
            int parameter1 = 10;
            int parameter2 = 20;
            int resultFromParameters = SolveFunction(expression, parameter1, parameter2);
            Console.WriteLine("Result from parameters = {0}", resultFromParameters);

            // Construct a truth table for a logic function
            int[][] truthTable = ConstructTruthTable(expression);
            Console.WriteLine("Truth table:");
            foreach (int[] row in truthTable)
            {
                foreach (int cell in row)
                {
                    Console.Write(cell + " ");
                }
                Console.WriteLine();
            }

            // Interpreter for logical operations
            result = InterpretExpression(expression);
            Console.WriteLine("Interpreted result = {0}", result);
        }

        // Introduction of logical functions
        static int EvaluateExpression(string expression)
        {
            // Parse expression into tokens
            string[] tokens = ParseExpression(expression);

            // Evaluate expression
            int result = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case "+":
                        result = int.Parse(tokens[i - 2]) + int.Parse(tokens[i - 1]);
                        break;
                    case "-":
                        result = int.Parse(tokens[i - 2]) - int.Parse(tokens[i - 1]);
                        break;
                    case "*":
                        result = int.Parse(tokens[i - 2]) * int.Parse(tokens[i - 1]);
                        break;
                    case "/":
                        result = int.Parse(tokens[i - 2]) / int.Parse(tokens[i - 1]);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        // Writing and reading from a file
        // Writing and reading from a file
        static void WriteToFile(string fileName, string expression)
        {
            // Write expression to file
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(expression);
            }
        }

        static string ReadFromFile(string fileName)
        {
            // Read expression from file
            string expression = "";
            using (StreamReader sr = new StreamReader(fileName))
            {
                expression = sr.ReadToEnd();
            }

            return expression;
        }

        // Solving a function for given parameters
        static int SolveFunction(string expression, int parameter1, int parameter2)
        {
            // Parse expression into tokens
            string[] tokens = ParseExpression(expression);

            // Set parameters
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "P1")
                {
                    tokens[i] = parameter1.ToString();
                }
                else if (tokens[i] == "P2")
                {
                    tokens[i] = parameter2.ToString();
                }
            }

            // Solve expression with parameters
            int result = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case "+":
                        result = int.Parse(tokens[i - 2]) + int.Parse(tokens[i - 1]);
                        break;
                    case "-":
                        result = int.Parse(tokens[i - 2]) - int.Parse(tokens[i - 1]);
                        break;
                    case "*":
                        result = int.Parse(tokens[i - 2]) * int.Parse(tokens[i - 1]);
                        break;
                    case "/":
                        result = int.Parse(tokens[i - 2]) / int.Parse(tokens[i - 1]);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        // Construct a truth table for a logic function
        static int[][] ConstructTruthTable(string expression)
        {
            // Parse expression into tokens
            string[] tokens = ParseExpression(expression);

            // Generate variations for the operands
            List<int[]> variations = new List<int[]>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "A" || tokens[i] == "B")
                {
                    variations.Add(new int[] { 0, 1 });
                }
            }

            // Construct truth table
            int[][] truthTable = new int[variations.Count][];
            for (int i = 0; i < variations.Count; i++)
            {
                truthTable[i] = new int[variations[i].Length];
                for (int j = 0; j < variations[i].Length; j++)
                {
                    truthTable[i][j] = variations[i][j];
                }
            }

            return truthTable;
        }

        // Interpreter for logical operations
        static int InterpretExpression(string expression)
        {
            // Parse expression into tokens
            string[] tokens = ParseExpression(expression);

            // Interpret expression
            int result = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case "AND":
                        result = int.Parse(tokens[i - 2]) & int.Parse(tokens[i - 1]);
                        break;
                    case "OR":
                        result = int.Parse(tokens[i - 2]) | int.Parse(tokens[i - 1]);
                        break;
                    case "XOR":
                        result = int.Parse(tokens[i - 2]) ^ int.Parse(tokens[i - 1]);
                        break;
                    case "NOT":
                        result = ~int.Parse(tokens[i - 1]);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        // Parse expression into tokens
        static string[] ParseExpression(string expression)
        {
            // Split expression into tokens
            string[] tokens = expression.Split(' ');

            return tokens;
        }
    }
}