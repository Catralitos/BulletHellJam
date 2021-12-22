using Audio;
using Enemies;
using Enemies.Boss;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text bossHealthText;
    public Text countdownText;
    public Text freezeTimeText;
    public Text scoreText;

    public int scorePerFrozenMilliSecond;

    private AudioManager _audioManager;
    private WaveSpawner _waveSpawner;
    private Boss _boss;

    private bool _timeRunning = true;
    private int _currentScore = 0;
    private const float Cooldown = 10f;
    private float _freezeTimeLeft;
    private float _timeLeft;

    public static TimeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        _timeLeft = Cooldown;
        _boss = BossEntity.Instance.boss;
        _audioManager = AudioManager.Instance;
        _waveSpawner = GetComponent<WaveSpawner>();
        _audioManager.Stop("TitleScreen");
        _audioManager.Play("LevelMusic");

        scoreText.text = $"{_currentScore:000000}";
    }

    private void Update()
    {
        if (_freezeTimeLeft > 0f)
        {
            _timeRunning = false;
            _freezeTimeLeft -= Time.deltaTime;
            freezeTimeText.text = $"+ {_freezeTimeLeft:0.000}";
        }
        else
        {
            _freezeTimeLeft = 0f;
            _timeRunning = true;
            freezeTimeText.text = "";
        }

        if (_timeRunning) _timeLeft -= Time.deltaTime;
        if (_timeLeft < 0)
        {
            _waveSpawner.SpawnNextWave();
            _timeLeft = Cooldown;
        }

        countdownText.text = $"{_timeLeft:0.0}";
        bossHealthText.text = $"{_boss.currentHealth:000}";
    }

    public void FreezeTime(float time)
    {
        time = Mathf.Round(time * 1000f) / 1000f;
        _freezeTimeLeft += time;
        IncreaseScore(Mathf.RoundToInt(time * scorePerFrozenMilliSecond));
    }

    public void IncreaseScore(int score)
    {
        _currentScore += score;
        scoreText.text = $"{_currentScore:000000}";
    }

    public void GoToDeathScreen()
    {
        Invoke(nameof(ActuallyGoToDeathScreen), 3f);
    }

    private void ActuallyGoToDeathScreen()
    {
        SceneManager.LoadScene(3);
    }
}