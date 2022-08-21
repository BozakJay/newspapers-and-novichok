using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public List<AudioClip> stampSounds;
    public List<GameObject> newsImages;

    public string RandomString(int length)
    {
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string text = "";

        for (int i = 0; i < length; i++)
            text += characters[Random.Range(0, 36)];

        return text;
    }

    public AudioClip RandomStampSound()
    {
        return stampSounds[Random.Range(0, stampSounds.Count)];
    }

    public GameObject RandomNewsImage()
    {
        return newsImages[Random.Range(0, newsImages.Count)];
    }
}
