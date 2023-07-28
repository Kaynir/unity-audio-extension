using System;
using UnityEngine;

namespace Kaynir.Audio.Evaluations
{
    public abstract class EvaluationSignal : MonoBehaviour
    {
        public event Action<float> NormalizedValueChanged;

        [SerializeField] private AnimationCurve curve = AnimationCurve.Constant(0f, 1f, 1f);

        public float NormalizedValue { get; private set; }

        protected abstract float GetEvaluationValue();

        protected void UpdateNormalizedValue()
        {
            float evaluationValue = GetEvaluationValue();
            NormalizedValue = Mathf.Clamp01(curve.Evaluate(evaluationValue));
            NormalizedValueChanged?.Invoke(NormalizedValue);
        }
    }
}