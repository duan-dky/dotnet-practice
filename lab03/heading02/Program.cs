namespace WinFormsApp2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// [STAThread]
        public class Timer1
        {
            static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
            static int alarmCounter = 1;
            static bool exitFlag = false;

            private static void TimerEventProcessor(Object myObject,
                                                    EventArgs myEventArgs)
            {
                myTimer.Stop();

                // Displays a message box asking whether to continue running the timer.
                MessageBox.Show("请及时提交信息！", "提示", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                alarmCounter += 1;
                myTimer.Enabled = true;
            }
            public void CallToChildThread()
            {
                /* Adds the event and the event handler for the method that will 
                   process the timer event to the timer. */
                myTimer.Tick += new EventHandler(TimerEventProcessor);

                // Sets the timer interval to 5 seconds.
                myTimer.Interval = 180000;
                myTimer.Start();

                // Runs the timer, and raises the event.
                while (exitFlag == false)
                {
                    // Processes all the events in the queue.
                    Application.DoEvents();
                }
            }
        }
            static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Timer1 timer1 = new Timer1();
            ThreadStart childref = new ThreadStart(timer1.CallToChildThread);
            Thread childThread = new Thread(childref);
            childThread.Start();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}