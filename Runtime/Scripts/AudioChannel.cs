using UnityEngine;
using UnityEngine.Audio;

namespace Kaynir.Audio
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Audio/Audio Channel")]
    public class AudioChannel : ScriptableObject
    {
        [SerializeField] private AudioMixerGroup _mixerGroup = null;
        [SerializeField] private string _volumeParameter = "MasterVolume";

        public AudioMixerGroup MixerGroup => _mixerGroup;

        public void SetVolume(float volume)
        {
            _mixerGroup.audioMixer.SetVolume(_volumeParameter, volume);
        }

        public float GetVolume()
        {
            return _mixerGroup.audioMixer.GetVolume(_volumeParameter);
        }

        public void Mute(bool isMuted)
        {
            SetVolume(isMuted
            ? AudioConstants.MIN_VOLUME
            : AudioConstants.MAX_VOLUME);
        }
    }
}