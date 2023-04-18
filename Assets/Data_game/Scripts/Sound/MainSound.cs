using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip moCua;
    
    private void Start()
    {
        AudioMoCua();
    }
    public void AudioMoCua()
    {
        audioSource.PlayOneShot(moCua);
    }

}
