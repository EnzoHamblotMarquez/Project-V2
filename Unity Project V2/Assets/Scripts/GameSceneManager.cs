using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{

    public static GameSceneManager instance;
    Scene currentScene;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            LoadTestScene();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            //!
        }

        if (EnemyManager.instance.GetEnemyList().Count == 0 || Input.GetKeyDown(KeyCode.R))
        {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        if (currentScene.name != "Main Menu")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void LoadTestScene()
    {
        if (currentScene.name != "Test Scene")
        {
        SceneManager.LoadScene("Test Scene");
        }
    }
    public void LoadMainScene()
    {
        if (currentScene.name != "Main Scene")
        {
            SceneManager.LoadScene("Main Scene");
        }
    }
    
}
