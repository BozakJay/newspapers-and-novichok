using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockScript : MonoBehaviour
{
    private ClockScript clock;
    public float timeBetweenHour;
    public float hour = 10;
    private TextMeshProUGUI textObject;
    public PagesLeft pagesLeft;

    private void Start()
    {
        clock = gameObject.GetComponent<ClockScript>();
        textObject = gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(UpdateClock(timeBetweenHour));
    }

    IEnumerator UpdateClock(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        hour += 1;
        string hourText = hour.ToString();
        if (hourText.Length == 1)
        {
            hourText = "0" + hourText;
        }

        textObject.text = hourText + ":00";

        if (hour == 17)  // end day at 17:00
        {
            FinishDay();

        } else
        {
            StartCoroutine(UpdateClock(timeBetweenHour));
        }
    }


    public GameObject g;
    public void FinishDay()
    {
        if (g.activeSelf) return;


        // refill the tray for next day
        switch (GameData.week)
        {
            case 0:
                pagesLeft.FillTray(4);
                break;
            case 1:
                pagesLeft.FillTray(5);
                break;
            case 2:
                pagesLeft.FillTray(6);
                break;
        }

        g.SetActive(true);
        g.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Score: " + Score.gameScore;

        int totalScore = 0;
        foreach (Page p in pagesLeft.pages)
        {
            totalScore += p.score1 + p.score2 + p.score3 + p.score4;
        }

        Score.gameScore += totalScore;

        StartCoroutine(RemoveScore(3f));
    }

    IEnumerator RemoveScore(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        g.SetActive(false);
    }
}
