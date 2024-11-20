using System;
using Ui;
using UnityEngine;
using UnityEngine.Audio;

namespace Ui
{
    public class MuteButton : ParentButtons
    {
        [SerializeField] private MusicObject _musicObject;

        /*[SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private string _mixerName;*/

        private bool isClicked;
       /* private int _minValue = -80;
        private int _maxValue = 0;*/

        public event Action<bool> IsMuted;

/*        public void SetValume(float value)
        {
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, value);
        }
*/
        protected override void Click()
        {
            if (GetClicked() == true)
            {
                _musicObject.MuteOnGame();
                IsMuted?.Invoke(true);
            }
            else
            {
                _musicObject.PlayOnGame();
                IsMuted?.Invoke(false);
            }
        }

        private bool GetClicked()
        {
            return isClicked = !isClicked;
        }
    }
}