using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgerMinigame : MonoBehaviour
{
    public GameObject minigamePanel;

    public void Clicked()
    {
        if (minigamePanel.activeSelf)
        {
            EndMinigame();
        }
        else
        {
            StartMinigame();
        }
    }

    public void StartMinigame()
    {
        minigamePanel.SetActive(true);
    }

    public void EndMinigame()
    {
        minigamePanel.SetActive(false);
    }
}
