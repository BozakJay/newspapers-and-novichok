using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page
{
    public string article1;
    public string article2;
    public string article3;
    public string article4;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public int score1;
    public int score2;
    public int score3;
    public int score4;

    public Page(string articleOne, string articleTwo, string articleThree, string articleFour,
                GameObject imageOne, GameObject imageTwo, GameObject imageThree, GameObject imageFour,
                int scoreOne, int scoreTwo, int scoreThree, int scoreFour)
    {
        article1 = articleOne;
        article2 = articleTwo;
        article3 = articleThree;
        article4 = articleFour;

        image1 = imageOne;
        image2 = imageTwo;
        image3 = imageThree;
        image4 = imageFour;

        score1 = scoreOne;
        score2 = scoreTwo;
        score3 = scoreThree;
        score4 = scoreFour;
    }
}
