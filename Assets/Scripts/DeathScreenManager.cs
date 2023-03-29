using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// 
/// </summary>
public class DeathScreenManager : MonoBehaviour
{
    /// <summary>
    /// The audio manager
    /// </summary>
    private AudioManager _audioManager;
    /// <summary>
    /// The retry button
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
    private void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Backs to title.
    /// </summary>
    private void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Goes to credits.
    /// </summary>
    private void GoToCredits()
    {
        SceneManager.LoadScene(2);
    } 
}
