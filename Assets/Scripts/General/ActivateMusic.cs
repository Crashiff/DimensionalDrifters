using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMusic : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject[] audioSources = GameObject.FindGameObjectsWithTag("music");
        Debug.Log(audioSources.Length);
        if (audioSources.Length == 1)
        {
            Debug.Log("active!");
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
