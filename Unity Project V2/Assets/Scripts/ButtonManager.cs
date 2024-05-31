using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button myButton;
    string myButtonName;

    void Start()
    {
        myButtonName = myButton.name;


        if (myButtonName == "Play")
        {
            myButton.onClick.AddListener(GameSceneManager.instance.LoadTestScene);
        }
        if (myButtonName == "Options")
        {
            myButton.onClick.AddListener(GameSceneManager.instance.LoadOptionsMenu);
        }
        if(myButtonName == "Back")
        {
            myButton.onClick.AddListener(GameSceneManager.instance.LoadMainMenu);
        }
        if (myButtonName == "Exit")
        {
            myButton.onClick.AddListener(OnExitPressed);
        }

    }

    private void OnExitPressed ()
    {
        Application.Quit();
    }

}
