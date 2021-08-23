using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//структура буквы
public struct Symbol
{
    //символ
    public Char symbol_name;
    //Путь к аудио файлу
    public String path;
    //Число баллов
    public int pointCounter;
}

//заполняем алфавит буквами
public struct SymbolsSet
{
        //общее число баллов
        private int commonPointCounter;

    //инициализируем список букв
        public List<Symbol> symbols_list;

        public int GetcommonPointCounter()
        {
            return commonPointCounter;
        }


        //заполняем список структурой из Symbol
        public void FillSymbolsSet(List<Symbol> savedList = null)
        {
            if (savedList == null) //если список букв отсутствует, то создаем и заполняем его
            {
                symbols_list = new List<Symbol>();

                //массив букв
                List<char> letters = Enumerable.Range(0, 32).Select((x, i) => (char)('А' + i)).ToList();
                //добавляем букву Ё
                letters.Insert(6, (char)1025);

                Symbol symbol = new Symbol();
                foreach (char ch in letters)
                {
                    symbol.symbol_name = ch;
                    symbol.path = Constants.LETTER_PATH + ch + Constants.AUDIO_FORMAT;
                    symbol.pointCounter = Constants.DEFAULT_SYMBOL_SCORE; //значение по умолчанию
                    symbols_list.Add(symbol);
                }
            }
            else //если список букв уже сохранен, то записываем его
                symbols_list = savedList;
        }

        //считаем общее число баллов в списке. возвращает -1, если список пуст 
        //public int CountCommonPoint()
        public void SetCountCommonPoint()
        {
            commonPointCounter = 0;

            if (symbols_list != null)
            {
                foreach (var symbol in symbols_list)
                {
                    commonPointCounter += symbol.pointCounter;
                }
            }

            //return commonPointCounter;
        }

        //число баллов, соответствующее temp_symbolToStudy
        public int GetPointOfSymbolToStudy(Char temp_symbolToStudy)
        {
            Symbol temp_symbol = symbols_list.Find(item => item.symbol_name == temp_symbolToStudy);
            return temp_symbol.pointCounter;
        }


        //методы для тестирования
#if DEBUG
        //выводит в консоль список структур символов
        public void DisplaySymbolsList()
        {
            if (symbols_list != null)
            {                
                Debug.Log("commonPointCounter: " + commonPointCounter);
                foreach (Symbol symbol in symbols_list)
                {
                    Debug.Log("Буква:" + symbol.symbol_name + "  Путь:" + symbol.path + "   Балл:" + symbol.pointCounter);
                }

                Debug.Log("__________________________________________________________");
        }
        }
        #endif
    }
