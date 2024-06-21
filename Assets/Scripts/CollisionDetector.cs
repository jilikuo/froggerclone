using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameObject entPlayer;
    private GameObject entKiller; 

    void Start()
    {
        entPlayer = GameObject.FindWithTag("Player");
        entKiller = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject == entPlayer)
        {
            entPlayer.SetActive(false);
        }
    }

}
