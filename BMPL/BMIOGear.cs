using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPL
{
    class BMIOGear
    {
        //Описание Api для запуска
        public class WinBmApi
        {
            public string WBAname;
            public string WBApath;
            public string WBAargs;
            public string WBAdesc;
        } 
        
        
        //DTO ответов от системы Windows
        public class WinStdOut
        {
            public int          ExitCode;
            public string       Stdoutx;
            public string       Stderrx;
            public Exception    Stdexcep;

            public WinStdOut(int p)
            {
                this.ExitCode = p;
            }

            public WinStdOut(Exception e)
            {
                this.Stdexcep = e;
            }

            public WinStdOut(int p, string s1, string s2)
            {
                this.ExitCode = p;
                this.Stdoutx = s1;
                this.Stderrx = s2;
            }
        }

        //Алиас запуска API
        public static WinStdOut ExecuteApi(WinBmApi wba)
        {
            return executeApi(wba);
        }

        private static WinStdOut executeApi(WinBmApi wba)
        {
            //Описание процесса запуска API
            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = wba.WBApath;
            process.StartInfo.Arguments = wba.WBAargs;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            //Запуск процесса и чтение буферов
            try
            {
                process.Start();

                string stdoutx = process.StandardOutput.ReadToEnd();
                string stderrx = process.StandardError.ReadToEnd();

                process.WaitForExit();

                return new WinStdOut(process.ExitCode,stdoutx,stderrx);
            }
            catch (Exception ex)
            {
                return new WinStdOut(ex);
            }
        }


    }
}
