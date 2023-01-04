using UnityEngine;
using static Kaynir.Audio.AudioSystem;

namespace Kaynir.Audio
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Audio/Sound Collection")]
    public class SoundCollection : ScriptableObject
    {
        public static event AudioEventHandler OnSourceRequested;

        [SerializeField] private AudioChannel _channel = null;
        [SerializeField] private AudioClip[] _clipVariations = null;
        
        [Header("Volume Settings:")]
        [SerializeField, Range(0f, 1f)] private float _defaultVolume = 1f;
        [SerializeField, Range(0f, .5f)] private float _volumeOffset = .2f;
        [SerializeField] private bool _randomizeVolume = false;

        [Header("Pitch Settings:")]
        [SerializeField, Range(-3f, 3f)] private float _defaultPitch = 1f;
        [SerializeField, Range(0f, .5f)] private float _pitchOffset = .15f;
        [SerializeField] private bool _randomizePitch = false;

        [ContextMenu("Play Sound")]
        public void PlaySound()
        {
            AudioSource source = OnSourceRequested?.Invoke(_channel);
            if (source) PlaySound(source);
        }

        private void PlaySound(AudioSource source)
        {
            source.volume = GetVolume();
            source.pitch = GetPitch();
            source.PlayOneShot(GetAudioClip());
        }

        private float GetVolume()
        {
            return _randomizeVolume 
            ? GetRandomValue(_defaultVolume, _volumeOffset)
            : _defaultVolume;
        }

        private float GetPitch()
        {
            return _randomizePitch 
            ? GetRandomValue(_defaultPitch, _pitchOffset)
            : _defaultPitch;
        }
        
        private float GetRandomValue(float value, float offset)
        {
            return Random.Range(value - offset, value + offset);
        }

        private AudioClip GetAudioClip()
        {
            return _clipVariations.Length > 1 
            ? _clipVariations[Random.Range(0, _clipVariations.Length)]
            : _clipVariations[0];
        }
    }
}