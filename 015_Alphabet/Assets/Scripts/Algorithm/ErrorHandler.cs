using System;
using System.Diagnostics;

namespace Alphabet
{
    static class ErrorHandler
    {
        //string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
        //пример использования в методе GetSymbolByMessage 
        static public void LogWriter(string methodName, string inputMethodArgs, string methodResult)
        {
            Debug.WriteLine("----------------------------");
            Debug.WriteLine("Дата-время: " + DateTime.Now);
            Debug.WriteLine("Имя Метода: " + methodName);
            Debug.WriteLine("Входные параметры (название = значение): " + inputMethodArgs);
            Debug.WriteLine("Результат работы метода: " + methodResult);
            Debug.WriteLine("----------------------------");
        }

        //пример использования смотри в методе ChangeScoreDueWrongAnswer()
        static public void ErrorWriter(string methodName, string errorDescription)
        {
            Debug.WriteLine("----------------------------");
            Debug.WriteLine("Дата-время: " + DateTime.Now);
            Debug.WriteLine("Имя Метода: " + methodName);
            Debug.WriteLine("ОШИБКА: " + errorDescription);
            Debug.WriteLine("----------------------------");
        }

        static public void CloseApplication()
        {
            Environment.Exit(0);
        }
    }
}
