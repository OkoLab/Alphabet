using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public GameObject mainButtons;

    public void OnClickPlay()
    {
        pauseMenuUI.SetActive(false);
        mainButtons.SetActive(true);
        GlobalClass.IsPaused = false;
    }

    public void OnClickPause()
    {
        pauseMenuUI.SetActive(true);
        mainButtons.SetActive(false);
        GlobalClass.IsPaused = true;
    }

    public void OnClickRating()
    {
        Application.OpenURL("https://google.com");
    }

    public void OnClickReload()
    {
        GlobalClass.IsReloadList = true;
        GlobalClass.IsPaused = false;
        SceneManager.LoadScene("Main");
    }    

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();

        switch (gameObject.name)
        {
            case "LeftLetter":
                GlobalClass.CORE.PutMessage(Constants.Message_Enum.PLAYER_CHOSE_LEFT);
                SceneManager.LoadScene("Result");
                break;
            case "RightLetter":
                GlobalClass.CORE.PutMessage(Constants.Message_Enum.PLAYER_CHOSE_RIGHT);
                SceneManager.LoadScene("Result");
                break;
        }        
    }
}
