using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public static AudioController instance;
    private AudioSource audioSource;

    [Header("Sounds")]
    public AudioClip playerShoot;    
    public AudioClip bombExplosion;
   

    void Start() {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip) {
        audioSource.PlayOneShot(clip);        
    }


}
