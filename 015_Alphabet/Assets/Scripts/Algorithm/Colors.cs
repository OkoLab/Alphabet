using System;
using UnityEngine;
using Random = System.Random;

public class Colors
{
    readonly Random random = new Random();

    //получаем цвет из hex кода
    private Color32 GetColorFromHexCode(int hex)
    {
        byte R = (byte)((hex >> 16) & 0xFF);
        byte G = (byte)((hex >> 8) & 0xFF);
        byte B = (byte)((hex) & 0xFF);
        return new Color32(R, G, B, 255);
    }

    //получаем рандомный элемент из Enum. Исключения отсутствуют  
    public Color32 GetRandomColors()
    {
        Array input_enum = Enum.GetValues(typeof(Constants.Colors_Enum));
        //берем имя элемента enum
        Constants.Colors_Enum symbolColorName = (Constants.Colors_Enum)input_enum.GetValue(random.Next(input_enum.Length));
        //берем значение выбранного элемента enum
        int symbolColor = (int)symbolColorName;
        //получаем цвет из значения выбранного элемента enum
        return GetColorFromHexCode(symbolColor);
    }
}
