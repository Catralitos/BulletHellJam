using System;
using UnityEngine;

namespace Audio
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class AudioManager : MonoBehaviour
    {
        /// <summary>
        /// The sounds
        /// </summary>
        public Sound[] sounds;

        /// <summary>
        /// The intro
        /// </summary>
        private Sound _intro;
        /// <summary>
        /// The loop
        /// </summary>
        private Sound _loop;

        #region SingleTon

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static AudioManager Instance { get; private set; }

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake()
        {
            // Needed if we want the audio manager to persist through scenes
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            // Add audio source components
            foreach (Sound s in sounds)
            {
                s.SetSource(gameObject.AddComponent<AudioSource>());
            }
        }

        #endregion

        /// <summary>
        /// Plays the specified sound name.
        /// </summary>
        /// <param name="soundName">Name of the sound.</param>
        public void Play(string soundName)
        {
            var s = Array.Find(sounds, sound => sound.name == soundName);
            if (s == null)
            {
                Debug.LogWarning("Sound " + soundName + " not found!");
                return;
            }

            if (s.IsPlaying()) return;
            s.Play();
        }

        /// <summary>
        /// Stops the specified sound name.
        /// </summary>
        /// <param name="soundName">Name of the sound.</param>
        public void Stop(string soundName)
        {
            var s = Array.Find(sounds, sound => sound.name == soundName);
            if (s == null)
            {
                Debug.LogWarning("Sound " + soundName + " not found!");
                return;
            }
            if (!s.IsPlaying()) return;
            s.Stop();
        }

        /// <summary>
        /// Sets the music.
        /// </summary>
        /// <param name="introName">Name of the intro.</param>
        /// <param name="loopName">Name of the loop.</param>
        public void SetMusic(string introName, string loopName)
        {
            if (_intro != null && introName == _intro.name && _loop != null && loopName == _loop.name)
            {
                Debug.Log(introName + "/" + loopName + " already playing, ignoring.");
                return;
            }

            if (_intro != null)
                _intro.Stop();
            if (_loop != null)
                _loop.Stop();

            _intro = Array.Find(sounds, sound => sound.name == introName);
            if (_intro == null)
            {
                Debug.LogWarning("Sound " + introName + " not found!");
                return;
            }

            _loop = Array.Find(sounds, sound => sound.name == loopName);
            if (_intro == null)
            {
                Debug.LogWarning("Sound " + loopName + " not found!");
                return;
            }

            var introDuration = _intro.clip.length;
            var startTime = AudioSettings.dspTime + 0.2;
            _intro.PlayScheduled(startTime);
            _loop.PlayScheduled(startTime + introDuration);
        }

        /// <summary>
        /// Determines whether the specified sound name is playing.
        /// </summary>
        /// <param name="soundName">Name of the sound.</param>
        /// <returns>
        ///   <c>true</c> if the specified sound name is playing; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPlaying(String soundName)
        {
            var s = Array.Find(sounds, sound => sound.name == soundName);
            if (s != null) return s.IsPlaying();
            Debug.LogWarning("Sound " + soundName + " not found!");
            return false;
        }
    }
}