using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public static GameSceneManager instance;
    private Scene currentScene;

    private const string mainMenuSceneName = "Main Menu";
    private const string optionsMenuSceneName = "Options Menu";
    private const string mainSceneName = "Test Scene";



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            LoadMainScene();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            LoadOptionsMenu();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        if (currentScene.name != mainMenuSceneName)
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }

    public void LoadOptionsMenu()
    {
        if (currentScene.name != optionsMenuSceneName)
        {
            SceneManager.LoadScene(optionsMenuSceneName);
        }
    }

    public void LoadMainScene()
    {
        if (currentScene.name != mainSceneName)
        {
            SceneManager.LoadScene(mainSceneName);
        }
    }


    public void QuitApplication()
    {
        Application.Quit();
    }

}
