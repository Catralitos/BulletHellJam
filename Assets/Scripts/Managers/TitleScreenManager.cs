using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class TitleScreenManager : MonoBehaviour
    {

        /// <summary>
        /// The mouse button
        /// </summary>
        public Button mouseButton, controllerButton, fullscreenButton, tutorialButton, exitButton;

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
            mouseButton.onClick.AddListener(StartMouseGame);
            controllerButton.onClick.AddListener(StartControllerGame);
            fullscreenButton.onClick.AddListener(ToggleFullscreen);
            tutorialButton.onClick.AddListener(ShowHowToPlay);
            exitButton.onClick.AddListener(ExitGame);
            _audioManager.Play("TitleScreen");
        }

        /// <summary>
        /// Toggles the fullscreen.
        /// </summary>
        private void ToggleFullscreen()
        {
            if (_gameManager.fullscreen)
            {
                Screen.SetResolution(1280, 720, false, 60);
                _gameManager.fullscreen = false;
            }
            else
            {
                Screen.SetResolution(1920, 1080, true, 60);
                _gameManager.fullscreen = true;
            }
        }

        /// <summary>
        /// Starts the mouse game.
        /// </summary>
        private void StartMouseGame()
        {
            _gameManager.mouseControls = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /// <summary>
        /// Starts the controller game.
        /// </summary>
        private void StartControllerGame()
        {
            _gameManager.mouseControls = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /// <summary>
        /// Shows the how to play.
        /// </summary>
        private void ShowHowToPlay()
        {
            //_audioManager.Stop("TitleScreen");
            SceneManager.LoadScene(4);
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
