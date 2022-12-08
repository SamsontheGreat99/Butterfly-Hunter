using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    public string savePath;

    public void CreateSaveFile()
    {
        savePath = Application.dataPath + "/Save.txt";

        if (!File.Exists(savePath))
        {
            File.WriteAllText(savePath, "User Saves\n\n");

            //Debug Print
            print("Created File on path: " + savePath);
        }
        else
        {
            //Debug Print
            print("File already exists");
        }
    }

    public void SaveTheGame()
    {
        //Debug Print
        //print("Saving");

        //Saves: ID, Start Time, Play Duration, Score, and any Feedback
        File.AppendAllText(savePath, "Student ID: " + StudentInfo.StudentID + "\n");
        File.AppendAllText(savePath, "Started Game: " + StudentInfo.StartTime + "\n");
        File.AppendAllText(savePath, "Play Duration: " + StudentInfo.PlayDuration + "\n");
        File.AppendAllText(savePath, "Score: " + StudentInfo.Score + "\n");
        File.AppendAllText(savePath, "Number of Replays: " + StudentInfo.ReplayCounter + "\n");
        File.AppendAllText(savePath, "Feedback: " + StudentInfo.Feedback + "\n");
        File.AppendAllText(savePath, "\n");
    }
}
