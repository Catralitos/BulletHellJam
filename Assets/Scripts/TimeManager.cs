using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text countdownText;
    [HideInInspector] public float timeLeft = 0f;

    private bool _timeRunning = true;
    private const float Cooldown = 10f;
    private float _freezeTimeLeft = 0;

    #region SingleTon

    public static TimeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        timeLeft = Cooldown;
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

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            //TODO spawn proxima wave
            timeLeft = Cooldown;
        }

        countdownText.text = $"{timeLeft:0.000}";
    }

    public void FreezeTime(float time)
    {
        _freezeTimeLeft += time;
    }
}