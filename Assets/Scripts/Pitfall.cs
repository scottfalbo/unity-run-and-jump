using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{

    private Transform player;

    private Vector3 spawnPoint;


    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
        spawnPoint = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
            player.transform.position = spawnPoint;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
