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

    //variáveis controladoras de funções 
    private string read = "r";
    private string update = "u";
    private string set = "s";

    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition(read);
        MoveCooldown(set);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove(currentCooldown)) //se o cooldown está zerado, permite movimento
        {
            PlayerMove();
        }
        PlayerPosition(read); //sempre recalcula onde o jogador está
    }

    private void PlayerMove()
    {

        /* a ideia de colocar um return em cada if é evitar o movimento
         * completamente diagonal do jogador. */

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPosition += Vector2.up * stepSize;
            PlayerPosition(update);
            MoveCooldown(set);
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPosition += Vector2.down * stepSize;
            PlayerPosition(update);
            MoveCooldown(set);
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { 
            targetPosition += Vector2.left * stepSize;
            PlayerPosition(update);
            MoveCooldown(set);
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPosition += Vector2.right * stepSize;
            PlayerPosition(update);
            MoveCooldown(set);
            return;
        }
    }

    private void PlayerPosition(string objective)
    {
        if (objective == read)
        {
            targetPosition = transform.position;
            return;
        }
        if (objective == update)
        {
            transform.position = targetPosition;
            return;
        }
    }

    private void MoveCooldown(string objective)
    {
        if (objective == set)
        {
            currentCooldown = mvCooldown;
        }
        if (objective == update)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private bool CanMove(float cd)
    {
        if (cd > 0)
        {
            MoveCooldown(update);
            return false;
        }
        else
        {
            return true;
        }
    }

}
