using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PagesLeft : MonoBehaviour
{
    private List<GameObject> pageObjects  = new List<GameObject>();
    private List<Page> pages = new List<Page>();
    public int maxPages;
    public int startingPages;
    public Page activePage;
    public TextMeshProUGUI newspaperText;
    public Utilities utils;

    private void Start()
    {
        for (int i = 0; i < maxPages; i++)
        {
            pageObjects.Add(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < startingPages; i++)
        {
            pages.Add(new Page(utils.RandomString(400), utils.RandomNewsImage()));
        }

        foreach (GameObject pageObject in pageObjects)
        {
            pageObject.SetActive(false);
        }

        for (int i = 0; i < pages.Count; i++)
        {
            pageObjects[i].SetActive(true);
        }
    }

    public void RemovePageFromTray()
    {
        if (activePage != null) activePage.image.SetActive(false);

        activePage = pages[pages.Count-1];
        pages.Remove(pages[pages.Count-1]);
        pageObjects[pages.Count].SetActive(false);
        newspaperText.text = activePage.text;
        activePage.image.SetActive(true);
    }
    
    public void ReturnPageToTray()
    {
        if (activePage == null) return;

        activePage.image.SetActive(false);
        pages.Add(activePage);
        pageObjects[pages.Count - 1].SetActive(true);
        activePage = null;
        newspaperText.text = "";
    }
}
