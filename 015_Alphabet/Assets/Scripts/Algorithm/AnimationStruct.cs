using System;
using System.Collections.Generic;

public struct AnimationStruct
{
    //private String situation;
    private Constants.GameSituation_Enum compatibleGameSituation;
    private String file_name;
    private int probability;

    //возвращает значения структуры анимаций
    public Constants.GameSituation_Enum Get_Situation() { return compatibleGameSituation; }
    public string Get_Name() { return file_name; }
    public int Get_Probability() { return probability; }

    //заполняем список структур фраз
    public void FillAnimationList(List<AnimationStruct> animationStructList)
    {
        //ситуация правильного ответа
        Set_AnimationStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "crab", 20);
        animationStructList.Add(this);
        Set_AnimationStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "delphine", 20);
        animationStructList.Add(this);
        Set_AnimationStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "fish1", 20);
        animationStructList.Add(this);
        Set_AnimationStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "killer_whale", 20);
        animationStructList.Add(this);
        Set_AnimationStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION, "octopus", 20);
        animationStructList.Add(this);
        Set_AnimationStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION, "shark", 35);
        animationStructList.Add(this);
        Set_AnimationStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION, "slope", 35);
        animationStructList.Add(this);
        Set_AnimationStruct(Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION, "turtilla", 30);
        animationStructList.Add(this);

    }

    //заполняем струтуру фразы
    public void Set_AnimationStruct(Constants.GameSituation_Enum arg1, String arg2, int arg3)
    {
        compatibleGameSituation = arg1;
        file_name = arg2;
        probability = arg3;
    }
}
