using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public static GameSceneManager instance;
    Scene currentScene;
    
    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.R))
        {
            LoadTestScene();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            LoadMainScene();
        }
    }

    public void LoadTestScene()
    {
        if (currentScene.name != "Test Scene")
        {
        //SceneManager.LoadScene("Test Scene"); //LoadMainScene not working properly after going back to Test Scene once. //!
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
