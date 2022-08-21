using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page
{
    public string text;
    public GameObject image;
    public int score;

    public Page(string newText, GameObject newImage)
    {
        text = newText;
        image = newImage;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
