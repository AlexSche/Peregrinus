using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject("UIManager");
                gameObject.AddComponent<UIManager>();
            }
            return _instance;
        }

    }
    public GameObject loginMenu;
    public GameObject registerMenu;
    public GameObject mainMenu;
    public GameObject levelsMenu;
    public GameObject level1Menu;
    public GameObject level2Menu;
    public GameObject level3Menu;
    public GameObject optionsMenu;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    public void LoginScreen()
    {
        loginMenu.SetActive(true);
        mainMenu.SetActive(false);
        registerMenu.SetActive(false);
    }

    public void MainScreen()
    {
        mainMenu.SetActive(true);
        levelsMenu.SetActive(false);
        loginMenu.SetActive(false);
        optionsMenu.SetActive(false);
        level1Menu.SetActive(false);
        level2Menu.SetActive(false);
        level3Menu.SetActive(false);

    }

    public void LevelsScreen() //Level button in MainMenu
    {
        levelsMenu.SetActive(true);
        mainMenu.SetActive(false);
        level1Menu.SetActive(false);
        level2Menu.SetActive(false);
        level3Menu.SetActive(false);
    }

    public void Level1Screen() //Level1 button in LevelsMenu
    {
        levelsMenu.SetActive(false);
        level1Menu.SetActive(true);
    }
    public void Level2Screen() //Level2 button in LevelsMenu
    {
        levelsMenu.SetActive(false);
        level2Menu.SetActive(true);
    }
    public void Level3Screen() //Level3 button in LevelsMenu
    {
        levelsMenu.SetActive(false);
        level3Menu.SetActive(true);
    }

    public void RegisterScreen() // Register button
    {
        loginMenu.SetActive(false);
        registerMenu.SetActive(true);
    }

    public void OptionsScreen() // Option button
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
