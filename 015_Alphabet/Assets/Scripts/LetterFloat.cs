using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterFloat : MonoBehaviour
{
    public Transform bottomTarget;
    public Transform middleTarget;
    public Transform leftTarget;
    public Transform rightTarget;

    public Text leftLetter;
    public Text rightLetter;

    public float speed;
    bool middleFlag = false;
    //public float delta;


    private int random; //определаем в какую сторону пойдет кнопка

    //AudioSource audioSource;
    private AudioClip symbolClip;
    private AudioClip phraseClip;
    public AudioSource phraseAudioSource;
    public AudioSource symbolAudioSource;

    private Phrases phrases = new Phrases();

    IEnumerator Start()
    {        
        random = GlobalClass.RandomFromRange(0, 2);

        //была нажата кнопка reload в меню
        if (GlobalClass.IsReloadList == true)
        {
            GlobalClass.CORE.ReloadCore();
            GlobalClass.IsReloadList = false;
        }

#if DEBUG
        GlobalClass.CORE.DisplayList();
#endif

        //audioSource = GetComponent<AudioSource>();
        GlobalClass.CORE.PutMessage(Constants.Message_Enum.GAME_START);
        //заполняем буквы значениями
        GetComponent<TextMesh>().text = GlobalClass.CORE.GetSymbolToStudy();
        
        //расчитываем скорость падения буквы 
        speed -= GlobalClass.CORE.GetSymbolPoint()*0.001f;

        leftLetter.text = GlobalClass.CORE.GetLeftSymbol();
        rightLetter.text = GlobalClass.CORE.GetRightSymbol();

        //определяем цвет букв
        Colors colors = new Colors();
        GetComponent<TextMesh>().color = leftLetter.color = rightLetter.color = colors.GetRandomColors();

        //проигрываем приветствие при запуске игры
        if (GlobalClass.IsStartedGame == true)
        {
            //путь к аудио файлу фразы
            phraseClip = Resources.Load<AudioClip>(phrases.GetPhraseBySituation(Constants.GameSituation_Enum.GAME_START_SITUATION));
            //проговариваем фразу
            PlayAudioClip(phraseClip, phraseAudioSource);
            //ждем пока проговорится фраза
            yield return new WaitForSeconds(phraseClip.length);
            GlobalClass.IsStartedGame = false;
        }
        
        //путь к аудио файлу буквы
        symbolClip = Resources.Load<AudioClip>(GlobalClass.CORE.GetSymbolSound());
        //проговариваем букву
        PlayAudioClip(symbolClip, symbolAudioSource);
    }

    void FixedUpdate()
    {        
        if (GlobalClass.IsStartedGame == false)
        {
            if (GlobalClass.IsPaused == true)
                Time.timeScale = 0f;
            else
            {
                Time.timeScale = 1f;

                if (transform.position.y == middleTarget.position.y)
                    PlayAudioClip(symbolClip, symbolAudioSource);

                if(middleFlag == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, middleTarget.position, speed);
                    if(transform.position.y == middleTarget.position.y)
                    {
                        PlayAudioClip(symbolClip, symbolAudioSource);
                        middleFlag = true;
                    }
                }
                else
                {
                    if (transform.position.y != bottomTarget.position.y)
                        transform.position = Vector3.MoveTowards(transform.position, bottomTarget.position, speed);
                    else
                    {

                        if (transform.position == bottomTarget.position)
                            PlayAudioClip(symbolClip, symbolAudioSource);

                        if (transform.position.y == bottomTarget.position.y)
                        {
                            if (random == 0) //идем на лево
                            {
                                transform.position = Vector3.MoveTowards(transform.position, leftTarget.position, speed);
                                if(transform.position == leftTarget.position)
                                {
                                    GlobalClass.CORE.PutMessage(Constants.Message_Enum.AL_CHOICE_LEFT);
                                    SceneManager.LoadScene("Result");
                                }
                            }
                            else //идем на право
                            {
                                transform.position = Vector3.MoveTowards(transform.position, rightTarget.position, speed);
                                if (transform.position == rightTarget.position)
                                {
                                    GlobalClass.CORE.PutMessage(Constants.Message_Enum.AL_CHOICE_RIGHT);
                                    SceneManager.LoadScene("Result");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    void PlayAudioClip(AudioClip symbolAudio, AudioSource audioS)
    {
        AudioSource audioSource = audioS;
        audioSource.PlayOneShot(symbolAudio);
        if (PlayerPrefs.GetInt(GlobalClass.muted_setting) == 1)
            AudioListener.pause = true;
    }

    void OnApplicationQuit()
    {
        GlobalClass.CORE.Save();
        Debug.Log("Application ending after " + Time.time + " seconds");
    }

    void OnApplicationPause(bool isApplicationPaused)
    {
        if(isApplicationPaused)
            GlobalClass.CORE.Save();
        Debug.Log("Application paused -- " + isApplicationPaused);
    }

}
