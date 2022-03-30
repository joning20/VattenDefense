using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource CashSound;
    public AudioSource ExplosionSound;

    [SerializeField] AudioMixer audioMixer;

    public void PlayCashSound()
    {
        CashSound.Play();
    }

  
}
