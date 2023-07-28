using UnityEngine;

namespace Kaynir.Audio.Filters
{
    public abstract class AudioSourceFilter : ScriptableObject
    {
        public abstract void Apply(AudioSource source, float scaleNormalized);
        
        public void Apply(AudioSource source)
        {
            Apply(source, GetRandomScale());
        }

        private float GetRandomScale()
        {
            return Random.value;
        }
    }
}