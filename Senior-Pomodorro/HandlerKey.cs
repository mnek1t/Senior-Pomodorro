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
            Console.WriteLine("Pause\nEnter 'Enter' key to continue the timer...");
            Console.ReadLine(); //sort of pause in the system 
            Console.WriteLine("Timer is resumed!");
        }
        public static void Exit()
        {
            Console.WriteLine("Exit");
        }
        public static KeyDelegate KeyHandler() // hand a pressed key
        {
            if (Console.KeyAvailable) //it's like if key is pressed 
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(intercept: true);//arg[0] - ignore output
                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    return Pause;
                }
                else if (pressedKey.Key == ConsoleKey.Escape)
                {
                    return Exit;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
