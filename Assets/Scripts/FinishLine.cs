using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameObject controller;
    private float playerPosy;

    private void Start()
    {
        //encontra o gerenciador do jogo
        controller = GameObject.FindWithTag("GameController");
    }

    void Update()
    {
        //se a posição y do jogador for igual a última lane, aciona a tela de próximo nível
        playerPosy = GameObject.FindWithTag("Player").transform.position.y;
        if (playerPosy >= 4.5f)
        {
            controller.GetComponent<NextLevelScreen>().CallNextLevelScreen(true);
            controller.GetComponent<ScoreManager>().AddScore();
            controller.GetComponent<ScoreManager>().ScoreBoardUpdate();
        }
    }
}
