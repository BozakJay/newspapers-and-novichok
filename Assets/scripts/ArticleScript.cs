using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleScript : MonoBehaviour
{
    public StampScript yesStamp;
    public StampScript noStamp;

    public void ClickArticle(int articleNumber)
    {
        if (yesStamp.isSelected)
        {
            Debug.Log("yes");
        } else if (noStamp.isSelected)
        {
            Debug.Log("no");
        }
    }
}
