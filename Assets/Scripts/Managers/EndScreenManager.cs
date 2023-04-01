using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    /// <summary>
    /// The end screen manager
    /// </summary>
    public class EndScreenManager : MonoBehaviour
    {
        /// <summary>
        /// The UI buttons
        /// </summary>
        public Button titleButton, exitButton;

        /// <summary>
        /// The final score text
        /// </summary>
        public Text scoreText;
        
        /// <summary>
        /// The AudioManager
        /// </summary>
        private AudioManager _audioManager;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            _audioManager = AudioManager.Instance;
            scoreText.text = "Final Score: " + GameManager.Instance.score;
            titleButton.onClick.AddListener(ToTitle);
            exitButton.onClick.AddListener(ExitGame);
            _audioManager.Stop("LevelMusic");
            _audioManager.Play("TitleScreen");
        }

        /// <summary>
        /// Goes to the title screen
        /// </summary>
        private static void ToTitle()
        {
            SceneManager.LoadScene(0);
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        private static void ExitGame()
        {
            Application.Quit();
        }
    }
}
