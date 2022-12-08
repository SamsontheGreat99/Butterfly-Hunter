using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject howTo;
    public Button startButton;
    public TMP_InputField idField;
    public GameObject feedbackArea;
    public TMP_InputField feedbackField;

    public void Update()
    {
        //If there's no idField, skip
        if (idField != null)
        {
            //If text field is 4 in length (4 digits)
            if (idField.text.ToString().Length == 4)
            {
                //Debug Print
                //print("IT's 4!");

                //Constantly Save StudentID so it's the current number
                StudentInfo.StudentID = int.Parse(idField.text);

                //Debug Print
                //print(StudentInfo.StudentID);

                //Turns Start Button on so player can play
                startButton.interactable = true;
            }
            else
            {
                //Turns Start Button off so player cant play
                startButton.interactable = false;
            }
        }

        if(feedbackField != null)
        {
            //Debug stuff
            //print("Feedbackfield stuff");
            //print("input is: " + feedbackField.text);  

            //Saves Feedback
            StudentInfo.Feedback = feedbackField.text;
        }


    }

    public void Start()
    {
        //Activates in the end of the game screen
        if (SceneManager.GetActiveScene().name == "EndGame")
        { 
            //Debug Prints
            //print("Output: "+ System.TimeSpan.FromSeconds((double)(new decimal(TimeSave.Timer))));
            //print("Already in?: " + StudentInfo.PlayDuration);

            //Stores Play duration (Adds to the duration if there is alread play duration)
            StudentInfo.PlayDuration += System.TimeSpan.FromSeconds((double)(new decimal(TimeSave.Timer)));
        }
    }

    public void HowToButton()
    {
        //Shows the Tutorial
        howTo.SetActive(true);
    }

    public void StartButton()
    {
        //Save Date Time when player starts the game
        StudentInfo.StartTime = System.DateTime.Now;

        //Debug Print
        //print("Date time thing: " + StudentInfo.StartTime);

        //Create the main save file
        gameObject.GetComponent<Save>().CreateSaveFile();

        //Load the main game
        SceneManager.LoadScene("Game");
    }

    public void HowtoExitButton()
    {
        //"Exits" (hides) the Tutorial
        howTo.SetActive(false);
    }

    public void FeedbackButton()
    {
        //Turns on feedback canvas
        feedbackArea.SetActive(true);
    }

    public void FeedbackExitButton()
    {
        //Turns off feedback canvas
        feedbackArea.SetActive(false);
    }

    public void Replay()
    {
        //Load main menu start scene
        StudentInfo.ReplayCounter++;
        SceneManager.LoadScene("Game");
    }

    public void exitGame()
    {
        //Will check if there is a save file
        gameObject.GetComponent<Save>().CreateSaveFile();
        //Will save the game
        gameObject.GetComponent<Save>().SaveTheGame();
        //Closes the application
        Application.Quit();
        //Stops the Editor play mode (simulates quitting the game)
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
