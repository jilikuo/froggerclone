using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameObject controller;
    private float playerPosy;

    private void Start()
    {
        controller = GameObject.FindWithTag("GameController");
    }

    void Update()
    {
        playerPosy = GameObject.FindWithTag("Player").transform.position.y;
        if (playerPosy >= 4.5f)
        {
            controller.GetComponent<NextLevelScreen>().CallNextLevelScreen(true);
        }
    }
}
