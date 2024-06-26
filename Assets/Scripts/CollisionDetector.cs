using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameObject controller;
    private GameObject entPlayer;

    void Start()
    {
        controller   = GameObject.FindWithTag("GameController");
        entPlayer    = GameObject.FindWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        //se houver colisão, desativa o movimento do jogador e chama a tela de game over
        if (other.gameObject == entPlayer)
        {
            entPlayer.GetComponent<PlayerMovement>().enabled = false;
            controller.GetComponent<GameOverScreen>().CallGameOverScreen(true);
        }
    }

}
