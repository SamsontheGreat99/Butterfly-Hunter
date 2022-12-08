using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{


    private Character person;
    public TMP_Text scoreText;
    public Slider thisSlider;
    public TMP_Text levelNumber;
    private bool hasBeaten1 = false;

    //"boxS" is just the name of the enemy spawn script
    //public EnemySpawnerScriptHere boxS

    private void Awake()
    {
        person = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        thisSlider.value = person.characterScore;
        scoreText.text = "Score: " + (thisSlider.value);

        //Level based on score
        if(thisSlider.value > -1 && thisSlider.value < 100) //Normal 0
        {
            //Debug.Log("level 0");

            //This set the enemy spawn timer to a new value
            //Enemy Spawner.timer = 2f;
            levelNumber.text = (1.ToString());
        }
        else if(thisSlider.value >= 100 && thisSlider.value < 200) //Medium 1
        {
            hasBeaten1 = true;
            //Debug.Log("level 1");
            levelNumber.text = (2.ToString());
            
            //This will set the enemy spawn timer down, making enemies spawn faster
            //boxS.timer = 1f;
        }
        else if(thisSlider.value >= 200) //Hard 2
        {
            //Debug.Log("level 2");
            levelNumber.text = (3.ToString());

            //This will set the enemy spawn timer down, making enemies spawn faster
            //boxS.timer = 0.5f;
        }
        
        if(thisSlider.value == 0 && hasBeaten1)
        {
            //Made sure to add score before calling the endgame scene
            //  This way the points are added
            StudentInfo.Score += person.characterScore;
            SceneManager.LoadScene("EndGame");
        }
        if(thisSlider.value == 1000)
        {
            StudentInfo.Score += person.characterScore;
            SceneManager.LoadScene("EndGame");
        }

        if(thisSlider.value == thisSlider.maxValue)
        {
            //saveChecker();            
            thisSlider.maxValue += 100;
        }
    }


    //public int calcScore()
    //{
    //}

    //public void saveChecker()
    //{
    //    if (!PlayerPrefs.HasKey("Highscore"))
    //    {
    //        PlayerPrefs.SetInt("Highscore", 100); //Default is 100
    //    }
    //    if (!PlayerPrefs.HasKey("Score"))
    //    {
    //        PlayerPrefs.SetInt("Score", 0);
    //    }

    //    PlayerPrefs.SetInt("Score", calcScore());

    //    if (PlayerPrefs.GetInt("Highscore") < PlayerPrefs.GetInt("Score"))
    //    {
    //        PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score"));
    //    }
    //}
}
