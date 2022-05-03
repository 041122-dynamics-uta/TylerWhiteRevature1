using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
                YOUR CODE HERE.
            **/
        }

        public static string GetName()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            return name;
        }

        public static string GreetFriend(string name)
        {
            return ($"Hello, {name}. You are my friend.");
        }

        public static double GetNumber()
        {
            double num = Convert.ToDouble(Console.ReadLine());
            return num;
        }

        public static int GetAction()
        {
            
            Console.WriteLine("Would you like to:\n+ Add [PRESS 1]\n- Subtract [PRESS 2]\n* Multiply [PRESS 3]\n/ Divide [PRESS 4]");
            int action = Convert.ToInt32(Console.ReadLine());
            
            //while (computeChoice != 1 || computeChoice != 2 || computeChoice != 3 || computeChoice != 4){
            //    Console.WriteLine("Not a valid answer. Would you like to:\n+ Add [PRESS 1]\n- Subtract [PRESS 2]\n* Multiply [PRESS 3]\n/ Divide [PRESS 4]");
            //    int computeChoice = Convert.ToInt32(Console.ReadLine());
            //}

            return action;
        }

        public static double DoAction(double x, double y, int action)
        {
            double result;
            if (action == 1){
                result = x + y;
                Console.WriteLine($"{x} + {y} = {result}");
                return result;
            }
            else if (action == 2){
                result = x - y;
                Console.WriteLine($"{x} - {y} = {result}");
                return result;
            }
            else if (action == 3){
                result = x * y;
                Console.WriteLine($"{x} * {y} = {result}");
                return result;
            }
            else if (action == 4){
                result = x / y;
                Console.WriteLine($"{x} / {y} = {result}");
                return result;
            }
            else {
                Console.WriteLine($"{action} is not a valid entry.");
                return result = 0;
            }

        }
    }
}
