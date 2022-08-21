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

    public void FinishDay()
    {

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
    }
}
