using System;
using System.Threading;
using System.Windows.Forms;

namespace Senior_Pomodorro
{
    class SeniorPomodorro 
    {
        private class Melody
        {
            public static void Grasshoper()
            {
                Console.Beep(440, 300);
                Console.Beep(330, 300);
                Console.Beep(440, 300);
                Console.Beep(330, 300);
                Console.Beep(440, 300);
                Console.Beep(415, 300);
                Console.Beep(415, 300);
                Thread.Sleep(600);
                Console.Beep(415, 300);
                Console.Beep(330, 300);
                Console.Beep(415, 300);
                Console.Beep(330, 300);
                Console.Beep(415, 300);
                Console.Beep(440, 300);
                Console.Beep(440, 300);
                Thread.Sleep(600);
                Console.Beep(440, 300);
                Console.Beep(494, 300);
                Console.Beep(494, 100);
                Console.Beep(494, 100);
                Console.Beep(494, 300);
                Console.Beep(494, 300);
                Console.Beep(523, 300);
                Console.Beep(523, 100);
                Console.Beep(523, 100);
                Console.Beep(523, 300);
                Console.Beep(523, 300);
                Console.Beep(523, 300);
                Console.Beep(494, 300);
                Console.Beep(440, 300);
                Console.Beep(415, 300);
                Console.Beep(440, 800);
            }
        } // here I save melody
        private KeyDelegate getKey;
        private readonly TimeSpan timer = new TimeSpan(0,0,3); // Time after which you want to play the melody
        public bool StartTimer()
        {
            Console.WriteLine($"TIMER IS STARTED AND SET ON {timer.TotalSeconds} seconds\n\nPress:\nSpaceBar to pause the timer\nEscape key to exit the programm\n");
            bool shouldDisplayMessageBox = false;
            DialogResult res; // create dialog window
            for (int i = 0; i <= timer.TotalSeconds; i++)
            {
                getKey = HandlerKey.KeyHandler();
                getKey?.Invoke();
                if (getKey == HandlerKey.Exit)
                {
                    shouldDisplayMessageBox = false;
                    return false;
                }                
                Thread.Sleep(1000); // repeat iterarion after 1 second
                shouldDisplayMessageBox = true;
            }
            if (shouldDisplayMessageBox == true) //if user dont press key or cycle is over
            {
                Console.WriteLine("TIMER IS UP!!");
                Thread thread = new Thread(Melody.Grasshoper) { IsBackground = true};
                thread.Start();
                //Melody.Grasshoper();
                res = MessageBox.Show("Please turn off the timer", "TIMER IS UP!!"); //display messageBox
                if (res == DialogResult.OK || res == DialogResult.Cancel)
                {
                    Application.Exit(); // close MessageBox
                    return false;
                }
                return false;
            }
            return true;
        } 
        
    }
}
