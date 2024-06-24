using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameObject controller;
    private GameObject entPlayer;
    private GameObject entKiller;

    void Start()
    {
        controller   = GameObject.FindWithTag("GameController");
        entPlayer    = GameObject.FindWithTag("Player");
        entKiller    = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject == entPlayer)
        {
            entPlayer.GetComponent<PlayerMovement>().enabled = false;
            controller.GetComponent<GameOverScreen>().CallGameOverScreen(true);
        }
    }

}
