using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variáveis limitadoras de movimento
    public float stepSize;
    public float mvCooldown; 

    //variáveis para cáculos internos
    private Vector2 targetPosition;
    private float currentCooldown;

    //constantes limites de cenário
    private const int limitNorth =   5;
    private const int limitEast  =  10;
    private const int limitSouth =  -5;
    private const int limitWest  = -10;

    // Start is called before the first frame update
    void Start()
    {
        ReadPlayerPosition();
        SetMoveCooldown();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove()) //se o cooldown está zerado, permite movimento
        {
            HandleMovement();
        }
        ReadPlayerPosition(); //sempre recalcula onde o jogador está
    }

    private void HandleMovement()
    {

        /* a ideia de colocar um return em cada if é evitar o movimento
         * completamente diagonal do jogador. */

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer(Vector2.up);
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer(Vector2.down);
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { 
            MovePlayer(Vector2.left);
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(Vector2.right);
            return;
        }
    }

    //funções relacionadas a posição do jogador
    private void MovePlayer(Vector2 direction)
    {
        Vector2 movementVector = direction * stepSize;

        if (ValidateMovement(movementVector))
        {
            targetPosition += movementVector;
            UpdatePlayerPosition();
            SetMoveCooldown();
        }
        else
        {
            return;
        }
    }

    private bool ValidateMovement(Vector2 mV)
    {
        if ((targetPosition.x + mV.x) <= limitWest || (targetPosition.x + mV.x) >= limitEast ||
            (targetPosition.y + mV.y) <= limitSouth || (targetPosition.y + mV.y) >= limitNorth)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void ReadPlayerPosition()
    {
        targetPosition = transform.position;
    }

    private void UpdatePlayerPosition()
    { 
        transform.position = targetPosition;
    }

    //funções relacionadas ao limite de movimento
    private void SetMoveCooldown()
    {
        currentCooldown = mvCooldown;
    }

    private void UpdateMoveCooldown()
    { 
        currentCooldown -= Time.deltaTime;
    }

    private bool CanMove()
    {
        if (currentCooldown > 0)
        {
            UpdateMoveCooldown();
            return false;
        }
        else
        {
            return true;
        }
    }

}
