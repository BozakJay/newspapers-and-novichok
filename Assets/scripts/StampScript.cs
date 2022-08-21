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
            } else
            {
                transform.position = defaultPosition;
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
    }

    public void ClickArticle()
    {
        if (AboveArticle() == 0) return;

        audioSource.PlayOneShot(utils.RandomStampSound(), 1f);
    }

    private int AboveArticle()
    {
        if (-5.81f < transform.position.x && transform.position.x < 0)  // left hand side
        {
            if (0 < transform.position.x && transform.position.x < 4.45f)  // top left hand side
            {
                return 1;
            }
            if (-4.45f < transform.position.x && transform.position.x < 0)  // bottom left hand side
            {
                return 2;
            }
        }

        if (0f < transform.position.x && transform.position.x < 5.81)  // right hand side
        {
            if (0 < transform.position.x && transform.position.x < 4.45f)  // top right hand side
            {
                return 3;
            }
            if (-4.45f < transform.position.x && transform.position.x < 0)  // bottom right hand side
            {
                return 4;
            }
        }
        return 0;
    }
}
