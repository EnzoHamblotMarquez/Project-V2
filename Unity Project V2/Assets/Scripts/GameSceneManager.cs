using UnityEngine;
using UnityEngine.SceneManagement;

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
            LoadOptionsMenu();
        }

        if (EnemyManager.instance.GetEnemyList().Count == 0 && SceneManager.GetActiveScene().name == "Test Scene" || Input.GetKeyDown(KeyCode.R))
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

    public void LoadOptionsMenu()
    {
        if (currentScene.name != "Options Menu")
        {
            SceneManager.LoadScene("Options Menu");
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
