using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    private Phrases phrases = new Phrases();
    public AudioClip hoorayClip; //
    public AudioSource phraseAudioS;
    private AudioClip phraseClip;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        Animation animation = new Animation();
        Image seaDwellerImage = GameObject.Find("Marine_life").GetComponent<Image>();
        Constants.GameSituation_Enum situation = GlobalClass.CORE.GetSituation();

        if (situation == Constants.GameSituation_Enum.RIGHT_ANSWER_SITUATION || situation == Constants.GameSituation_Enum.RIGHT_ANSWER_DIFFICULT_CASE_SITUATION)
        {
            //win
            string str = animation.GetAnimationBySituation(situation);
            Sprite seaDwellerSprite = Resources.Load<Sprite>(str);
            seaDwellerImage.sprite = seaDwellerSprite;
            seaDwellerImage.enabled = true;

            PlayAudioClip(hoorayClip);
            yield return new WaitForSeconds(hoorayClip.length);
        }
        else
        {
            //loose не показываем картинку
            seaDwellerImage.enabled = false;
        }

        //ход человека - проигрываем фразу, ход робота - фразу не проигрываем
        if (GlobalClass.CORE.GetIsAI() == false)
        {
            phraseClip = Resources.Load<AudioClip>(phrases.GetPhraseBySituation(situation));
            PlayAudioClip(phraseClip, phraseAudioS);

            yield return new WaitForSeconds(phraseClip.length); // таймер, через n секунд
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene("Main"); // выполнится эта строка
    }

    void PlayAudioClip(AudioClip symbolAudio, AudioSource audioS = null)
    {
       if (audioS == null)
           audioS = GetComponent<AudioSource>();

       audioS.PlayOneShot(symbolAudio);
       if (PlayerPrefs.GetInt(GlobalClass.muted_setting) == 1)
           AudioListener.pause = true;
    }
}
