using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryManager : MonoBehaviour
{
    public GameObject point;
    public GameObject pointRespawn;
    private List<Point> pointScript = new List<Point>();
    private int lastMiss = 0;
    public void InstatiatePoints(int n)
    {
        for (int i = 0; i<n; i++)
        {
            GameObject pointTemp = Instantiate(point, pointRespawn.transform);
            pointScript.Add(pointTemp.GetComponent<Point>());
        }
    }

    /// <summary>
    /// Do the miss change and if was the last miss return true.
    /// </summary>
    /// <returns></returns>
    public bool Miss()
    {
        if (lastMiss == pointScript.Count)
        {
            return true;
        } else
        {
            pointScript[pointScript.Count-lastMiss-1].WrongGuess();
            lastMiss++;
            return false;
        }
    }
}
