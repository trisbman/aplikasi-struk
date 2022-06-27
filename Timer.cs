using System;
using System.Timers;

namespace aplikasi_struk
{
    class Timer
    {
        private string Msg;
        private System.Timers.Timer aTimer;
        private int Duration;
        private int YPos;

        public Timer(string msg, int duration)
        {
            Msg = msg;
            Duration = duration;
            YPos = Console.GetCursorPosition().Top;
        }
        public void Start()
        {
            Console.Write(Msg + " " + Duration + "...");
            SetTimer();
        }
        private void SetTimer()
        {
            // Create a timer with a second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (Duration == 0) Environment.Exit(0);
            Duration -= 1;
            Console.SetCursorPosition(0, YPos);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, YPos);
            Console.WriteLine(Msg + " " + Duration + "...");
        }
    }
}
