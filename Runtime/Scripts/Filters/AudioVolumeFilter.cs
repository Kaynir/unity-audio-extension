using Kaynir.Audio.Tools;
using UnityEngine;

namespace Kaynir.Audio.Filters
{
    [CreateAssetMenu(menuName = AssetMenuTools.FILTERS_PATH + "Volume Filter")]
    public class AudioVolumeFilter : AudioSourceFilter
    {
        [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0.8f, 1f, 1f);

        public override void Apply(AudioSource source, float scaleNormalized)
        {
            source.volume = curve.Evaluate(scaleNormalized);
        }
    }
}