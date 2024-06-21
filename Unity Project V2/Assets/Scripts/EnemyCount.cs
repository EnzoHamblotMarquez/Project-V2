using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCount : MonoBehaviour
{
    public static EnemyCount instance;

    private List<GameObject> enemies;
    private GameObject[] enemiesFound;

    private TextMeshProUGUI textMesh;


    private void Start()
    {
        enemies = new List<GameObject>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        enemies.Clear();

        enemiesFound = GameObject.FindGameObjectsWithTag(EnemyController.enemyTag);

        foreach (GameObject enemy in enemiesFound)
        {
            enemies.Add(enemy);
        }

        if (enemies.Count == 0)
        {
            GameSceneManager.instance.LoadMainMenu();
        }

        textMesh.text = "Remaining Enemies: " + enemies.Count.ToString();

    }

}
