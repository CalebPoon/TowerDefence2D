﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardViewManager : MonoBehaviour {

    public GameObject cardGroup;
	
    bool clicked = false;
    Vector3 prevMousePos;

    float cardWidth = 380;
    float slotWidth = 400;

    int maxLevel;
    public int selectedLevel = 0;

    float leftMargin;
    float rightMargin;

    void Awake()
    {
        maxLevel = cardGroup.transform.childCount;
        leftMargin = cardWidth / 2;
        rightMargin = -((cardWidth / 2) + slotWidth * (maxLevel-1));
    }

    void Update()
    {
        if (!clicked)
        {
            float slotCenX = -selectedLevel * slotWidth;
            Vector3 targetPos = new Vector3(slotCenX, 0, 0);
//            Debug.Log(targetPos);
            cardGroup.GetComponent<RectTransform>().localPosition = 
                Vector3.MoveTowards(cardGroup.GetComponent<RectTransform>().localPosition, targetPos, Time.deltaTime * 400f);
        }
    }

    void OnMouseDown()
    {
        prevMousePos = Input.mousePosition;
        clicked = true;
    }

    void OnMouseDrag()
    {
        Vector3 diff = Input.mousePosition - prevMousePos;
        prevMousePos = Input.mousePosition;


        cardGroup.GetComponent<RectTransform>().localPosition += new Vector3(diff.x, 0, 0);

        float x = cardGroup.GetComponent<RectTransform>().localPosition.x;

        if (x > leftMargin)
        {
            cardGroup.GetComponent<RectTransform>().localPosition = new Vector3(leftMargin, 0, 0);
            x = cardGroup.GetComponent<RectTransform>().localPosition.x;
        }

        if (x < rightMargin)
        {
            cardGroup.GetComponent<RectTransform>().localPosition = new Vector3(rightMargin, 0, 0);
            x = cardGroup.GetComponent<RectTransform>().localPosition.x;
        }

        selectedLevel = -(int)Mathf.Round(x / slotWidth);
//        Debug.Log("Selected: " + selectedLevel);
    }

    void OnMouseUp()
    {
        clicked = false;
    }
}
