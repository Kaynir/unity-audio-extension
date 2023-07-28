using UnityEngine;

namespace Kaynir.Audio.Evaluations
{
    public class VelocityEvaluationSignal3D : EvaluationSignal
    {
        [SerializeField] private Rigidbody body = null;

        private void FixedUpdate() => UpdateNormalizedValue();

        protected override float GetEvaluationValue()
        {
            return body.velocity.sqrMagnitude;
        }
    }
}