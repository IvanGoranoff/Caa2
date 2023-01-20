using System;
using System.IO;

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
        static void WriteToFile(string fileName, string expression)
        {
            // Write expression to file
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(expression);
            }
        }

        // Function to parse an expression into a list of logic nodes
        public static List<LogicNode> Parse(string expression)
        {
            // Initialize an empty list of logic nodes
            List<LogicNode> nodes = new List<LogicNode>();

            // Iterate over each character of the expression
            for (int i = 0; i < expression.Length; i++)
            {
                // Get the character at the current position
                char c = expression[i];

                // Check if the character is an operator
                if (c == '&' || c == '|' || c == '!')
                {
                    // Create a logic node for the operator
                    LogicNode node = new LogicNode(expression[i], false);
                    nodes.Add(node);
                }
                else if (Char.IsLetterOrDigit(c))
                {
                    // Create a logic node for the variable
                    LogicNode node = new LogicNode(expression[i], true);
                    nodes.Add(node);
                }
            }

            // Return the list of logic nodes
            return nodes;
        }

        // Function to get the list of variables from a list of logic nodes
        // Function to get the list of variables from a list of logic nodes
        public static List<string> GetVariables(List<LogicNode> nodes)
        {
            // Initialize an empty list of variables
            List<string> variables = new List<string>();

            // Iterate over each node in the list
            foreach (LogicNode node in nodes)
            {
                // Check if the node is a variable
                if (node.IsVariable)
                {
                    // Add the variable to the list
                    variables.Add(node.Value.ToString());
                }
            }

            // Return the list of variables
            return variables;
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
        // Solving a function for given parameters

        static int SolveFunction(string expression, int parameter1, int parameter2)
        {
            string[] tokens = ParseExpression(expression);
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
            int result = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case "+":
                        result = int.Parse(tokens[i - 1]) + int.Parse(tokens[i - 2]);
                        break;
                    case "-":
                        result = int.Parse(tokens[i - 1]) - int.Parse(tokens[i - 2]);
                        break;
                    case "*":
                        result = int.Parse(tokens[i - 1]) * int.Parse(tokens[i - 2]);
                        break;
                    case "/":
                        result = int.Parse(tokens[i - 1]) / int.Parse(tokens[i - 2]);
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
            // List to store the variables
            List<string> variables = new List<string>();
            // Iterate over each token and determine if it is a variable
            foreach (string token in tokens)
            {
                if (Char.IsLetterOrDigit(token[0]))
                {
                    variables.Add(token);
                }
            }
            // Create the truth table
            int[][] truthTable = new int[(int)Math.Pow(2, variables.Count)][];
            for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++)
            {
                truthTable[i] = new int[variables.Count];
                // Generate the combinations of 1s and 0s
                for (int j = 0; j < variables.Count; j++)
                {
                    truthTable[i][j] = (i >> j) & 1;
                }
            }
            return truthTable;
        }


        // Finding a logical function
        static int InterpretExpression(string expression)
        {
            string[] tokens = ParseExpression(expression);
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
    public class LogicNode
    {
        // Character representing the value of the node
        private char value;

        // Boolean to indicate whether the node is a variable or an operator
        private bool isVariable;

        // Constructor
        public LogicNode(char value, bool isVariable)
        {
            this.value = value;
            this.isVariable = isVariable;
        }

        // Getters and setters
        public char Value { get => value; set => value = value; }
        public bool IsVariable { get => isVariable; set => isVariable = isVariable; }
    }

}
