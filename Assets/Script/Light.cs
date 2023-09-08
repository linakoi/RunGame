using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public AudioClip audioClip1;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        
    }

}


