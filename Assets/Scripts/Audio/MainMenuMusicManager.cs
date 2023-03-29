using UnityEngine;

namespace Audio
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class MainMenuMusicManager : MonoBehaviour
    {
        /// <summary>
        /// The audio manager
        /// </summary>
        private AudioManager _audioManager;

        /// <summary>
        /// The intro
        /// </summary>
        public string intro = "MenuIntro";
        /// <summary>
        /// The loop
        /// </summary>
        public string loop = "MenuLoop";

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            _audioManager = AudioManager.Instance;
            _audioManager.SetMusic(intro, loop);
        }
    }
}
