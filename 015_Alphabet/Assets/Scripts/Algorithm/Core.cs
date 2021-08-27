using Alphabet;
using System;

public class Core
{
    //текущая игровая ситуация
    protected Constants.GameSituation_Enum situation;

    //ход робота?
    protected bool isAI;

    //символ для изучения
    protected Char symbolToStudy;

    //расшифрованный ответ игрока
    protected Char symbolFromPlayer;

    //неверный символ
    protected Char symbolForComparison;
    
    //путь к файлу со звуком символа
    protected String pathToSoundFileSymbolToStudy;
    
    //символ в левом кольце
    protected Char leftSymbol;

    //символ в правом кольце
    protected Char rightSymbol;

    //баллы изучаемого символа
    protected int symbolPoint;

    // генератор случайных чисел для всех методов класса
    Random rand = new Random();

    //структура массива символов
    SymbolsSet symbolsSet = new SymbolsSet();

    public Core()
    {
        symbolsSet.FillSymbolsSet(SaveManager.Load());
        symbolsSet.SetCountCommonPoint();
    }

    //сбрасываем сохраненные баллы 
    public void ReloadCore()
    {
        symbolsSet.FillSymbolsSet(null);
        symbolsSet.SetCountCommonPoint();
        Save();
    }
    
    public string GetSymbolToStudy()
    {
        return symbolToStudy.ToString();
    }
    
    public string GetLeftSymbol()
    {
        return leftSymbol.ToString();
    }
    public string GetRightSymbol()
    {
        return rightSymbol.ToString();
    }
    public string GetSymbolSound()
    {
        return pathToSoundFileSymbolToStudy;
    }

    public int GetSymbolPoint()
    {
        return symbolPoint;
    }

    public Constants.GameSituation_Enum GetSituation()
    {
        return situation;
    }

    public bool SetIsAI(bool flag)
    {
        return isAI = flag;
    }

    public bool GetIsAI()
    {
        return isAI;
    }

    protected void SymbolFromPlayer(Constants.Message_Enum inputMessage)
    {
        if ((inputMessage == Constants.Message_Enum.PLAYER_CHOSE_LEFT) || (inputMessage == Constants.Message_Enum.AL_CHOICE_LEFT))
        {
            symbolFromPlayer = leftSymbol;
        }
        if ((inputMessage == Constants.Message_Enum.PLAYER_CHOSE_RIGHT) || (inputMessage == Constants.Message_Enum.AL_CHOICE_RIGHT))
        {
            symbolFromPlayer = rightSymbol;
        }

        if ((inputMessage == Constants.Message_Enum.AL_CHOICE_RIGHT) || (inputMessage == Constants.Message_Enum.AL_CHOICE_LEFT))
            SetIsAI(true);
        else
            SetIsAI(false);
    }

    //проверка верности ответа игрока. Результат меняет значение переменной класса mSituation
    protected void MakeValidation()
    {
        if (symbolFromPlayer == symbolToStudy)
        {
            situation = Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION;
        }
        else if (symbolFromPlayer == symbolForComparison)
        {
            situation = Constants.GameSituation_Enum.WRONG_ANSWER_SITUATION;
        }
        else
        {
            ErrorHandler.ErrorWriter(System.Reflection.MethodInfo.GetCurrentMethod().Name, "ответ игрока отличается от левого и правого символа");
            //закрываем программу
            ErrorHandler.CloseApplication();
        }
    }

    //Метод изменения числа баллов при правильном ответе
    protected void ChangeScoreDueCorrectAnswer()
    {
        int tempScore = 0;
        
        try
        {
            Symbol temp_symbol = symbolsSet.symbols_list.Find(item => item.symbol_name == symbolToStudy);
            tempScore = temp_symbol.pointCounter - Constants.SYMBOL_SCORE_STEP_IF_RIGHT;
            if (tempScore < Constants.SYMBOL_MINIMUM_SCORE)
            {
                temp_symbol.pointCounter = Constants.SYMBOL_MINIMUM_SCORE;
            }
            else
            {
                temp_symbol.pointCounter = tempScore;
            }

            //меняем с списке элемент symbol на элемент с новым количеством баллов 
            int index = symbolsSet.symbols_list.FindIndex(item => item.symbol_name == symbolToStudy);
            symbolsSet.symbols_list[index] = temp_symbol;
        }
        catch
        {
            ErrorHandler.ErrorWriter(System.Reflection.MethodInfo.GetCurrentMethod().Name, "отсутствует символ для изучения");
            //закрываем программу
            ErrorHandler.CloseApplication();
        }
    }

    //Метод изменения числа баллов при неправильном ответе
    protected void ChangeScoreDueWrongAnswer()
    {
        int tempScore = 0;

        try
        {
            Symbol temp_symbol = symbolsSet.symbols_list.Find(item => item.symbol_name == symbolToStudy);
            tempScore = temp_symbol.pointCounter + Constants.SYMBOL_SCORE_STEP_IF_FAULT;
            if (tempScore > Constants.SYMBOL_MAXIMUM_SCORE)
            {
                temp_symbol.pointCounter = Constants.SYMBOL_MAXIMUM_SCORE;
            }
            else
            {
                temp_symbol.pointCounter = tempScore;
            }

            //меняем с списке элемент symbol на элемент с новым количеством баллов 
            int index = symbolsSet.symbols_list.FindIndex(item => item.symbol_name == symbolToStudy);
            symbolsSet.symbols_list[index] = temp_symbol;
        }
        catch
        {
            ErrorHandler.ErrorWriter(System.Reflection.MethodInfo.GetCurrentMethod().Name, "отсутствует символ для изучения");           
            //закрываем программу
            ErrorHandler.CloseApplication();
        }
    }

    //Выбор символа для обучения. Результат в symbolToStudy и pathToSoundFileSymbolToStudy
    protected bool СhoosingSymbol()
    {
        //программист, убедись, что commonPointCounter у тебя актуальный!!!
        int count = symbolsSet.GetcommonPointCounter();
        int randomPointNumber = rand.Next(count + 1);
        int currentPointNumber = 0;
        foreach (var temp_symbol in symbolsSet.symbols_list)
        {
            currentPointNumber += temp_symbol.pointCounter;
            if (currentPointNumber >= randomPointNumber)
            {
                symbolToStudy = temp_symbol.symbol_name;
                pathToSoundFileSymbolToStudy = temp_symbol.path;
                symbolPoint = temp_symbol.pointCounter;
                return true;
            }
        }
        //ошибка не смогли выбрать символ
        //закрываем
        ErrorHandler.CloseApplication();

        return false;
    }

    public void Save()
    {
        SaveSymbolsList savedList = new SaveSymbolsList();
        savedList.SetSymbolsList(symbolsSet.symbols_list);
        SaveManager.Save(savedList.GetSymbolsList());
    }

    //Выбор парного символа
    protected void СhoosingComparisonSymbol()
    {
        //число элементов в массиве с символами
        int N = symbolsSet.symbols_list.Count;

        //Генерируем случайное число S в диапазоне от 0 - первый символ в алфавите, до N-1
        int S = rand.Next(0, N); // случайное число в диапазоне от 0 до N-1
        if (symbolsSet.symbols_list[S].symbol_name == symbolToStudy)
        {
            if ((S - 1) >= 0)
            {   // проверяем, что не вылезли за пределы массива вниз
                symbolForComparison = symbolsSet.symbols_list[S - 1].symbol_name;
            }
            else
            {
                if ((S + 1) < N)
                {   // проверяем, что не вылезли за пределы массива вверх
                    symbolForComparison = symbolsSet.symbols_list[S + 1].symbol_name;
                }
            }
        }
        else
        {
            symbolForComparison = symbolsSet.symbols_list[S].symbol_name;
        }
    }

    //Возвращает код выбранного игроком/ компом символа
    protected Char GetSymbolByMessage(Constants.Message_Enum arg1)
    {
        if ((arg1 == Constants.Message_Enum.PLAYER_CHOSE_LEFT) || (arg1 == Constants.Message_Enum.AL_CHOICE_LEFT))
        {
            //пример использования
            ErrorHandler.LogWriter(System.Reflection.MethodInfo.GetCurrentMethod().Name, "arg1 = " + arg1.ToString(), leftSymbol.ToString());
            return leftSymbol;
        }
                
        if ((arg1 != Constants.Message_Enum.PLAYER_CHOSE_RIGHT) && (arg1 != Constants.Message_Enum.AL_CHOICE_RIGHT))
        {

            // если дошли до этого места ошибка - запись в лог файл значения arg1
            ErrorHandler.ErrorWriter(System.Reflection.MethodInfo.GetCurrentMethod().Name, "arg1" + arg1);
            //закрываем программу
            ErrorHandler.CloseApplication();
        }
        
        return rightSymbol;	// игрок выбрал правый символ, возвращаем его значение*/        
    }

    //Метод проверка события "угадана сложная буква"
    protected void IsDifficultSybol()
    {
        if ( ((situation == Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION) && (symbolsSet.GetPointOfSymbolToStudy(symbolToStudy)) >= Constants.DIFFICULT_CASE_LEVEL))
            situation = Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION;
    }

    //Выбор парного символа
    protected void SetLeftSymbolSetRightSymbol()
    {
        if (rand.Next(0, 2) == 0)
        {
            leftSymbol = symbolToStudy;
            rightSymbol = symbolForComparison;
        }
        else
        {
            leftSymbol = symbolForComparison;
            rightSymbol = symbolToStudy;
        }
    }

    //Метод для передачи алфавиту сообщения о ходе игрока
    public void PutMessage(Constants.Message_Enum arg1)
    {
        if ((arg1 == Constants.Message_Enum.PLAYER_CHOSE_LEFT) || (arg1 == Constants.Message_Enum.PLAYER_CHOSE_RIGHT))
            ProсessingPlayerChoice(arg1);
        if ((arg1 == Constants.Message_Enum.AL_CHOICE_LEFT) || (arg1 == Constants.Message_Enum.AL_CHOICE_RIGHT))
            ProсessingAlChoice(arg1);

        GameDatasetGeneration();
    }

    //Метод генерации игрового набора данных
    protected void GameDatasetGeneration()
    {
        СhoosingSymbol();
        СhoosingComparisonSymbol();
        SetLeftSymbolSetRightSymbol();
    }

    //обработка хода игрока
    protected void ProсessingPlayerChoice(Constants.Message_Enum arg1)
    {
        SymbolFromPlayer(arg1);
        MakeValidation(); // в результате изменяется член данных Situation
        IsDifficultSybol(); // в результате изменяется член данных Situation
        ChangeSymbolPointsNumber();
        symbolsSet.SetCountCommonPoint();
    }

    //обработка хода компа
    protected void ProсessingAlChoice(Constants.Message_Enum arg1)
    {
        SymbolFromPlayer(arg1);
        MakeValidation(); // в результате изменяется член данных Situation
    }

    //Метод изменение числа баллов символа
    protected void ChangeSymbolPointsNumber()
    {
        if (situation == Constants.GameSituation_Enum.WRONG_ANSWER_SITUATION)
            ChangeScoreDueWrongAnswer();
        else
        {
            if ((situation == Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION) || (situation == Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION))
                ChangeScoreDueCorrectAnswer();
            else
            {
                // ошибка: непредусмотренное значение situation, запись этого значения в лог, прекращение работы проги
                ErrorHandler.ErrorWriter(System.Reflection.MethodInfo.GetCurrentMethod().Name, "непредусмотренное значение situation");
                ErrorHandler.CloseApplication();
            }
        }
    }

    //методы для тестирования
#if DEBUG
    public void  CommonTestMethod()
    {
        testСhoosingComparisonSymbol();
    }


    public void TestChangeScoreDueAnswer()
    {
        symbolToStudy = 'Ч';
        ChangeScoreDueCorrectAnswer();
        symbolToStudy = 'К';
        ChangeScoreDueWrongAnswer();
    }
    public void testСhoosingComparisonSymbol()
    {
        int circleNumber = 100000;
        int lettersCount = 33;
        int[] myLettersArray = new int[lettersCount];        
        symbolToStudy = 'Р';

        symbolsSet.FillSymbolsSet();
        symbolsSet.SetCountCommonPoint();
        for (int i = 0; i < circleNumber; i++)
        {
            СhoosingComparisonSymbol();
            int currentLetterIndex = symbolsSet.symbols_list.FindIndex(item => item.symbol_name == symbolForComparison);
            myLettersArray[currentLetterIndex]++;
        }
        DisplayArray(myLettersArray, circleNumber);
    }
    public void DisplayArray(int[] anyArray, int circleNumber)
    {
        int i = 0;
        foreach (int el in anyArray)
        {
            i++;
            Console.WriteLine(i + ": " + (float)(el) * 100 / (float)circleNumber);
        }
    }

    public void DisplayList()
    {
        symbolsSet.DisplaySymbolsList();
    }

#endif
}
