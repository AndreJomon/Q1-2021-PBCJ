using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    GameManager gameManager;
    public void Start()
    {
        gameManager = GameManager.instance;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
