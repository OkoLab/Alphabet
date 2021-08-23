using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{

    public GameObject m_on, m_off;

    private void Start()
    {
        
        if (PlayerPrefs.GetString("Music") == "no")
        {
            m_on.SetActive(false);
            m_off.SetActive(true);
        }
        else
        {
            m_on.SetActive(true);
            m_off.SetActive(false);
        }
        
    }

    private void OnMouseUpAsButton()
    {
        if(gameObject.name == "Music")
        {
            if (PlayerPrefs.GetString("Music") != "no")
            {
                PlayerPrefs.SetString("Music", "no");
                m_on.SetActive(false);
                m_off.SetActive(true);
                GameObject.Find("Background_music").GetComponent<AudioSource>().Stop();

            }
            else
            {
                PlayerPrefs.SetString("Music", "yes");
                m_on.SetActive(true);
                m_off.SetActive(false);
                GameObject.Find("Background_music").GetComponent<AudioSource>().Play();
            }
        }
    }
}
