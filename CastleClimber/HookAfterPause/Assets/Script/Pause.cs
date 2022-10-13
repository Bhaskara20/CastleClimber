using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool gamepaused = false;
    public GameObject Pausebutton;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }
    
    public void retry()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }
    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
