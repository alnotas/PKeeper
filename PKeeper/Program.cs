using Microsoft.Win32;
using System;
using System.Windows.Forms;


namespace PKeeper
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static public RegistryKey baseKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\PKeeperV2");
      static public int PINRetries = 3;

      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new GridForm());
      }
   }
}
