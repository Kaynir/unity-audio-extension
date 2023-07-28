using System;
using UnityEngine;

namespace Kaynir.Audio.Evaluations
{
    public abstract class EvaluationSignal : MonoBehaviour
    {
        public event Action<EvaluationInfo> Processed;

        [SerializeField] private AnimationCurve normalizationCurve = AnimationCurve.Constant(0f, 1f, 1f);

        public EvaluationInfo GetEvaluationInfo()
        {
            float evaluationValue = GetEvaluationValue();
            return new EvaluationInfo()
            {
                value = GetEvaluationValue(),
                valueNormalized = Mathf.Clamp01(normalizationCurve.Evaluate(evaluationValue))
            };
        }

        protected abstract float GetEvaluationValue();

        protected void ExecuteSignal()
        {
            Processed?.Invoke(GetEvaluationInfo());
        }
    }
}