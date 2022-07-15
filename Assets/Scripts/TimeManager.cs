using Audio;
using Enemies;
using Enemies.Boss;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text bossHealthText;
    public Text countdownText;
    public Text freezeTimeText;
    public Text scoreText;
    public Text healthText;
    public Text dashText;

    public float timeMultiplier = 4;
    public int scorePerFrozenMilliSecond;

    private AudioManager _audioManager;
    private WaveSpawner _waveSpawner;
    private Boss _boss;

    private bool _timeRunning = true;
    private int _currentScore = 0;
    private const float Cooldown = 10f;
    private float _freezeTimeLeft;
    [HideInInspector] public float timeLeft;

    [HideInInspector] public bool gameEnded;

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
        timeLeft = Cooldown;
        _boss = BossEntity.Instance.boss;
        _audioManager = AudioManager.Instance;
        _waveSpawner = GetComponent<WaveSpawner>();
        _audioManager.Stop("TitleScreen");
        _audioManager.Play("LevelMusic");
        dashText.gameObject.SetActive(true);
        scoreText.text = $"{_currentScore:000000}";
    }

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

    public void FreezeTime(float time)
    {
        time *= timeMultiplier;
        time = Mathf.Round(time * 1000f) / 1000f;
        Mathf.Clamp(time, 0, 5000f);
        _freezeTimeLeft += time;
        IncreaseScore(Mathf.RoundToInt(time * scorePerFrozenMilliSecond));
    }

    public void IncreaseScore(int score)
    {
        _currentScore += score;
        scoreText.text = $"{_currentScore:000000}";
        GameManager.Instance.score = _currentScore;
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