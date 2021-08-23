using UnityEngine;

public class PlayBackround : MonoBehaviour
{
    //проигрываем звук на бэкроунд
    void Start()
    {
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
        if(PlayerPrefs.GetInt(GlobalClass.muted_setting) == 1)
            AudioListener.pause = true;
    }
}
