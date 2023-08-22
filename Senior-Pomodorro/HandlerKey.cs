using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Senior_Pomodorro
{
    delegate void KeyDelegate();
    static class HandlerKey
    {
        public static void Pause()
        {
            Console.WriteLine("Enter 'Enter' key to continue the timer...");
            Console.ReadLine(); //sort of pause in the system 
            Console.WriteLine("Timer is resumed!");
        }
        public static void Exit()
        {

        }
        public static void Continue()
        {

        }
        public static KeyDelegate KeyHandler() // hand a pressed key
        {
            if (Console.KeyAvailable) 
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("Pause");
                    return Pause;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return Exit;
                }
                else
                {
                    return Continue;
                }
            }
            return Continue;
        }
    }
}
