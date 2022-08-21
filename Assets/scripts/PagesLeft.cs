using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PagesLeft : MonoBehaviour
{
    private List<GameObject> pageObjects  = new List<GameObject>();
    public List<Page> pages = new List<Page>();
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
            pages.Add(MakeNewPage(0.7f));
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

        article1Text.transform.parent.gameObject.GetComponent<ArticleScript>().isStamped = false;
        article2Text.transform.parent.gameObject.GetComponent<ArticleScript>().isStamped = false;
        article3Text.transform.parent.gameObject.GetComponent<ArticleScript>().isStamped = false;
        article4Text.transform.parent.gameObject.GetComponent<ArticleScript>().isStamped = false;

        foreach (GameObject articleImg in GameObject.FindGameObjectsWithTag("articleImage"))
        {
            Destroy(articleImg);
        }

        Instantiate(activePage.image1, new Vector3(-2.39f, 0.95f, 0), Quaternion.identity);
        Instantiate(activePage.image2, new Vector3(-2.39f, -3.32f, 0), Quaternion.identity);
        Instantiate(activePage.image3, new Vector3(3.53f, 0.95f, 0), Quaternion.identity);
        Instantiate(activePage.image4, new Vector3(3.53f, -3.32f, 0), Quaternion.identity);

        // activePage.image.SetActive(true);

        GameObject[] marks = GameObject.FindGameObjectsWithTag("stampMark");
        if (marks != null)
        {
            foreach (GameObject mark in marks)
            {
                Destroy(mark);
            }
        }
    }
    
    public void ReturnPageToTray()
    {
        return;
        if (activePage == null) return;

        // activePage.image.SetActive(false);
        pages.Add(activePage);
        pageObjects[pages.Count - 1].SetActive(true);
        activePage = null;
        article1Text.text = "";
        article2Text.text = "";
        article3Text.text = "";
        article4Text.text = "";

        foreach (GameObject articleImg in GameObject.FindGameObjectsWithTag("articleImage"))
        {
            Destroy(articleImg);
        }
    }

    public void FillTray(int numberOfPages)
    {
        pages = new List<Page>();  // reset pages

        for (int i = 0; i < numberOfPages; i++)
        {
            pages.Add(MakeNewPage(0.7f));
        }

        for (int i = 0; i < pages.Count; i++)
        {
            pageObjects[i].SetActive(true);
        }
    }

    public GameObject[] badImages;
    public GameObject[] goodImages;

    private Page MakeNewPage(float chanceOfBad)
    {
        (string, GameObject, int) article1 = RandomArticle(chanceOfBad);
        (string, GameObject, int) article2 = RandomArticle(chanceOfBad);
        (string, GameObject, int) article3 = RandomArticle(chanceOfBad);
        (string, GameObject, int) article4 = RandomArticle(chanceOfBad);

        return new Page(article1.Item1, article2.Item1, article3.Item1, article4.Item1, article1.Item2, article2.Item2, article3.Item2, article4.Item2, article1.Item3, article2.Item3, article3.Item3, article4.Item3);
    }

    private (string, GameObject, int) RandomArticle(float chanceOfBad)
    {
        string[] badTitles = { "Explosion Kills 38 in Regir Region", "Serial Killer Strikes Again!", "Economy Drops By 8%", "Man, 51, Killed By Son", "Women Robbed Of Apples!", "Homeless Population To Increase By 20%", "Terrorist Attack in Croya Region!", "Crime Rates Rising Faster Than Past 30 Years", "Shop Broken Into", "Senka Bank Fraud Cases Come To Light", "President Orders Another Attack on Burnamoy!", "Man Killed In Hit And Run", "Kittens Murdered By Pyschopath!", "Famine in Greyage Region" };
        int[] badScores = { -3, -2, -3, -2, -1, -1, -3, -2, -1, -2, -3, -1, -1, -3 };

        string[] goodTitles = { "New Bakery Opens!", "Man Saves Boy From  Drowning", "War Going Well!", "Man Wins Lottery, Donates To Orphanage!", "Kittens Rescued From Abuse!", "Highest Grain Yields In 5 Years!", "Woman Turns 100!", "Terrorists Caught!", "President Meets With Leader Of Guhna" };
        int[] goodScores = { 2, 1, 3, 2, 2, 3, 1, 3, 3 };

        string title;
        GameObject gO;
        int sc;

        if (Random.Range(0, 1) < chanceOfBad)
        {
            int choice = Random.Range(0, 14);
            title = badTitles[choice];
            gO = badImages[choice];
            sc = badScores[choice];
        }
        else
        {
            int choice = Random.Range(0, 9);
            title = goodTitles[choice];
            gO = goodImages[choice];
            sc = goodScores[choice];
        }

        return (title, gO, sc);
    }
}
