using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeathScreenManager : MonoBehaviour
{
    private AudioManager _audioManager;
    public Button retryButton, titleButton, creditsButton;
    
    private void Start()
    {
        _audioManager = AudioManager.Instance;
        retryButton.onClick.AddListener(RetryGame);
        titleButton.onClick.AddListener(BackToTitle);
        creditsButton.onClick.AddListener(GoToCredits);
        _audioManager.Stop("LevelMusic");
        _audioManager.Play("TitleScreen");
    }

    private void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    private void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }

    private void GoToCredits()
    {
        SceneManager.LoadScene(2);
    } 
}
