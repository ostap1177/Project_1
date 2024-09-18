using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersSound : MonoBehaviour
{
    [SerializeField] CoinCreator _coinCreator;
    [SerializeField] AudioSource _audioSourceHit;


    private void OnEnable()
    {
        _coinCreator.PlayedSound += OnPlayedSound;
    }

    private void OnDisable()
    {
        _coinCreator.PlayedSound += OnPlayedSound;
    }

    private void OnPlayedSound()
    {
        PlaySound(_audioSourceHit);
    }

    private void PlaySound(AudioSource audioSource)
    {
        audioSource.Stop();
        audioSource.Play();
    }
}
