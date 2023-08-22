using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KillProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HideApplication();
            KillProcess();
        }

        static void KillProcess()
        {
            while (true)
            {
                Process.GetProcesses().ToList().ForEach(process =>
                {
                    if (process.ProcessName.Equals("FTK Imager"))
                    {
                        process.Kill();
                    }
                });
            }
        }
        static void HideApplication()
        {
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(handle, 0);
        }
    }
}