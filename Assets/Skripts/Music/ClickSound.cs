using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound()
    {
        _audioSource.Stop();
        _audioSource.Play();
    }
}
