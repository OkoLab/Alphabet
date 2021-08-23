using Alphabet;
using System;

public class Utils
{
    Random random = new Random();
       
    //метод, который проверяет реализовалась вероятность или нет, проверяет входной параметр    
    public bool IsProbabilityCome(int argProbability)
    {
        //Проверяем допустимость значения вероятности. Оно должно быть больше или равно нулю и меньше или равно ста.  
        if ( (0 <= argProbability) && (argProbability <= 100) )
        {// не надо ничего считать событие с вероятностью 0 никогда не произойдет
            if (argProbability == 0)
            {
                return false;
            }
            if (argProbability == 100)
            {// не надо ничего считать событие с вероятностью 100 всегда свершается
                return true;
            }

            //Создание объекта для генерации чисел
            int tempRandomValue = random.Next(0, 100);

            if ( (tempRandomValue + 1) <= argProbability) // +1, тк случайное число генерируется в диапазоне от 0 до 99, а не от 1 до 100
                return true;
            else
                return false;
        }
        else
        {
            //нужно  записывать еще и дату/ время и значение argProbability
            ErrorHandler.ErrorWriter(System.Reflection.MethodInfo.GetCurrentMethod().Name, "значении вероятности должно быть больше или равно нулю и меньше или равно ста." + " argProbability = " + argProbability);
        }
        return false;
    }
}
