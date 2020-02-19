using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomBirdSound : MonoBehaviour
{
    public AudioClip[] birdSounds;

    void Start()
    {
        int randSound = Random.Range(0, 9);
        PlaySound(randSound);
        StartCoroutine(DestroySelf());
    }

    void PlaySound (int clip)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = birdSounds[clip];
        audio.PlayOneShot(audio.clip, 0.8f);
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(4);
        Destroy (gameObject);
    }
}
