using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page
{
    public string article1;
    public string article2;
    public string article3;
    public string article4;
    public GameObject image;

    public Page(string articleOne, string articleTwo, string articleThree, string articleFour)
    {
        article1 = articleOne;
        article2 = articleTwo;
        article3 = articleThree;
        article4 = articleFour;
    }
}
