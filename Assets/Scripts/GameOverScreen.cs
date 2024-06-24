using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    public void CallGameOverScreen(bool check)
    {
        gameOverUI.GetComponent<TextMeshProUGUI>().text = "Game Over"; 
        gameOverUI.SetActive(check);
    }
}
