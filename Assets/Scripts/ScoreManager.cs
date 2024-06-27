using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int curScore;
    public GameObject scoreBoard;

    private void Start()
    {
        curScore = 0;
    }

    public void AddScore()
    {
        curScore += 1;
    }

    public void ScoreBoardUpdate()
    {
        scoreBoard.GetComponent<TextMeshProUGUI>().text = curScore.ToString("000");
    }
}
