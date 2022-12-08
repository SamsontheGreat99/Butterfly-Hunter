using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float setTimer;
    public TMP_Text clock;

    public Score score;

    private void Awake()
    {
        setTimer = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        setTimer += Time.deltaTime;

        if(setTimer < 0)
        {
            setTimer = 0;
        }

        DisplayTimer(setTimer);
        TimeSave.Timer = setTimer;
    }

    void DisplayTimer(float time)
    {
        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);

        clock.text = string.Format("{0:00}:{1:00}", min, sec);
    }

}
