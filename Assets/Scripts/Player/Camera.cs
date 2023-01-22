using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    private Vector3 cameraPos = new Vector3(-7, 12, -7);
    
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        transform.position = player.transform.position + cameraPos;
    }
}
