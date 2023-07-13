using UnityEngine;

namespace Kaynir.Audio.Modules
{
    public abstract class AudioModule : ScriptableObject
    {
        public abstract void Apply(AudioSource source);
    }
}