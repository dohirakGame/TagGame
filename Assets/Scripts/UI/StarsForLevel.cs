using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsForLevel : MonoBehaviour
{
	[Header("Спрайты для звезд")]
	[SerializeField] private Sprite glassImage;
	[SerializeField] private Sprite bronzeImage;
	[SerializeField] private Sprite ironImage;
	[SerializeField] private Sprite goldImage;

	[Header("ID уровня")]
	[SerializeField] private int levelID;

	[Header("Время для звезды (сек)")]
	[SerializeField] private int timeForGold;
	[SerializeField] private int timeForIron;
	[SerializeField] private int timeForBronze;

	private void Start()
	{
		if (PlayerPrefs.HasKey($"LevelTime{levelID}"))
		{
			int allSecond = PlayerPrefs.GetInt($"LevelTime{levelID}");

			if (allSecond <= timeForGold) gameObject.GetComponent<Image>().sprite = goldImage;
			else if (allSecond > timeForGold && allSecond <= timeForIron) gameObject.GetComponent<Image>().sprite = ironImage;
			else if (allSecond > timeForIron && allSecond <= timeForBronze) gameObject.GetComponent<Image>().sprite = bronzeImage;
			else gameObject.GetComponent<Image>().sprite = glassImage;
		}
		else gameObject.GetComponent<Image>().sprite = glassImage;
	}
}
