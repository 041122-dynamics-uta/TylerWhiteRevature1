using System;

namespace switchStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            int temperature = 54;
            switch (temperature)
            {
                case < 32:
                    Console.WriteLine($"The temperature is {temperature} degrees, brrrr.");
                break;
                case 32:
                    Console.WriteLine($"The temperature is {temperature} degrees, the freezing point of water.");
                break;
                case < 90:
                    Console.WriteLine($"The temerature is {temperature} degrees, a good temperature for humans.");
                break;
                default:
                    Console.WriteLine($"The temperature is {temperature}, are you sweating?");
                break;
            }
        }
    }
}
