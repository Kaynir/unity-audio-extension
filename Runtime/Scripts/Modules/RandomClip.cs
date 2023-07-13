using System.Collections.Generic;
using Kaynir.Audio.Tools;
using UnityEngine;

namespace Kaynir.Audio.Modules
{
    [CreateAssetMenu(menuName = AssetMenuTools.CLIP_MODULE_PATH)]
    public class RandomClip : AudioModule
    {
        [SerializeField] private List<AudioClip> collection = new List<AudioClip>();

        public override void Apply(AudioSource source)
        {
            if (collection.Count == 0) return;
            source.clip = GetRandomClip();
        }

        private AudioClip GetRandomClip()
        {
            int index = Random.Range(0, collection.Count);
            return collection[index];
        }
    }
}