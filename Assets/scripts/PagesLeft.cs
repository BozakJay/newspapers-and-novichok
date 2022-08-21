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
    public TextMeshProUGUI article1Text;
    public TextMeshProUGUI article2Text;
    public TextMeshProUGUI article3Text;
    public TextMeshProUGUI article4Text;
    public Utilities utils;
    public ClockScript clock;

    private void Start()
    {
        for (int i = 0; i < maxPages; i++)
        {
            pageObjects.Add(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < startingPages; i++)
        {
            pages.Add(new Page(utils.RandomString(400), utils.RandomString(400), utils.RandomString(400), utils.RandomString(400)));
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
        //if (activePage != null) activePage.image.SetActive(false);

        if (pages.Count == 0)
        {
            clock.FinishDay();
            return;
        }

        activePage = pages[pages.Count-1];
        pages.Remove(pages[pages.Count-1]);
        pageObjects[pages.Count].SetActive(false);
        article1Text.text = activePage.article1;
        article2Text.text = activePage.article2;
        article3Text.text = activePage.article3;
        article4Text.text = activePage.article4;
        // activePage.image.SetActive(true);
    }
    
    public void ReturnPageToTray()
    {
        if (activePage == null) return;

        // activePage.image.SetActive(false);
        pages.Add(activePage);
        pageObjects[pages.Count - 1].SetActive(true);
        activePage = null;
        article1Text.text = "";
        article2Text.text = "";
        article3Text.text = "";
        article4Text.text = "";
    }

    public void FillTray(int numberOfPages)
    {
        pages = new List<Page>();  // reset pages

        for (int i = 0; i < numberOfPages; i++)
        {
            pages.Add(new Page(utils.RandomString(400), utils.RandomString(400), utils.RandomString(400), utils.RandomString(400)));
        }

        for (int i = 0; i < pages.Count; i++)
        {
            pageObjects[i].SetActive(true);
        }
    }
}
