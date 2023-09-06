using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMusic : MonoBehaviour
{
    static bool isPlaying = false;
    private AudioSource audioSource;
    // Start is called before the first frame update

    private void Awake()
    {
        if(!isPlaying)
        {
            isPlaying = true;
        } 
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject[] audioSources = GameObject.FindGameObjectsWithTag("music");
        Debug.Log("hi" + audioSources.Length);

        if (audioSources.Length == 1)
        {
            audioSource.Play();
        }
    }
}
