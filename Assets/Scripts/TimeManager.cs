using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text countdownText;

    private bool _timeRunning = true;
    private const float Cooldown = 10f;
    private float _freezeTimeLeft = 0;
    private float _timeLeft = 0f;

    #region SingleTon

    public static TimeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        _timeLeft = Cooldown;
    }

    private void Update()
    {
        if (_freezeTimeLeft > 0f)
        {
            _timeRunning = false;
            _freezeTimeLeft -= Time.deltaTime;
        }
        else
        {
            _freezeTimeLeft = 0f;
            _timeRunning = true;
        }

        if (!_timeRunning) return;

        _timeLeft -= Time.deltaTime;
        if (_timeLeft < 0)
        {
            //TODO spawn proxima wave
            _timeLeft = Cooldown;
        }

        countdownText.text = $"{_timeLeft:0.000}";
    }

    public void FreezeTime(float time)
    {
        _freezeTimeLeft += time;
    }
}