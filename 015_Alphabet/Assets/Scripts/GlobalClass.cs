using UnityEngine;

public class GlobalClass
{
    public static Constants.GameSituation_Enum situation;
    public static Core CORE = new Core();

    public static int COUNT = 0;

    public static bool IsStartedGame = true;
    public static bool IsPaused = false;
    public static bool IsReloadList = false;


    public static string letter_setting = "FloatLetter"; //название настроек буквы
    public static string muted_setting = "muted";

    public static int RandomFromRange(int min = 0, int max=26)
    {
        int i = Random.Range(min, max);
        return i;
    }
}

