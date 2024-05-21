using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    List<GameObject> enemies;
    GameObject[] enemiesFound;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;

        enemies = new List<GameObject>();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        enemies.Clear();

        enemiesFound = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemiesFound)
        {
            enemies.Add(enemy);
        }

        if (enemies.Count == 0)
        {
            GameSceneManager.instance.LoadMainScene();
        }
    }
}
