using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Animation
{
    Random random = new Random();
    public String GetAnimationBySituation(Constants.GameSituation_Enum CurentGameSituation)
    {
        int probabilitySum = 0;

        List<AnimationStruct> myAnimationStructList = new List<AnimationStruct>();
        AnimationStruct myAnimationStruct = new AnimationStruct();
        myAnimationStruct.FillAnimationList(myAnimationStructList);

        int tempRandomValue = random.Next(0, 100);

        foreach (AnimationStruct currentAnimationStruct in myAnimationStructList)
        {//Перебираем список с фразами. Исходим из того, что вероятности фраз в списке заполнены правильно. У каждой фразы есть вероятность ее воспроизведения
            if (currentAnimationStruct.Get_Situation() == CurentGameSituation)
            {//Если фраза подходит для данной ситуации, то:
                probabilitySum = currentAnimationStruct.Get_Probability() + probabilitySum;
                if (probabilitySum >= tempRandomValue)
                {
                    //возвращаем путь к текущей фразе, тк нет смысла проверять реализовалась ли ее вероятность 
                    return Constants.ANIMATION_PATH + currentAnimationStruct.Get_Name();
                }
            }
        }

        //Debug.WriteLine(DateTime.Now + "ОШИБКА: Вероятность никакой фразы не реализовалась. Метод: GetPhraseBySituation Дата:");
        return null;
    }
}
