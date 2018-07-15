using System;
using Microsoft.Win32;

namespace Focus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (IsWin10())
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
            }

            var focus = new FocusGame();
            focus.Start();
        }

        private static bool IsWin10()
        {
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            using(RegistryKey regKey=Registry.LocalMachine.OpenSubKey(key))
            {
                if (regKey != null)
                {
                    try
                    {
                        return regKey.GetValue("ProductName").ToString().Contains("10");
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }

                return false;
            }
        }
    }
}