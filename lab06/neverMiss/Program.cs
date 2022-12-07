using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace neverMiss
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public class Timer1
        {
            static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
            static int alarmCounter = 1;
            static bool exitFlag = false;
            private static void TimerEventProcessor(Object myObject,
                                                    EventArgs myEventArgs)
            {
                myTimer.Stop();
                alarmCounter += 1;
                myTimer.Enabled = true;
            }
            public void CallToChildThread()
            {
                ///* Adds the event and the event handler for the method that will 
                //   process the timer event to the timer. */
                //myTimer.Tick += new EventHandler(TimerEventProcessor);

                //// Sets the timer interval to 60 seconds.
                //myTimer.Interval = 10000;
                //myTimer.Start();

                //// Runs the timer, and raises the event.
                //while (exitFlag == false)
                //{
                //    // Processes all the events in the queue.
                //    Application.DoEvents();
                //}
                for(; ; )
                {   
                    Thread.Sleep(60000);
                    timer timer = new timer();
                    int sum = timer.getSum();
                    reminder[] reminder = new reminder[sum];
                    for (int i = 0; i < sum; i++)
                    {
                        reminder[i] = new reminder();
                    }
                    timer.QueryTimer(DateTime.Now.ToString("yyyy/MM/d HH:mm"), reminder);
                    reminder = null;
                }
            }
        }
        [STAThread]
        static void Main()
        {
            bool createdNew;
            Mutex mutex = new Mutex(true, "neverMiss", out createdNew);
            if (createdNew)
            {
                Timer1 timer1 = new Timer1();
                ThreadStart childref = new ThreadStart(timer1.CallToChildThread);
                Thread childThread = new Thread(childref);
                childThread.Start();
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("程序已经在运行！");
            }
        }
    }
}
