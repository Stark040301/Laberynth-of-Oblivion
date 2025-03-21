using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios; // Array of audio clips
    private AudioSource controlAudio;
    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    public void SelectAudio(int index, float volume)
    {
        controlAudio.PlayOneShot(audios[index], volume);
    }
}
