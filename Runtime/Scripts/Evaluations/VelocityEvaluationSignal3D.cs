using UnityEngine;

namespace Kaynir.Audio.Evaluations
{
    public class VelocityEvaluationSignal3D : EvaluationSignal
    {
        [SerializeField] private Rigidbody body = null;

        private void Update() => ExecuteSignal();

        protected override float GetEvaluationValue()
        {
            return body.velocity.sqrMagnitude;
        }
    }
}