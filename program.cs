using System;
using System.Windows.Forms;
using UniversalByteRemover;

namespace 万能字节移除器
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ByteRemover());
        }
    }
}