using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class TutorialScreenManager: MonoBehaviour
    {
        public Button titleButton;

        private GameManager _gameManager;
        private AudioManager _audioManager;
    
        private void Start()
        {
            _audioManager = AudioManager.Instance;
            _gameManager = GameManager.Instance;
            titleButton.onClick.AddListener(ToTitle);
        }

        private void ToTitle()
        {
            SceneManager.LoadScene(0);
        }
    }
