using System.Runtime.InteropServices;

namespace SpotiSync
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AllocConsole();
            
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}