using System;
using System.Collections.Generic;

namespace Alphabet
{
    //структура фраз. Медиа - это аудио фраза или анимация 
    public struct PhraseStruct
    {
        //private String situation;
        private Constants.GameSituation_Enum compatibleGameSituation;
        private String file_name;
        private int probability;

        //возвращает значения структуры фразы
        public Constants.GameSituation_Enum Get_Situation() { return compatibleGameSituation; }
        public String Get_Name() { return file_name; }
        public int Get_Probability() { return probability; }

        //заполняем список структур фраз
        public void FillPhraseList(List<PhraseStruct> phrasesStructList)
        {
            //ситуация запуска приложения
            Set_PhraseStruct(Constants.GameSituation_Enum.GAME_START_SITUATION, "hello_1", 30);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.GAME_START_SITUATION, "hello_2", 30);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.GAME_START_SITUATION, "lets_learn_the_letters", 20);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.GAME_START_SITUATION, "lets_learn_the_sounds", 20);
            phrasesStructList.Add(this);


            //ситуация неправильного ответа
            Set_PhraseStruct(Constants.GameSituation_Enum.WRONG_ANSWER_SITUATION, "you_will_definitely_succeed", 50);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.WRONG_ANSWER_SITUATION, "try_again", 50);
            phrasesStructList.Add(this);

            //ситуация правильного ответа        
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "you_are_smart", 20);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "you_can_do_even_better", 15);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "well_done", 20);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "well_done_you_are_good_at_it", 15); 
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "great", 15);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "cool", 15);
            phrasesStructList.Add(this);

            //ситуация угадана сложная буква
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION, "cheers_you_did_it", 35);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION, "you_did_it", 30);
            phrasesStructList.Add(this);
            Set_PhraseStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION, "you_never_give_up", 35);
            phrasesStructList.Add(this);
        }

        //заполняем струтуру фразы
        public void Set_PhraseStruct(Constants.GameSituation_Enum arg1, String arg2, int arg3)
        {
            compatibleGameSituation = arg1;
            file_name = arg2;
            probability = arg3;
        }
    }
}
