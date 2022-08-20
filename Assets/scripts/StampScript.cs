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

    private void Start()
    {
        defaultPosition = transform.position;
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
            if (isSelected)  // left click -> use the stamp
            {
                // TODO what stamp does when used

            } else  // left click -> select the stamp
            {
                isSelected = true;
            }

        } else  // right click -> put down stamp
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
}
