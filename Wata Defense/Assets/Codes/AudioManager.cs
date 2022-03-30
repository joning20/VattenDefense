using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource CashSound;
    public AudioSource ExplosionSound;
    public AudioSource NetSound;
    public AudioSource BubbleSound;
    public AudioSource RiverSound;
    public AudioSource SplashSound;

    [SerializeField] AudioMixer audioMixer;

    public void PlayCashSound()
    {
        CashSound.pitch = Mathf.Lerp(1f, 1.3f, Random.value);

        CashSound.Play();
    }

    public void PlayNetSound()
    {
        NetSound.Play();
    }

    public void PlayBubbleSound()
    {
        BubbleSound.pitch = Mathf.Lerp(0.5f, 2f, Random.value);

        BubbleSound.Play();
    }

    public void PlayRiverSound()
    {
        RiverSound.Play();
    }

    public void PlaySplashSound()
    {
        SplashSound.pitch = Mathf.Lerp(0.5f, 2f, Random.value);

        SplashSound.Play();
    }
}
