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
                    Console.WriteLine($"The temperature is {temperature}, is it snowing?")
                break;
                case > 32:
                    Console.WriteLine($"The temperature is {temperature}, still need a jacket.");
                break;
                default:
                    Console.WriteLine($"The temperature is {temperature}, death.");
                break;
            }
        }
    }
}
