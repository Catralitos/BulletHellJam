using Audio;
using Enemies.Boss;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        /// <summary>
        /// The boss health text
        /// </summary>
        public Text bossHealthText;
        /// <summary>
        /// The countdown text
        /// </summary>
        public Text countdownText;
        /// <summary>
        /// The freeze time text
        /// </summary>
        public Text freezeTimeText;
        /// <summary>
        /// The score text
        /// </summary>
        public Text scoreText;
        /// <summary>
        /// The health text
        /// </summary>
        public Text healthText;
        /// <summary>
        /// The dash text
        /// </summary>
        public Text dashText;

        /// <summary>
        /// The time multiplier
        /// </summary>
        public float timeMultiplier = 4;
        /// <summary>
        /// The score per frozen milli second
        /// </summary>
        public int scorePerFrozenMilliSecond;

        /// <summary>
        /// The audio manager
        /// </summary>
        private AudioManager _audioManager;
        /// <summary>
        /// The wave spawner
        /// </summary>
        private WaveSpawner _waveSpawner;
        /// <summary>
        /// The boss
        /// </summary>
        private Boss _boss;

        /// <summary>
        /// The time running
        /// </summary>
        private bool _timeRunning = true;
        /// <summary>
        /// The current score
        /// </summary>
        private int _currentScore = 0;
        /// <summary>
        /// The cooldown
        /// </summary>
        private const float Cooldown = 10f;
        /// <summary>
        /// The freeze time left
        /// </summary>
        private float _freezeTimeLeft;
        /// <summary>
        /// The time left
        /// </summary>
        [HideInInspector] public float timeLeft;

        /// <summary>
        /// The game ended
        /// </summary>
        [HideInInspector] public bool gameEnded;

        /// <summary>
        /// The instance
        /// </summary>
        public static TimeManager Instance;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// Called when [destroy].
        /// </summary>
        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            timeLeft = Cooldown;
            _boss = BossEntity.Instance.boss;
            _audioManager = AudioManager.Instance;
            _waveSpawner = GetComponent<WaveSpawner>();
            _audioManager.Stop("TitleScreen");
            _audioManager.Play("LevelMusic");
            dashText.gameObject.SetActive(true);
            scoreText.text = $"{_currentScore:000000}";
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update()
        {
            _freezeTimeLeft -= Time.deltaTime;
            if (_freezeTimeLeft > 0f)
            {
                _timeRunning = false;
                freezeTimeText.text = $"+ {_freezeTimeLeft:0.000}";
            }
            else
            {
                _freezeTimeLeft = 0f;
                _timeRunning = true;
                freezeTimeText.text = "";
            }

            if (_timeRunning) timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                _waveSpawner.SpawnNextWave();
                BossEntity.Instance.gameObject.GetComponent<BossShoot>().BossSwitch();
                timeLeft = Cooldown;
            }

            countdownText.text = $"{timeLeft:0.0}";
            bossHealthText.text = $"{_boss.currentHealth:000}";
            if (PlayerEntity.Instance == null) return;
            dashText.gameObject.SetActive(PlayerEntity.Instance.movement.canDash);
        }

        /// <summary>
        /// Freezes the time.
        /// </summary>
        /// <param name="time">The time.</param>
        public void FreezeTime(float time)
        {
            time *= timeMultiplier;
            time = Mathf.Round(time * 1000f) / 1000f;
            Mathf.Clamp(time, 0, 5000f);
            _freezeTimeLeft += time;
            IncreaseScore(Mathf.RoundToInt(time * scorePerFrozenMilliSecond));
        }

        /// <summary>
        /// Increases the score.
        /// </summary>
        /// <param name="score">The score.</param>
        public void IncreaseScore(int score)
        {
            _currentScore += score;
            scoreText.text = $"{_currentScore:000000}";
            GameManager.Instance.score = _currentScore;
        }

        /// <summary>
        /// Goes to death screen.
        /// </summary>
        public void GoToDeathScreen()
        {
            Invoke(nameof(ActuallyGoToDeathScreen), 3f);
        }

        /// <summary>
        /// Actuallies the go to death screen.
        /// </summary>
        private void ActuallyGoToDeathScreen()
        {
            SceneManager.LoadScene(3);
        }
    }
}