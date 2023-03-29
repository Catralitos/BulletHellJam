using UnityEngine;

namespace Audio
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class Sound
    {
        /// <summary>
        /// The name
        /// </summary>
        public string name;
        /// <summary>
        /// The clip
        /// </summary>
        public AudioClip clip;

        /// <summary>
        /// The volume
        /// </summary>
        [Range(0f, 1f)]
        public float volume = 1f;
        /// <summary>
        /// The pitch
        /// </summary>
        [Range(0.1f, 3f)]
        public float pitch = 1f;
        /// <summary>
        /// The loop
        /// </summary>
        public bool loop;

        /// <summary>
        /// The source
        /// </summary>
        [HideInInspector]
        public AudioSource source;

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="audioSource">The audio source.</param>
        public void SetSource(AudioSource audioSource)
        {
            audioSource.clip = clip;

            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.loop = loop;
            this.source = audioSource;
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            source.Play();
        }

        /// <summary>
        /// Plays the scheduled.
        /// </summary>
        /// <param name="time">The time.</param>
        public void PlayScheduled(double time)
        {
            source.PlayScheduled(time);
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            source.Stop();
        }

        /// <summary>
        /// Determines whether this instance is playing.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is playing; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPlaying()
        {
            return source.isPlaying;
        }
    }
}

