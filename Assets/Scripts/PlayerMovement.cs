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
        targetPosition += direction * stepSize;
        UpdatePlayerPosition();
        SetMoveCooldown();
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
