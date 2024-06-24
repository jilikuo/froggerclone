using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameObject objUI;
    private GameObject entPlayer;
    private GameObject entKiller;

    void Start()
    {
        objUI     = GameObject.Find("GameStateText ");
        entPlayer = GameObject.FindWithTag("Player");
        entKiller = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject == entPlayer)
        {
            entPlayer.GetComponent<PlayerMovement>().enabled = false;
            objUI.GetComponent<TextMesh>().text = "Game Over";
            objUI.SetActive(true);
        }
    }

}
