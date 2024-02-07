using System.Collections.Generic;
using System;

namespace Program
{
    public class Operation
    {
        public double num1 { get; set; }
        public double num2 { get; set; }
        public string operation { get; set; }
        public double result { get; set; }
        public bool choice { get; set; }
        public bool continueChoice { get; set; }

        public Operation()
        {
            num1 = 0;
            num2 = 0;
            operation = "";
            result = 0;
            choice = true;
            continueChoice = false;
        }

        public void SetToEmpty()
        {
            num1 = 0;
            num2 = 0;
            operation = "";
            result = 0;
        }

        public void SetToContinue()
        {
            num1 = result;
            num2 = 0;
            operation = "";
            result = 0;
        }

        public void Add(double num1, double num2)
        {
            result = Math.Round(num1 + num2, 2);
            Console.WriteLine("The result is: " + result);
        }

        public void Subtract(double num1, double num2)
        {
            result = Math.Round(num1 - num2, 2);
            Console.WriteLine("The result is: " + result);
        }

        public void Multiply(double num1, double num2)
        {
            result = Math.Round(num1 * num2, 2);
            Console.WriteLine("The result is: " + result);
        }

        public void Divide(double num1, double num2)
        {
            result = Math.Round(num1 / num2, 2);
            Console.WriteLine("The result is: " + result);
        }

        public void Continue()
        {
            Console.WriteLine("Do you want to continue? (Y/N)");
            string choice = Console.ReadLine();
            if (choice.ToUpper() == "Y")
            {
                this.choice = true;
            }
            else if (choice.ToUpper() == "N")
            {
                this.choice = false;
            }
            else
            {
                Console.WriteLine("Invalid choice");
                Continue();
            }
        }

        public void ContinueResult()
        {
            Console.WriteLine("Do you want to continue with the result? (Y/N)");
            string choice = Console.ReadLine();
            if (choice.ToUpper() == "Y")
            {
                this.continueChoice = true;
            }
            else if (choice.ToUpper() == "N")
            {
                this.continueChoice = false;
            }
            else
            {
                Console.WriteLine("Invalid choice");
                ContinueResult();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Operation op = new Operation();
            DisplayMenu(op);
        }

        private static void DisplayMenu(Operation op)
        {
            while (op.choice)
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO THE C# CALCULATOR");
                Console.WriteLine("----------------------------");
                if (op.num1 == 0 && op.continueChoice == false)
                {
                    try
                    {
                        Console.WriteLine("Enter the first number: ");
                        op.num1 = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        op.SetToEmpty();
                        DisplayMenu(op);
                    }
                }
                else
                {
                    Console.WriteLine("Your first number is: " + op.num1);
                }

                try
                {
                    Console.WriteLine("Enter the second number: ");
                    op.num2 = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    op.SetToEmpty();
                    DisplayMenu(op);
                }

                try
                {
                    Console.WriteLine("Enter the operation: ");
                    op.operation = Console.ReadLine();

                    CheckOperation(op);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }

                op.Continue();
                if (op.choice == false) break;
                op.ContinueResult();

                if (op.continueChoice)
                {
                    op.SetToContinue();
                }
                else
                {
                    op.SetToEmpty();
                }
            }
        }

        private static void CheckOperation(Operation op)
        {
            switch (op.operation)
            {
                case "+":
                    op.Add(op.num1, op.num2);
                    break;
                case "-":
                    op.Subtract(op.num1, op.num2);
                    break;
                case "*":
                    op.Multiply(op.num1, op.num2);
                    break;
                case "/":
                    op.Divide(op.num1, op.num2);
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    op.SetToEmpty();
                    DisplayMenu(op);
                    break;
            }
        }
    }
}