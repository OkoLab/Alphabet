using System;
using System.Collections.Generic;
using Alphabet;

public class Phrases
{
    Random random = new Random();

    //Выбор фразы по ситуации
    public String GetPhraseBySituation(Constants.GameSituation_Enum CurentGameSituation)
    {
        int probabilitySum = 0;

        List<PhraseStruct> myPhraseStructList = new List<PhraseStruct>();
        PhraseStruct myPhraseStruct = new PhraseStruct();
        myPhraseStruct.FillPhraseList(myPhraseStructList);

        int tempRandomValue = random.Next(0, 100);

        foreach (PhraseStruct currentPhrasesStruct in myPhraseStructList)
        {//Перебираем список с фразами. Исходим из того, что вероятности фраз в списке заполнены правильно. У каждой фразы есть вероятность ее воспроизведения           
            if (currentPhrasesStruct.Get_Situation() == CurentGameSituation)
            {//Если фраза подходит для данной ситуации, то:
                probabilitySum = currentPhrasesStruct.Get_Probability() + probabilitySum;
                if(probabilitySum >= tempRandomValue)
                {
                    //возвращаем путь к текущей фразе, тк нет смысла проверять реализовалась ли ее вероятность 
                    return Constants.PHRASE_PATH + currentPhrasesStruct.Get_Name();
                }
            }
        }
        return null;
    }    
}