using Kaynir.Audio.Tools;
using UnityEngine;

namespace Kaynir.Audio.Filters
{
    [CreateAssetMenu(menuName = AssetMenuTools.FILTERS_PATH + "Pitch Filter")]
    public class PitchFilter : SoundFilter
    {
        [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0f, .8f, 1f, 1.2f);

        public override void Apply(AudioSource source, float scaleNormalized)
        {
            source.pitch = curve.Evaluate(scaleNormalized);
        }
    }
}