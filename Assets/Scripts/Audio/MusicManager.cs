using UnityEngine;

namespace Audio
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class MusicManager : MonoBehaviour
    {
        /// <summary>
        /// The audio manager
        /// </summary>
        private AudioManager _audioManager;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            _audioManager = AudioManager.Instance;
        }
        /*
        void Update()
        {
            if (worldType != WorldManager.currentWorld)
            {
                worldType = WorldManager.currentWorld;
                SwitchMusic();
            }
        }

        private void SwitchMusic()
        {
            switch (worldType)
            {
                case WorldType.Light:
                    _audioManager.SetMusic("LightIntro", "LightLoop");
                    break;
                case WorldType.Dark:
                    _audioManager.SetMusic("DarkIntro", "DarkLoop");
                    break;
                default:
                    Debug.LogWarning("No music assigned to world type " + worldType);
                    break;
            }
        }*/
    }
}
