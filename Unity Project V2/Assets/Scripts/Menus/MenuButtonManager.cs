using UnityEngine;
using UnityEngine.UI;

public class MenuButtonManager : MonoBehaviour
{
    public Button myButton;
    private string myButtonName;

    void Start()
    {
        myButtonName = myButton.name;


        if (myButtonName == "Play")
        {
            myButton.onClick.AddListener(GameSceneManager.instance.LoadMainScene);
        }
        if (myButtonName == "Options")
        {
            myButton.onClick.AddListener(GameSceneManager.instance.LoadOptionsMenu);
        }
        if (myButtonName == "Back")
        {
            myButton.onClick.AddListener(GameSceneManager.instance.LoadMainMenu);
        }
        if (myButtonName == "Exit")
        {
            myButton.onClick.AddListener(GameSceneManager.instance.QuitApplication);
        }

    }

}
