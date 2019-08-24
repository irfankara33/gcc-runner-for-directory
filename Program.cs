using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace run_gcc_compiler_for_directory
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("correct usage is:./runner folder1 folder2 folderN");
                Environment.Exit(1);
            }
            foreach(var fname in args)
            {
                foreach (var q in Directory.GetFiles(fname, "*.c"))
                {
                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.WorkingDirectory = Environment.CurrentDirectory;
                    ps.RedirectStandardInput = false;
                    ps.UseShellExecute = false;
                    ps.CreateNoWindow = true;
                    ps.RedirectStandardOutput = false;
                    ps.RedirectStandardError = false;
                    ps.FileName = "gcc.exe";
                    ps.Arguments = "\"" + q + "\" -o \"" + q + ".exe\"";//eger kaynak kod dosyası boşluk karakteri içeriyorsa diye dosya ismini "" arasına aldırdım.
                    Process prs = new Process();
                    prs.StartInfo = ps;
                    prs.Start();
                }
            }
        }
    }
}
