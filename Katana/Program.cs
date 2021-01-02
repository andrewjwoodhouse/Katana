using System;
using System.Windows.Forms;

namespace Katana
{

    internal static class KatanaForm
    {
        internal static Form2 form2;
        internal static Form1 form1;
        internal static Form3 form3;
    }

    static class Program
    {
        public static Form1 form1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form1 = new Form1());


        }
        

    }
}
