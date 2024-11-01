using System;
using System.Text;
using System.Windows.Forms;

namespace MsgViewerApp
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args) // Change here to accept command-line arguments
        {
            // Register code pages for encoding support (including Windows-1252)
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check if a command-line argument was passed
            if (args.Length > 0)
            {
                // Assume the first argument is the file path
                string msgFilePath = args[0];
                Application.Run(new Form1(msgFilePath)); // Pass the file path to your main form
            }
            else
            {
                Application.Run(new Form1()); // Run normally
            }
        }
    }
}
