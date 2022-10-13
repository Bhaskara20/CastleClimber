using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;

    public float speedMultiplier;
    private int life =3;
    public GameObject Pause;

    //UI
    //public Text scoreText;
    //public Text highscoreText;
    public Image[] lifeImage;
    //public GameObject canvasGameOver;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //life = 3;
        //score = 0;
        //highscore = PlayerPrefs.GetInt("highscore",0);
        //Saveload.load();
        //speedMultiplier = 1f;
        updateUI();
    }

    //public void addScore(int value)
    //{
        //score += value;
        //if (score >= Saveload.highscoreData)
          //  Saveload.highscoreData = score;
        //updateUI();

    //}

    public void loseLife(int value)
    {
        life -= value;
        updateUI();
        if (life <= 0)
        {
            life = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene("castle");
            //TODO: Game Over
            //Time.timeScale = 0f;
            //Saveload.save();
            //canvasGameOver.SetActive(true);
        }
    }

    void updateUI()
    {
        //scoreText.text = "Score: " + score;
        //highscoreText.text = "Highscore: " + Saveload.highscoreData;
        for (int i = 0; i < 3; i++)
        {
            if (i < life)
            {
                lifeImage[i].color = Color.white;
            }
            else
                lifeImage[i].color = Color.grey;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
