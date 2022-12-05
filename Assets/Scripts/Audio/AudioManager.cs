using UnityEngine;

namespace Wuzzle.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource music;

        private void Awake() => music = transform.Find("Music").GetComponent<AudioSource>();

        public void MuteAudio() => music.mute = true;

        public void MuteOffAudio() => music.mute = false;
    }
}
