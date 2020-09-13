using System;

namespace Calculator
{
     /* Assignment 1, Calculator. Ulf Bengtsson v. Lexicon Växjö.
        Basic Console-based calculator using C#.
        Thye Hansen, triumfthye@hotmail.com
        2020-09-13 */
     
    class Calculating
    {
        double result;
        public double Addition(double numOne, double numTwo)
        {
            result = numOne + numTwo;
            return result;
        }
        
        public double Subtraction(double numOne, double numTwo)
        {
            result = numOne - numTwo;
            return result;
        }

        public double Multiplication(double numOne, double numTwo)
        {
            result = numOne * numTwo;
            return result;
        }

        public double Division(double numOne, double numTwo)
        {
            if (numTwo == 0)
            {
                Console.WriteLine(" --Division by 0 is undefined: Invalid result--");
                return result;
            }
            else
            {
                result = numOne / numTwo;
                return result;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n" + " -- Welcome to this Simple Calculator -- \n Use standart operators for " +
                    "addition, subtraction, multiplication, division. \n Please press " +
                    "the Enter key after each choise.\n");

            bool runChoise = true;

            do
            {
                Console.Write(" Proceed? (y/n): ");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "y":
                        InputHandler();
                        break;
                    case "n":
                        Console.WriteLine("\n Program terminated");
                        runChoise = false;
                        break;
                    default:
                        Console.WriteLine("\n Invalid input!\n");//To be clear to user
                        break;
                }
            } while (runChoise);
        }


        static void InputHandler()
        {
            Calculating run = new Calculating();

            double numOne, numTwo, result = 0;

            Console.Write("\n Enter first number:  ");
            numOne = NumOrNot(Console.ReadLine());
         
            Console.Write(" Enter math operator: ");
            string symbol = ValidOrNot(Console.ReadLine());

            Console.Write(" Enter second number: ");
            numTwo = NumOrNot(Console.ReadLine());

            switch (symbol)
            {
                case "+":
                    result = run.Addition(numOne, numTwo);
                    break;
                case "-":
                    result = run.Subtraction(numOne, numTwo);
                    break;
                case "*":
                    result = run.Multiplication(numOne, numTwo);
                    break;
                case "/":
                    result = run.Division(numOne, numTwo);
                    break;
            }

            result = Math.Round(result, 2);
            Console.WriteLine("\n " + numOne + " " + symbol + " " + numTwo + " = " + result + "\n");
        }

        //To be clear to user and avoid errors
        static double NumOrNot(string inNum)
        {
            if (!double.TryParse(inNum, out double outNum))
            {
                Console.WriteLine(" --Invalid input: Invalid result--");
                return outNum;
            }
            else
            {
                return outNum;
            }
        }

        //To be clear to user and avoid errors
        static string ValidOrNot(string outSym)
        {
            switch (outSym)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    return outSym;
                default:
                    Console.WriteLine(" --Invalid input: Invalid result--");
                    outSym = "0"; //Just to look nice
                    return outSym;
            }
        }
    }
}
