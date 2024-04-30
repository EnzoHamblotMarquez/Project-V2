using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomSpawner : MonoBehaviour
{
    private RoomTemplates roomTemplates;
    private HashSet<Vector3> notSpawnedRoomPositions;
    private HashSet<Vector3> spawnedRoomPositions;

    [SerializeField] private int maxTwoDoorRooms;

    [SerializeField] private float roomDistance;

    private bool startClosingRooms;


    void Start()
    {
        roomTemplates = GetComponent<RoomTemplates>();

        notSpawnedRoomPositions = new HashSet<Vector3>
        {
            Vector3.left * roomDistance, Vector3.right * roomDistance, Vector3.up * roomDistance, Vector3.down * roomDistance
        };

        spawnedRoomPositions = new HashSet<Vector3>
        {
            Vector3.zero
        };


        startClosingRooms = true;

        Spawn();
    }


    void Update()
    {

    }

    private void Spawn()
    {        

        while (!startClosingRooms)
        {
            /*foreach (Vector3 pos in notSpawnedRoomPositions)
            {
                Instantiate(roomTemplates.entryRoom, pos, Quaternion.identity);
            }



            if (spawnedRoomPositions.Count - 1 == maxTwoDoorRooms)
            {
                startClosingRooms = true;
            }*/
        }

        foreach (Vector3 pos in notSpawnedRoomPositions)
        {
            Instantiate(roomTemplates.closedRoom, pos, Quaternion.identity);
        }

    }
}
