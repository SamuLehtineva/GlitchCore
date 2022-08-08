using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : MonoBehaviour
    {
        public static PlayerAudio instance;

        [SerializeField]
        List<AudioClip> clips = new List<AudioClip>();
        
        private AudioSource audi;

        void Awake()
        {
            instance = this;
            audi = GetComponent<AudioSource>();
        }

        public void PlayClip(int index)
        {
            audi.PlayOneShot(clips[index]);
        }

    }
}
