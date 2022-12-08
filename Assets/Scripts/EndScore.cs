using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScore : MonoBehaviour
{
    TMP_Text Highscore, Score;

    void Start()
    {
        //Highscore = GameObject.Find("Highscore").GetComponent<TMP_Text>();
        Score = GameObject.Find("Score").GetComponent<TMP_Text>();
        Score.text = "Score: " + StudentInfo.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + StudentInfo.Score.ToString();

        //Debug Print
        //print(StudentInfo.Score);

        //if (!PlayerPrefs.HasKey("Highscore"))
        //{
        //PlayerPrefs.SetInt("Highscore", 100);
        //}
        //if (!PlayerPrefs.HasKey("Score"))
        //{
        //PlayerPrefs.SetInt("Score", 0);
        //}

        //Highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
        //Score.text = "Score: " + PlayerPrefs.GetInt("Score");

    }
}
