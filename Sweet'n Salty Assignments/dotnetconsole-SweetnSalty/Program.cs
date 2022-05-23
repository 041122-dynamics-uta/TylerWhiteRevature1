using System;

namespace dotnetconsole_SweetnSalty
{
    class Program
    {
        static void Main(string[] args)
        {
            //Counter variables to keep track of occurences
            int swtTotal = 0;
            int sltTotal = 0;
            int swsTotal = 0;

            //Get start number
            Console.WriteLine("What is the start number?");
            int startNum = Int32.Parse(Console.ReadLine());

            //Get stop number
            Console.WriteLine("What is the stop number?");
            int stopNum = Int32.Parse(Console.ReadLine());

            //Get how many numbers per line
            Console.WriteLine("How many numbers would you like printed per line?");
            int numPerLine = Int32.Parse(Console.ReadLine());

            Console.WriteLine();

            //Loops through the numbers (range) and counts the required occurences and prints them to the screen in place of a number
            for (int x = startNum; x <= stopNum; x++)
            {
                //If the number is divisible by 5 AND 3, then it's Sweet'n Salty!
                if (x % 5 == 0 && x % 3 == 0)
                {
                    Console.Write("Sweet'n Salty ");
                    swsTotal++;
                }
                //Else if the number is divisible by 3, then it's Sweet.
                else if (x % 3 == 0)
                {
                    Console.Write("Sweet ");
                    swtTotal++;
                }
                //Else if the number is divisible by 5, then it's Salty
                else if (x % 5 == 0)
                {
                    Console.Write("Salty ");
                    sltTotal++;
                }
                //Else just print the sad number
                else
                {
                    Console.Write($"{x} ");
                }
                
                //This if returns after their numbers per line is hit 
                if (x % numPerLine == 0)
                {
                    Console.WriteLine();
                }
            }

            //Print the totals
            Console.WriteLine($"\nYou are Sweet {swtTotal} times.");
            Console.WriteLine($"You are Salty {sltTotal} times.");
            Console.WriteLine($"You are Sweet'n Salty {swsTotal} times.");
        }
    }
}
