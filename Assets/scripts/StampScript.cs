using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StampScript : MonoBehaviour, IPointerClickHandler
{
    public bool isTick;
    public bool isSelected;
    public StampScript otherStamp;
    private Vector3 defaultPosition;
    private AudioSource audioSource;
    public AudioClip stampSound;
    public float cooldownTime;
    private float cooldownTimeStamp;
    public Utilities utils;
    public GameObject article1;
    public GameObject article2;
    public GameObject article3;
    public GameObject article4;
    public GameObject tickMark;
    public GameObject crossMark;
    public PagesLeft pgl;

    private void Start()
    {
        defaultPosition = transform.position;
        audioSource = gameObject.GetComponent<AudioSource>();
        cooldownTimeStamp = Time.time;
    }

    public UnityEvent leftClick;
    public UnityEvent rightClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            leftClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rightClick.Invoke();
    }

    public void OnClickStamp(bool leftClick)
    {
        if (leftClick) {
            if (Time.time <= cooldownTimeStamp) return;
            cooldownTimeStamp = Time.time + cooldownTime;

            if (isSelected)  // left click -> use the stamp
            {
                // TODO what stamp does when used
                ClickArticle();

            } else  // left click -> select the stamp
            {
                isSelected = true;
                cooldownTimeStamp = Time.time;
            }

        } else  // right click -> put down stamp  TODO THIS IS BROKEN SOMEHOW (works on right side only)
        {
            isSelected = false;

            if (isTick)
            {
                transform.position = defaultPosition;
                article1.transform.GetChild(1).gameObject.SetActive(false);
                article2.transform.GetChild(1).gameObject.SetActive(false);
                article3.transform.GetChild(1).gameObject.SetActive(false);
                article4.transform.GetChild(1).gameObject.SetActive(false);
            } else
            {
                transform.position = defaultPosition;
                article1.transform.GetChild(1).gameObject.SetActive(false);
                article2.transform.GetChild(1).gameObject.SetActive(false);
                article3.transform.GetChild(1).gameObject.SetActive(false);
                article4.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        // if the stamp is selected, chase the mouse

        if (!isSelected) return;

        Vector2 mousePos = Input.mousePosition;
        Vector2 newPoint = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = newPoint;

        GameObject article = AboveArticle();  // check if above article
        article1.transform.GetChild(1).gameObject.SetActive(false);
        article2.transform.GetChild(1).gameObject.SetActive(false);
        article3.transform.GetChild(1).gameObject.SetActive(false);
        article4.transform.GetChild(1).gameObject.SetActive(false);

        if (article != null)
        {
            article.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ClickArticle()
    {
        GameObject article = AboveArticle();  // check if above article
        if (article == null) return;

        if (article.GetComponent<ArticleScript>().isStamped) return;

        article.transform.GetChild(1).gameObject.SetActive(true);

        // article.GetComponent<ArticleScript>().articleNum

        audioSource.PlayOneShot(utils.RandomStampSound(), 1f);

        if (isTick)
        {
            Instantiate(tickMark, transform.position, Quaternion.identity);
        } else
        {
            Instantiate(crossMark, transform.position, Quaternion.identity);
            if (article.GetComponent<ArticleScript>().articleNum == 1)
            {
                pgl.activePage.score1 = 0;
            }
            if (article.GetComponent<ArticleScript>().articleNum == 2)
            {
                pgl.activePage.score2 = 0;
            }
            if (article.GetComponent<ArticleScript>().articleNum == 3)
            {
                pgl.activePage.score3 = 0;
            }
            if (article.GetComponent<ArticleScript>().articleNum == 4)
            {
                pgl.activePage.score4 = 0;
            }
        }

        article.GetComponent<ArticleScript>().isStamped = true;
    }

    private GameObject AboveArticle()
    {
        if (-5.81f < transform.position.x && transform.position.x < 0)  // left hand side
        {
            if (0 < transform.position.y && transform.position.y < 4.45f)  // top left hand side
            {
                return article1;
            }
            if (-4.45f < transform.position.y && transform.position.y < 0)  // bottom left hand side
            {
                return article2;
            }
        }

        if (0f < transform.position.x && transform.position.x < 5.81)  // right hand side
        {
            if (0 < transform.position.y && transform.position.y < 4.45f)  // top right hand side
            {
                return article3;
            }
            if (-4.45f < transform.position.y && transform.position.y < 0)  // bottom right hand side
            {
                return article4;
            }
        }
        return null;
    }
}
