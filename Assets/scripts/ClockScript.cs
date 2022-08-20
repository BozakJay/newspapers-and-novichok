using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockScript : MonoBehaviour
{
    public ClockScript clock;
    public float timeBetweenHour;
    public float hour = 10;
    public TextMeshProUGUI textObject;

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
            // TODO end of day

        } else
        {
            StartCoroutine(UpdateClock(timeBetweenHour));
        }
    }
}
