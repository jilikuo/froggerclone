using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float stepSize;
    private Vector2 targetPosition;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        transform.position = targetPosition;
    }

    private void playerMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
            targetPosition += Vector2.up * stepSize;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            targetPosition += Vector2.down * stepSize;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            targetPosition += Vector2.left * stepSize;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            targetPosition += Vector2.right * stepSize;
    }


}
