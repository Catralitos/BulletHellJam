using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{

    public Button mouseButton, controllerButton, fullscreenButton, tutorialButton;

    private GameManager _gameManager;
    private AudioManager _audioManager;
    
    private void Start()
    {
        _audioManager = AudioManager.Instance;
        _gameManager = GameManager.Instance;
        mouseButton.onClick.AddListener(StartMouseGame);
        controllerButton.onClick.AddListener(StartControllerGame);
        fullscreenButton.onClick.AddListener(ToggleFullscreen);
        tutorialButton.onClick.AddListener(ShowHowToPlay);
        _audioManager.Play("TitleScreen");
    }

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

    private void StartMouseGame()
    {
        _gameManager.mouseControls = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void StartControllerGame()
    {
        _gameManager.mouseControls = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ShowHowToPlay()
    {
        _audioManager.Stop("TitleScreen");
        SceneManager.LoadScene(4);
    }
 
}
