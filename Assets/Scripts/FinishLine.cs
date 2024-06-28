using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameObject controller;
    private float playerPosy;
    private bool finishedLevel;

    private void Start()
    {
        finishedLevel = false;
        //encontra o gerenciador do jogo, já que ele será o responsável pelos outros scripts
        controller = GameObject.FindWithTag("GameController");
    }

    void Update()
    {
        //se a posição y do jogador for igual a última lane, aciona a tela de próximo nível
        playerPosy = GameObject.FindWithTag("Player").transform.position.y;
        if (playerPosy >= 4.5f && !finishedLevel)
        {
            finishedLevel = true;
            controller.GetComponent<ScoreManager>().AddScore();
            controller.GetComponent<NextLevelScreen>().CallNextLevelScreen(true);
            controller.GetComponent<ScoreManager>().ScoreBoardUpdate();
        }
    }
}
