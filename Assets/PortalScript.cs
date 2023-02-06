using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Hier wird der Timer beendet
        timer.endTimer();
        timer.saveTimeInDatabase();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //SceneManager.LoadScene("Level_02");
        //Die selbe Scene laden
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
