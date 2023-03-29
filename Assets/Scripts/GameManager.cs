using Audio;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The fullscreen
    /// </summary>
    public bool fullscreen = false;
    /// <summary>
    /// The mouse controls
    /// </summary>
    public bool mouseControls = true;

    /// <summary>
    /// The score
    /// </summary>
    [HideInInspector] public int score;

    /// <summary>
    /// The audio manager
    /// </summary>
    private AudioManager _audioManager;

    #region SingleTon

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>
    /// The instance.
    /// </value>
    public static GameManager Instance { get; private set; }

    /// <summary>
    /// Awakes this instance.
    /// </summary>
    private void Awake()
    {
        // Needed if we want the audio manager to persist through scenes
        if (Instance == null)
        {
            Instance = this;
            _audioManager = AudioManager.Instance;
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

    /// <summary>
    /// Toggles the fullscreen.
    /// </summary>
    public void ToggleFullscreen()
    {
        if (fullscreen)
        {
            Screen.SetResolution(1280, 720, false, 60);
            fullscreen = false;
        }
        else
        {
            Screen.SetResolution(1920, 1080, true, 60);
            fullscreen = true;
        }
    }
}