using UnityEngine;
using UnityEngine.Audio;

namespace Kaynir.Audio
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Audio/Audio Channel")]
    public class AudioChannel : ScriptableObject
    {
        [SerializeField] private AudioMixerGroup _mixerGroup = null;
        [SerializeField] private string _volumeID = "Master";

        public AudioMixerGroup MixerGroup => _mixerGroup;
        public string VolumeID => _volumeID;

        public void SetVolume(float volume)
        {
            _mixerGroup.audioMixer.SetVolume(_volumeID, volume);
        }

        public float GetVolume()
        {
            return _mixerGroup.audioMixer.GetVolume(_volumeID);
        }
    }
}