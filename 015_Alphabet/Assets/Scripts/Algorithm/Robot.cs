using System;

namespace Alphabet
{
    class Robot
    {
        Random random = new Random();

        //метод выбора вместо игрока
        public Constants.Message_Enum GetRobotChoice()
        {
            int tempRandomValue = random.Next(0, 2);
            if (tempRandomValue == 0) // выбрали случайным образом левую букву. Возможные значение 0 и 1.
                return Constants.Message_Enum.PLAYER_CHOSE_LEFT;
            return Constants.Message_Enum.PLAYER_CHOSE_RIGHT;
        }
    }
}
