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

    void Start()
    {
        ReadPlayerPosition();
        SetMoveCooldown();
    }

    void Update()
    {
        if (CanMove()) //se o cooldown está zerado, permite movimento
        {
            HandleMovement();
        }
        ReadPlayerPosition(); //sempre recalcula onde o jogador está
    }

    //operação principal de movimento
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

    //verifica se o jogador está dentro do limite do cenário
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

    //define a target position como a posição atual do jogador
    private void ReadPlayerPosition()
    {
        targetPosition = transform.position;
    }

    //move o jogador para a targetposition
    private void UpdatePlayerPosition()
    { 
        transform.position = targetPosition;
    }

    //funções relacionadas ao limite de movimento
    private void SetMoveCooldown()
    {
        currentCooldown = mvCooldown;
    }

    //diminui o tempo que passou do cooldown
    private void UpdateMoveCooldown()
    {
        currentCooldown -= Time.deltaTime;
    }


    // verifica se o jogador pode se mover
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
