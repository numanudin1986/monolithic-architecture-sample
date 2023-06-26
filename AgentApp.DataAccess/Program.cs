using System;
using System.Configuration;
using System.Globalization;
namespace AgentApp.DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            // string Name = ConfigurationManager.ConnectionStrings["AgentAppDatabase"].ConnectionString;
            DateTime d = DateTime.Now;
            Console.WriteLine(d.ToString("MMMM"));
            Console.WriteLine("Hello World!");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i]);
            }
        }
    }
}
