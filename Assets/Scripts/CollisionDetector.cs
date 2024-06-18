using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameObject entPlayer;
    private GameObject entKiller; 


    // Start is called before the first frame update
    void Start()
    {
        entPlayer = GameObject.FindWithTag("Player");
        entKiller = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D() 
    {   
        entPlayer.SetActive(false);      
    }

}
