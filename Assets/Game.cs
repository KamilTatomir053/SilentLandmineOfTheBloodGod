using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Soldiers soldiers;

    public GameObject mainMenu;

    public GameObject gameUI;

    public GameObject detonateButton;

    public Text recordScoreText;

    public Text scoreText;

    public Animator bombAnimator;

    public Animator explosionAnimator;

    private bool bombIsExploded = false;

    public Text livesText;

    public int lives = 5;

    private int score = 0;

    public GameObject lostText;

    // Start is called before the first frame update
    void Start()
    {
        RefreshHighScore();

        Time.timeScale = 0;

        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        soldiers.StartSoldierMovement();

        Time.timeScale = 1;

        mainMenu.SetActive(false);

        gameUI.SetActive(true);
    }

    public void RemoveHeart()
    {
        if (lives > 0)
            lives--;

        livesText.text = "Lives: " + lives;

        if (lives == 0)
        {
            lostText.SetActive(true);

            Invoke("ShowMainMenu", 3);
        }
    }

    public void RespawnBomb()
    {
        bombIsExploded = false;

        bombAnimator.SetTrigger("respawn");

        explosionAnimator.SetTrigger("respawn");

        detonateButton.SetActive(true);
    }

    public void Bomb()
    {
        if (bombIsExploded == false)
        {
            bombIsExploded = true;

            bombAnimator.SetTrigger("detonate");

            explosionAnimator.SetTrigger("detonate");
        }
    }

    public void ShowMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void AddPoint()
    {
        score++;

        scoreText.text = "Score: " + score;

        int highScore = 0;

        if (PlayerPrefs.HasKey("score") == true)
        {
            highScore = PlayerPrefs.GetInt("score");
        }

        if (score > highScore)
        {
            PlayerPrefs.SetInt("score", score);
        }

        RefreshHighScore();
    }

    private void RefreshHighScore()
    {
        int highScore = 0;

        if (PlayerPrefs.HasKey("score") == true)
        {
            highScore = PlayerPrefs.GetInt("score");
        }

        recordScoreText.text = "High Score: " + highScore;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
