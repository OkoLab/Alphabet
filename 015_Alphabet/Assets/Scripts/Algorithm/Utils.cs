using Alphabet;
using System;

public class Utils
{
    Random random = new Random();
       
    //�����, ������� ��������� ������������� ����������� ��� ���, ��������� ������� ��������    
    public bool IsProbabilityCome(int argProbability)
    {
        //��������� ������������ �������� �����������. ��� ������ ���� ������ ��� ����� ���� � ������ ��� ����� ���.  
        if ( (0 <= argProbability) && (argProbability <= 100) )
        {// �� ���� ������ ������� ������� � ������������ 0 ������� �� ����������
            if (argProbability == 0)
            {
                return false;
            }
            if (argProbability == 100)
            {// �� ���� ������ ������� ������� � ������������ 100 ������ ����������
                return true;
            }

            //�������� ������� ��� ��������� �����
            int tempRandomValue = random.Next(0, 100);

            if ( (tempRandomValue + 1) <= argProbability) // +1, �� ��������� ����� ������������ � ��������� �� 0 �� 99, � �� �� 1 �� 100
                return true;
            else
                return false;
        }
        else
        {
            //�����  ���������� ��� � ����/ ����� � �������� argProbability
            ErrorHandler.ErrorWriter(System.Reflection.MethodInfo.GetCurrentMethod().Name, "�������� ����������� ������ ���� ������ ��� ����� ���� � ������ ��� ����� ���." + " argProbability = " + argProbability);
        }
        return false;
    }
}
