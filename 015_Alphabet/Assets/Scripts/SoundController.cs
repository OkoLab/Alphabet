using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Sprite voliumeOn;
    [SerializeField] Sprite voliumeOff;
    public Button voliumeBtn;
    private bool isMuted = false;

    private void Start()
    {
        if(!PlayerPrefs.HasKey(GlobalClass.muted_setting))
        {
            PlayerPrefs.SetInt(GlobalClass.muted_setting, 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = isMuted;
    }

    private void UpdateButtonIcon()
    {
        if (isMuted == false)
            voliumeBtn.image.sprite = voliumeOn;
        else
            voliumeBtn.image.sprite = voliumeOff;
    }

    public void OnClickMusicVoliumeOnOf()
    {
        if(isMuted == false)
        {
            isMuted = true;
            AudioListener.pause = isMuted;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = isMuted;
        }

        Save();
        UpdateButtonIcon();
    }

    private void Load()
    {
        isMuted = PlayerPrefs.GetInt(GlobalClass.muted_setting) == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt(GlobalClass.muted_setting, isMuted ? 1 : 0);
    }

}
