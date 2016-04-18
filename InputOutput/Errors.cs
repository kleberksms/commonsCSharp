using System;
using System.Globalization;
using System.IO;

namespace InputOutput
{
    public class Errors
    {
        public static void WriteErrorFile(Exception exception, string pathFile)
        {
            using (var writer = new StreamWriter(pathFile, true))
            {
                writer.WriteLine("Message :{0}<br/>{1}StackTrace :{2}{1}Date :{3}", exception.Message, Environment.NewLine, exception.StackTrace, DateTime.Now.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}
