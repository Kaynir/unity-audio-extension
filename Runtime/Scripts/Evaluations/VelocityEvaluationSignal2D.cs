using UnityEngine;

namespace Kaynir.Audio.Evaluations
{
    public class VelocityEvaluationSignal2D : EvaluationSignal
    {
        [SerializeField] private Rigidbody2D body = null;

        private void Update() => ExecuteSignal();

        protected override float GetEvaluationValue()
        {
            return body.velocity.sqrMagnitude;
        }
    }
}