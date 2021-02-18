using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    public TextMeshProUGUI text; //Text to change in the lose scene

    private void Start()
    {
        if (text)
        {
            ChangeLoseText();
        }
    }

    private void ChangeLoseText()
    {
        text.text = GameManager.instance.GetChosenWord();
    }

    public void LoadScene(string s)
    {
        GameManager.instance.LoadScene(s);
    }
}
