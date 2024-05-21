using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float smoothTime = 0.25f;
    Vector3 velocity = Vector3.zero;
    [SerializeField] Transform player;


    void FixedUpdate() //Does not work properly if it's in other types of "Update" functions //!
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = transform.position;

        transform.position = Vector3.SmoothDamp(cameraPosition, playerPosition, ref velocity, smoothTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
