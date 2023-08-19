using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Pomodorro
{
    static class HandlerKey
    {
        public static string KeyHandler() // hand a pressed key
        {
            if (Console.KeyAvailable == true) //keystroke is available
            {
                switch (Console.ReadKey(intercept: true).Key)
                {
                    case ConsoleKey.Spacebar:
                        {
                            Console.WriteLine("Pause");
                            return "Pause";
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.WriteLine("Exit");
                            return "Exit";
                        }
                    case ConsoleKey.Enter:
                        {
                            return "Continue";
                        }
                    default:
                        return " ";
                }
            }
            return " ";
        }
    }
}
