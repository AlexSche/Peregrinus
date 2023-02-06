using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadMenu()
    {

        SceneManager.LoadScene(0);
        UIManager.Instance.LevelsScreen();

    }
}
