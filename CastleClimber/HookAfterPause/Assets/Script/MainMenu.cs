using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 

public class MainMenu : MonoBehaviour
{

    public GameObject Setting;
    public void PlayGame(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("StartCutscene");
    }

    public void SettingUI()
    {
        Setting.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
