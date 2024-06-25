using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextLevelScreen : MonoBehaviour
{
    public GameObject nextLevelUI;

    private void Start()
    {
        if (nextLevelUI != null)
        {
            nextLevelUI.SetActive(false);
        }
    }

    public void CallNextLevelScreen(bool check)
    {
        nextLevelUI.GetComponent<TextMeshProUGUI>().text = "Congratulations!";
        nextLevelUI.SetActive(check);
    }
}
