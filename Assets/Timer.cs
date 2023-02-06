using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;

public class Timer : MonoBehaviour
{
    public Text myTimerText;
    bool timerStarted = false;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            time += Time.deltaTime;
        }
        displayTime();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Hier wird der Timer gestartet
        timerStarted = true;
        Debug.Log("Starte Timer");
    }

    public void startTimer()
    {
        timerStarted = true;
    }

    public void endTimer() 
    {
        timerStarted = false;
    }

    public void saveTimeInDatabase()
    {
        endTimer();
        //time in db für den Nutzer speichern
        int level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Level: " + level);

        FirebaseManager.Instance.SaveTime(level, time);

    }

    void displayTime()
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliSeconds = (time % 1) * 1000;
        myTimerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
