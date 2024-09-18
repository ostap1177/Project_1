using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class MuteSound : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private string _mixerName;
    
    private bool isClicked;
    private int _minValue = -80;
    private int _maxValue = 0;

    public event UnityAction <bool> IsMuted;

    public void OnMute()
    {
        if (GetClicked() == true)
        {
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, _minValue);
            IsMuted?.Invoke(true);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, _maxValue);
            IsMuted?.Invoke(false);
        }
    }

    private bool GetClicked()
    {
        return isClicked = !isClicked;
    }
}
