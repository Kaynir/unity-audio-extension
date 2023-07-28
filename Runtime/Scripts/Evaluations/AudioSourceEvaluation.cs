using System.Collections.Generic;
using Kaynir.Audio.Filters;
using UnityEngine;

namespace Kaynir.Audio.Evaluations
{
    public class AudioSourceEvaluation : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource = null;
        [SerializeField] private EvaluationSignal evaluationSource = null;
        [SerializeField] private List<SoundFilter> filters = new List<SoundFilter>();

        private void OnEnable()
        {
            evaluationSource.NormalizedValueChanged += ApplyFilters;
            ApplyFilters(evaluationSource.NormalizedValue);
        }

        private void OnDisable()
        {
            evaluationSource.NormalizedValueChanged -= ApplyFilters;
        }

        private void ApplyFilters(float scaleNormalized)
        {
            filters.ForEach(f => f.Apply(audioSource, scaleNormalized));
        }
    }
}