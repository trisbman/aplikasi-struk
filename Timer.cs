using System;
using System.Timers;

namespace aplikasi_struk
{
    class Timer
    {
        private System.Timers.Timer aTimer;

        public void Start()
        {
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
            Console.WriteLine("{0:HH:mm:ss}", e.SignalTime);
        }
    }
}
