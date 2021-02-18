using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public Image selfImage;
    private bool pointUsed = false;

    public void WrongGuess()
    {
        Color32 color = selfImage.color;
        color = new Color32(color.r, color.g, color.b, 100);
        selfImage.color = color;
        pointUsed = true;
    }

    public bool PointUsed()
    {
        return pointUsed;
    }
}
