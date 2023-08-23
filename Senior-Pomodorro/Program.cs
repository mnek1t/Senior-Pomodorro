namespace Senior_Pomodorro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeniorPomodorro senior = new SeniorPomodorro();
            while(true) 
            {
                if (!senior.StartTimer())
                {
                    break;
                }
            }
        }
    }
}
