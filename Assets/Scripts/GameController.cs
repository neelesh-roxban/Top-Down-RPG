using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject deathScreen;
    public GameObject pauseScreen;
    public float Score;
    public Text ScoreUI;
    public Text DeathScreenUI;
    public Text PauseScreenUI;
    public Timer Timer;
   

    private void Awake()
    {
       
        if (!instance)
        {
            instance = this;
        }
        Score = 0f;
    }
    

    public void playerDeath()
    {
        DeathScreenUI.text = Score.ToString();
        deathScreen.SetActive(true);
        Time.timeScale = 0f;

    }

   public void RestartButton()
    {
        reset();
        deathScreen.SetActive(false);
        Timer.time = 0f;

    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1 1");
        reset();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void menuButton()
    {
        Debug.Log("home");
        SceneManager.LoadScene("Home");
    }
    public void pauseButton()
    {
        DeathScreenUI.text = Score.ToString();
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }


    public void addscore()
    {

        Score += 10;
        Debug.Log(Score);
        ScoreUI.text = Score.ToString();
    }
    private void reset()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] Bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject s in enemies)
        {

            Destroy(s);
        }
        foreach (GameObject s in Bullets)
        {

            Destroy(s);
        }
        Score = 0f;
        Time.timeScale = 1f;
        

    }
}
