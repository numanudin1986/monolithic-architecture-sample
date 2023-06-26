
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AgentApp;
using AgentApp.DataAccess.Interfaces;
using AgentApp.DataAccess.Repositories;
using AgentApp.DataAccess.Entity;
using Microsoft.Extensions.Options;
using static AgentApp.Components.Enumerations.Enumeration;

namespace AgentApp.Components.Helpers
{
   
    public static class LogHelper
    {

        static string LogFilePath = string.Empty;
        static string fileName = string.Empty;
        static LogHelper()
        {
            //LogFilePath = ConfigurationHelper.LogDirectory + "log.txt";
            //CreateFile(ConfigurationHelper.LogDirectory, LogFilePath);
        }

    

        public static void WriteExceptionLog(Exception ex)
        {
           
            try
            {
                new Thread(delegate ()
                {
                    StackTrace stackTrace = new StackTrace(ex, true);
                    var frame = stackTrace.GetFrames().LastOrDefault();

                    string methodName = frame != null ? frame.GetMethod().Name : "Unknown";
                    int lineNumber = frame != null ? frame.GetFileLineNumber() : -1;
                    fileName = frame != null ? frame.GetFileName() : "Unknown";
                    string innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "null";
                    string exceptionMessage = ex.Message;
                    TblLogging log = new TblLogging()
                    {
                        Type = Convert.ToString((int)LogType.Exception),
                        ExceptionMessage = exceptionMessage,
                        InnerExceptionMessage = innerExceptionMessage,
                        FileName = fileName,
                        LineNumber = Convert.ToString(lineNumber),
                        MehtodName = methodName,
                        CreatedDate = DateTime.UtcNow
                    };
                    

                }).Start();

            }
            catch (Exception exception)
            {

            }

        }



        private static void WriteDebugLogInFile(string message)
        {
            try
            {
                //using (IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationHelper.RAKConnectionString))
                //{
                //    Log log = new Log()
                //    {
                //        LogType = LogType.Debug,
                //        DebugLogMessage = message,
                //    };
                //    unitOfWork.LogRepository.Insert(log);
                //}
            }
            catch (Exception)
            {

            }
        }

        private static void WriteExceptionLogInFile(Exception ex)
        {
            try
            {


                StackTrace stackTrace = new StackTrace(ex, true);
                var frame = stackTrace.GetFrames().LastOrDefault();

                string methodName = frame != null ? frame.GetMethod().Name : "Unknown";
                int lineNumber = frame != null ? frame.GetFileLineNumber() : -1;
                fileName = frame != null ? frame.GetFileName() : "Unknown";
                string innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "null";
                string exceptionMessage = ex.Message;

                using (StreamWriter writetext = new StreamWriter(LogFilePath, true))
                {
                    string exceptionLog = string.Format("{0}, Exception \t Filename: {1} \t Method Name: {2} \t Line Number: {3} \t Inner Exception Message: {4} \t Exception Message: {5}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), fileName, methodName, lineNumber, innerExceptionMessage, exceptionMessage);
                    writetext.WriteLine(exceptionLog);
                }

            }
            catch (Exception)
            {

            }

        }

        private static bool CreateFile(string logDirectory, string logFilePath)
        {

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(@logDirectory);
            }

            if (!File.Exists(logFilePath))
            {
                FileStream file = File.Create(@logFilePath);
                file.Close();
                return true;
            }

            return false;
        }

    }
}
