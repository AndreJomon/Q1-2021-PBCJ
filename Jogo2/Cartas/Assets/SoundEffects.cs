using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    public AudioSource audioSource;
    public static SoundEffects instance;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
        } else
        {
            Destroy(this);
            return;
        }
    }

    public void PlayCorrect()
    {
        audioSource.clip = correctAnswer;
        audioSource.Play();
    }

    public void PlayWrong()
    {
        audioSource.clip = wrongAnswer;
        audioSource.Play();
    }
}
