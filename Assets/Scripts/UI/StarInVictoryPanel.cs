using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarInVictoryPanel : MonoBehaviour
{
    [Header("Нужные спрайты")]
    [SerializeField] private Sprite goldImage;
    [SerializeField] private Sprite ironImage;
    [SerializeField] private Sprite bronzeImage;
    [SerializeField] private Sprite glassImage;

    [Header("Таймер")]
    [SerializeField] private GameObject timer;

    [Header ("Поля для показа")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Image starField;

    [Header ("Требуемое время")]
	[SerializeField] private int timeForGold;
	[SerializeField] private int timeForIron;
	[SerializeField] private int timeForBronze;

	public void ShowResult()
    {
        int allsecond = timer.GetComponent<TimerTracker>().GetAllSeconds();

        if (allsecond <= timeForGold) starField.sprite = goldImage;
        else if (allsecond > timeForGold && allsecond <= timeForIron) starField.sprite = ironImage;
        else if (allsecond > timeForIron && allsecond <= timeForBronze) starField.sprite = bronzeImage;
        else starField.sprite = glassImage;

        int minutes = (int)allsecond / 60;
        int seconds = allsecond % 60;

		timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
