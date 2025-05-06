using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BoxMaker : MonoBehaviour
{
    float veryLeft,veryRight,veryTop,veryBottom;

    Vector2 callBox;
    Vector2 pos;

    public float initXOffset;
    public float xOffset;
    public float leewayXOffset;
    public float initYOffset;
    public float yOffset;
    int indentX;

    public GameObject[] selectBoxes;

    void Start()
    {
        SetMinAndMax();
        MakeBoxes();
    }

    void SetMinAndMax()
    {
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        veryLeft = -Bounds.x;
        veryRight = Bounds.x;
        veryTop = -Bounds.y;
        veryBottom = Bounds.y;
    }

    void MakeBoxes()
    {
        for(int i = 0; i < selectBoxes.Length; i++)
        {
            indentX += (i * 0) + 1;
            callBox.x = veryLeft + initXOffset + (indentX * xOffset);

            if (callBox.x + leewayXOffset > veryRight)
            {
                yOffset -= 2;
                indentX = 1;
                callBox.x = veryLeft + initXOffset + (indentX * xOffset);
            }

            pos = new Vector2(callBox.x, yOffset);
            Instantiate(selectBoxes[i], pos, Quaternion.identity);
        }

        print("boxes should've been made");
    }
}
