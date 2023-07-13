using Kaynir.Audio.Tools;
using UnityEngine;

namespace Kaynir.Audio.Modules
{
    [CreateAssetMenu(menuName = AssetMenuTools.VOLUME_MODULE_PATH)]
    public class RandomVolume : AudioModule
    {
        [SerializeField, Range(0f, 1f)] private float defaultValue = 1f;
        [SerializeField, Range(0f, .5f)] private float offsetValue = .2f;

        public override void Apply(AudioSource source)
        {
            source.volume = GetRandomValue();
        }

        private float GetRandomValue()
        {
            return Random.Range(defaultValue - offsetValue,
                                defaultValue);
        }
    }
}