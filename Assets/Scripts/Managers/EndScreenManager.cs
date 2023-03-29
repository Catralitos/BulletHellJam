using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class EndScreenManager : MonoBehaviour
    {
        /// <summary>
        /// The title button
        /// </summary>
        public Button titleButton, exitButton;

        /// <summary>
        /// The score text
        /// </summary>
        public Text scoreText;

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
            scoreText.text = "Final Score: " + GameManager.Instance.score;
            titleButton.onClick.AddListener(ToTitle);
            exitButton.onClick.AddListener(ExitGame);
            _audioManager.Stop("LevelMusic");
            _audioManager.Play("TitleScreen");
        }

        /// <summary>
        /// Converts to title.
        /// </summary>
        private void ToTitle()
        {
            SceneManager.LoadScene(0);
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
