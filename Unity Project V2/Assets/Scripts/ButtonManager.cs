using System.Collections;
using System.Collections.Generic;
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
            myButton.onClick.AddListener(GameSceneManager.instance.LoadMainScene);
        }
        if (myButtonName == "Exit")
        {
            Application.Quit();
            Debug.Log("Exit");
        }

    }

}
