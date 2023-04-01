using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    /// <summary>
    /// The death screen manager
    /// </summary>
    public class DeathScreenManager : MonoBehaviour
    {
        /// <summary>
        /// The AudioManager
        /// </summary>
        private AudioManager _audioManager;
        /// <summary>
        /// The various UI buttons
        /// </summary>
        public Button retryButton, titleButton, creditsButton;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            _audioManager = AudioManager.Instance;
            retryButton.onClick.AddListener(RetryGame);
            titleButton.onClick.AddListener(BackToTitle);
            creditsButton.onClick.AddListener(GoToCredits);
            _audioManager.Stop("LevelMusic");
            _audioManager.Play("TitleScreen");
        }

        /// <summary>
        /// Retries the game.
        /// </summary>
        private static void RetryGame()
        {
            SceneManager.LoadScene(1);
        }

        /// <summary>
        /// Returns to the title screen.
        /// </summary>
        private static void BackToTitle()
        {
            SceneManager.LoadScene(0);
        }

        /// <summary>
        /// Goes to the credits.
        /// </summary>
        private static void GoToCredits()
        {
            SceneManager.LoadScene(2);
        } 
    }
}
