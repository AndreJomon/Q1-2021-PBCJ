using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcaManager : MonoBehaviour
{

    public int missCount = 0;
    public int tryLimit = 15;
    public GameObject wordManager;
    public TryManager tryManager;
    private char lastChar = ' '; // Control to not let the player hold the button and lose automatically

    private void Start()
    {
        tryManager.InstatiatePoints(tryLimit);
    }

    private void Update()
    {
        WordManager wordManagerScript = wordManager.GetComponent<WordManager>();
        foreach (char c in Input.inputString)
        {
            if (c != lastChar)
            {
                lastChar = c;
                if (!wordManagerScript.InputLetter(c))
                {
                    if (tryManager.Miss())
                    {
                        Debug.Log("PERDEU");
                    }
                }
                if (wordManagerScript.CorrectWord())
                {
                    Debug.Log("GANHOU");
                }
            }
        }
    }
}
