using System;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Senior_Pomodorro
{
    class SeniorPomodorro : Melody
    {      
        private TimeSpan timer; // Time after which you want to play the melody
        private Thread StartMelody = new Thread(Grasshoper); // for starting playing melody with displaying a MessageBox
        private TimeSpan IsCorrectInput(TimeSpan time)
        {
            if (time.Seconds >= 60)
            {
                int minutes = time.Minutes + 1;
                if (minutes >= 60)
                {
                    int hours = time.Hours + 1;
                    if (hours >= 24)
                    {
                        return new TimeSpan(24, 0, 0);
                    }
                   return new TimeSpan(time.Hours, 0, 0);
                }
                return new TimeSpan(time.Hours, minutes, 0);
            }
            else
            {
                return time;
            }
        }
        private string Printer(TimeSpan timer)
        {
            if (timer.Hours > 1)
            {
               return $"Timer is set on: {timer.Hours} hours, {timer.Minutes}minutes and {timer.Seconds} seconds\n";
            }
            else if (timer.Minutes > 1 && timer.Hours < 1)
            {
                return $"Timer is set on: {timer.Minutes} minutes and {timer.Seconds} seconds\n";
            }
            else
            {
                return $"Timer is set on: {timer.Seconds} seconds\n";
            }
        }
        public SeniorPomodorro(TimeSpan time) //Initialize timer by user input
        {
            timer = IsCorrectInput(time);
            Console.WriteLine(Printer(timer));
        }
        public void StartTimer()
        {
            Console.WriteLine("SpaceBar to pause the timer\n" +
                "Escape key to exit the programm\n" +
                "Enter to continue the timer\n");
            bool shouldDisplayMessageBox = false; 
            for (int i = 0; i <= timer.TotalSeconds; i++)
            {
                if (HandlerKey.KeyHandler().ToLower() == "pause")
                {
                    Console.WriteLine("Enter 'Enter' key to continue the timer...");
                    Console.ReadLine(); //sort of pause in the system 
                    Console.WriteLine("Timer is resumed!");
                }
                if (HandlerKey.KeyHandler().ToLower() == "exit")
                {
                    shouldDisplayMessageBox = false;
                    break;
                }
                Thread.Sleep(1000); // repeat iterarion after 1 second
                shouldDisplayMessageBox = true;
            }
            if (shouldDisplayMessageBox == true)
            {
                StartMelody.Start();
                Console.WriteLine("TIMER IS UP!!");
                DialogResult res = MessageBox.Show("Please turn off the timer", "ATTENTION");
                if (res == DialogResult.OK || res == DialogResult.Cancel)
                {
                    StartMelody.Interrupt();
                    Application.Exit();
                }
            }
        }
        
    }
}
