using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public static AudioController instance;
    private AudioSource audioSource;
    private AudioSource auxAudioSource;

    [Header("Sounds")]
    public AudioClip playerShoot;
    public AudioClip bombExplosion;
    public AudioClip jetPack;


    void Start() {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        auxAudioSource = gameObject.AddComponent<AudioSource>();
        
    }

    public void Play(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }

    public void PlayLoopSound(AudioClip clip) {
        auxAudioSource.clip = clip;
        auxAudioSource.loop = true;
        auxAudioSource.volume = .5f;
        auxAudioSource.Play();
    }

    public void StopLoopSound() {
        if (auxAudioSource.isPlaying) {
            auxAudioSource.Stop();
        }
    }


}
