using System;

namespace Senior_Pomodorro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = new string[3];
            Console.WriteLine("Set time for a timer:");
            Console.Write("Hours: ");
            args[0] = Console.ReadLine();
            bool isValidInput = Int32.TryParse(args[0],out int hours );
            if (isValidInput)
            {
                Console.Write("Minutes: ");
                args[1] = Console.ReadLine();
                isValidInput = Int32.TryParse(args[1], out int minutes);
                if (isValidInput)
                {
                    Console.Write("Seconds: ");
                    args[2] = Console.ReadLine();
                    isValidInput = Int32.TryParse(args[2], out int seconds);
                    if (isValidInput)
                    {
                        TimeSpan time = new TimeSpan(hours, minutes, seconds);
                        SeniorPomodorro timer = new SeniorPomodorro(time);
                        timer.StartTimer();
                    }
                }
            }
            else
            {
                throw new Exception("Error Input! Please enter only integer numbers");
            }
            
        }
    }
}
