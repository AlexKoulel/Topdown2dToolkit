using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple script so that the camera can follow the player.
/// The player always stays at the center of the screen.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private Camera mainCam;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        mainCam = GetComponent<Camera>();
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x , player.transform.position.y,-10);
    }
}
