using UnityEngine;

namespace Managers
{
    /// <summary>
    /// The Game Manager
    /// It keeps track of settings and score between scenes
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// If the game is full screen
        /// </summary>
        public bool fullscreen;
        /// <summary>
        /// If the game will be played using mouse controls or the controller
        /// </summary>
        public bool mouseControls = true;

        /// <summary>
        /// The score
        /// </summary>
        [HideInInspector] public int score;

        
        #region SingleTon

        /// <summary>
        /// Gets the sole instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static GameManager Instance { get; private set; }

        /// <summary>
        /// Awakes this instance (if none exist).
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                if (fullscreen) Screen.SetResolution(1920, 1080, true, 60);
                else Screen.SetResolution(1280, 720, false, 60);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        #endregion
        
    }
}