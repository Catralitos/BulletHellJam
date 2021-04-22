using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    public Button titleButton, exitButton;

    private GameManager _gameManager;
    private AudioManager _audioManager;
    
    private void Start()
    {
        _audioManager = AudioManager.Instance;
        _gameManager = GameManager.Instance;
        titleButton.onClick.AddListener(ToTitle);
        exitButton.onClick.AddListener(ExitGame);
        _audioManager.Stop("LevelMusic");
        _audioManager.Play("TitleScreen");
    }

    private void ToTitle()
    {
        SceneManager.LoadScene(0);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
