using System.Collections.Generic;
using Kaynir.Audio.Filters;
using UnityEngine;

namespace Kaynir.Audio.Evaluations
{
    public class AudioSourceEvaluation : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource = null;
        [SerializeField] private EvaluationSignal evaluationSignal = null;
        [SerializeField] private List<AudioSourceFilter> filters = new List<AudioSourceFilter>();

        private void OnEnable()
        {
            evaluationSignal.Processed += OnSignalProcessed;
            OnSignalProcessed(evaluationSignal.GetEvaluationInfo());
        }

        private void OnDisable()
        {
            evaluationSignal.Processed -= OnSignalProcessed;
        }

        private void OnSignalProcessed(EvaluationInfo info)
        {
            filters.ForEach(f => f.Apply(audioSource, info.valueNormalized));
        }
    }
}