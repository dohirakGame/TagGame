using TMPro;
using UnityEngine;

public class TimerTracker : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI timerText;

	private int minutes = 0;
	private int seconds = 0;
	private bool isRunning;

	private float second = 1;

	private void Update()
	{
		if (isRunning)
		{
			second -= Time.deltaTime;
			if (second <= 0)
			{
				second = 1;
				seconds++;
			}
			if (seconds == 60)
			{
				minutes++;
				seconds = 0;
			}
			timerText.text = string.Format("Время: {0:00}:{1:00}", minutes, seconds);
		}
	}
	public void StartTimer()
	{
		isRunning = true;
	}

	public void StopTimer()
	{
		isRunning = false;
	}
}

