using Kaynir.Audio.Tools;
using UnityEngine;

namespace Kaynir.Audio.Modules
{
    [CreateAssetMenu(menuName = AssetMenuTools.PITCH_MODULE_PATH)]
    public class RandomPitch : AudioModule
    {
        [SerializeField, Range(-3f, 3f)] private float defaultValue = 1f;
        [SerializeField, Range(0f, .5f)] private float offsetValue = .2f;

        public override void Apply(AudioSource source)
        {
            source.pitch = GetRandomValue();
        }

        private float GetRandomValue()
        {
            return Random.Range(defaultValue - offsetValue,
                                defaultValue + offsetValue);
        }
    }
}