using TMPro;
using UnityEngine;

public class TimerTracker : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI timerText;

	private int _minutes = 0;
	private int _seconds = 0;
	private int _allSeconds = 0;
	private bool _isRunning;

	private float _second = 1;

	public int GetAllSeconds()
	{
		return _allSeconds;
	}

	private void Update()
	{
		if (_isRunning)
		{
			_second -= Time.deltaTime;
			if (_second <= 0)
			{
				_second = 1;
				_seconds++;
				_allSeconds++;
			}
			if (_seconds == 60)
			{
				_minutes++;
				_seconds = 0;
			}
			timerText.text = string.Format("Время: {0:00}:{1:00}", _minutes, _seconds);
		}
	}
	public void StartTimer()
	{
		_isRunning = true;
	}

	public void StopTimer()
	{
		_isRunning = false;
	}

	public void SaveLevelTime(int levelID)
	{
		if (!PlayerPrefs.HasKey($"LevelTime{levelID}")) PlayerPrefs.SetInt($"LevelTime{levelID}", _allSeconds);
		else if (_allSeconds < PlayerPrefs.GetInt($"LevelTime{levelID}")) PlayerPrefs.SetInt($"LevelTime{levelID}", _allSeconds);
	}
}

