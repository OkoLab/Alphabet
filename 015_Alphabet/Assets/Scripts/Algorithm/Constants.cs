public static class Constants
{
    public const int MAX_PROBABILITY_ACCURACY = 2;
    public enum GameSituation_Enum { GAME_START_SITUATION, WRONG_ANSWER_SITUATION, RIGHT_ANSWER_SITUATION, RIGHT_ANSWER_DIFFICULT_CASE_SITUATION };
    public enum Message_Enum { GAME_START, PLAYER_CHOSE_LEFT, PLAYER_CHOSE_RIGHT, AL_CHOICE_LEFT, AL_CHOICE_RIGHT };
    public enum Colors_Enum
    {
        CRIMSON_COLOR = 0xDC143C,
        RED_COLOR = 0xFF0000,
        BLUE_COLOR = 0x4A2BDD,
        DEEPPINK_COLOR= 0xFF1493,
        MEDIUMVIOLETRED_COLOR = 0xC71585,
        TOMATO_COLOR = 0xFF6347,
        DARKORANGE_COLOR = 0xFF8C00,
        DARKMAGENTA_COLOR = 0x8B008B,
        INDIGO_COLOR = 0x4B0082,
        DARKGOLDENROD_COLOR = 0xB8860B,
        GREEN_COLOR = 0x008000,
        DARKCYAN_COLOR = 0x008B8B,
        STEELBLUE_COLOR = 0x4682B4
    }

    public const string LETTER_PATH = "Audio/Letter/";
    public const string PHRASE_PATH = "Audio/Phrases/";
    public const string ANIMATION_PATH = "Sprites/Fishes/";
    public const string AUDIO_FORMAT = "";

    //Количество баллов у символа по умолчанию
    public const int DEFAULT_SYMBOL_SCORE = 5;
    //Шаг уменьшения баллов при угадывании
    public const int SYMBOL_SCORE_STEP_IF_RIGHT = 1;
    //Шаг увеличения баллов при ошибке
    public const int SYMBOL_SCORE_STEP_IF_FAULT = 2;
    //Минимальное значение баллов у символа
    public const int SYMBOL_MINIMUM_SCORE = 1;
    //Максимальное значение баллов у символа
    public const int SYMBOL_MAXIMUM_SCORE = 10;

    //Если баллов больше или равно, то это сложная буква
    public const int DIFFICULT_CASE_LEVEL = 8;
}
