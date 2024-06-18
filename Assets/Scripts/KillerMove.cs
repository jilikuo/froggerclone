        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerMove : MonoBehaviour
{
    //variáveis de controle de dificuldade
    public float moveSpeed;

    //variáveis de controle de operação
    private Vector2 killerPosition;
    private Rigidbody2D thisBody;
    private Vector2 forceDirection;

    // Start is called before the first frame update
    void Start()
    {
        killerPosition = transform.position;
        thisBody = this.gameObject.GetComponent<Rigidbody2D>();
        VerifyPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisBody.AddForce(forceDirection * moveSpeed);
    }

    private void VerifyPosition()
    {
        if (killerPosition.x > 0 ) 
        {
            forceDirection = Vector2.left;
        }
        if (killerPosition.x < 0 ) 
        { 
            forceDirection = Vector2.right;
        }
    }
}