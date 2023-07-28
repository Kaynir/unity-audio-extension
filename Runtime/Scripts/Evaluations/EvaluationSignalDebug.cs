using UnityEngine;

namespace Kaynir.Audio.Evaluations
{
    public class EvaluationSignalDebug : MonoBehaviour
    {
        [SerializeField] private EvaluationSignal evaluationSignal = null;

        private void OnEnable()
        {
            evaluationSignal.Processed += OnSignalProcessed;
        }

        private void OnDisable()
        {
            evaluationSignal.Processed -= OnSignalProcessed;
        }

        private void OnSignalProcessed(EvaluationInfo info)
        {
            Debug.Log($"Evaluation signal for {gameObject.name} processed with value: {info.value}.");
        }
    }
}