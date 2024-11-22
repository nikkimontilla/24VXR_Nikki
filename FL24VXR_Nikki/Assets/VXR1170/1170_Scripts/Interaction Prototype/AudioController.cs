using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioPlayer;
    public void PlayAudio()
    {
        audioPlayer.Play();
    }
}
