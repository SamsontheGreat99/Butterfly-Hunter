using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{
    private Character person;

    public GameObject pauseCanvas;
    public GameObject ResumeButton;
    public GameObject EndGameButton;
    public GameObject pauseButton;
    public GameObject GameUI;
    public TMP_Text scoreText;

    private void Start()
    {
        person = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
    }
    private void Update()
    {
        scoreText.text = "Current Score: " + person.characterScore.ToString();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        pauseButton.SetActive(false);
        GameUI.SetActive(false);
    }

    public void UnPauseGame()
    {
        pauseCanvas.SetActive(false);
        pauseButton.SetActive(true);
        GameUI.SetActive(true);
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        StudentInfo.Score += person.characterScore;
        SceneManager.LoadScene("EndGame");
    }
}
