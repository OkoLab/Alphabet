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
        {//���������� ������ � �������. ������� �� ����, ��� ����������� ���� � ������ ��������� ���������. � ������ ����� ���� ����������� �� ���������������
            if (currentAnimationStruct.Get_Situation() == CurentGameSituation)
            {//���� ����� �������� ��� ������ ��������, ��:
                probabilitySum = currentAnimationStruct.Get_Probability() + probabilitySum;
                if (probabilitySum >= tempRandomValue)
                {
                    //���������� ���� � ������� �����, �� ��� ������ ��������� ������������� �� �� ����������� 
                    return Constants.ANIMATION_PATH + currentAnimationStruct.Get_Name();
                }
            }
        }

        //Debug.WriteLine(DateTime.Now + "������: ����������� ������� ����� �� �������������. �����: GetPhraseBySituation ����:");
        return null;
    }
}
