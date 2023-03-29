using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class TutorialScreenManager: MonoBehaviour
    {
        /// <summary>
        /// The title button
        /// </summary>
        public Button titleButton;

        /// <summary>
        /// The game manager
        /// </summary>
        private GameManager _gameManager;
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
            _gameManager = GameManager.Instance;
            titleButton.onClick.AddListener(ToTitle);
        }

        /// <summary>
        /// Converts to title.
        /// </summary>
        private void ToTitle()
        {
            SceneManager.LoadScene(0);
        }
    }
}
