using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page
{
    public string text;
    public GameObject image;

    public Page(string newText, GameObject newImage)
    {
        text = newText;
        image = newImage;
    }
}
