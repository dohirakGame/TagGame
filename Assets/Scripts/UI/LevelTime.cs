using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTime : MonoBehaviour
{
	[SerializeField] private int levelID;
	private void Start()
	{
		if (PlayerPrefs.HasKey($"LevelTime{levelID}")) 
		{
			int allSecond = PlayerPrefs.GetInt($"LevelTime{levelID}");
			int minutes = (int)allSecond / 60;
			int seconds = allSecond % 60;
				
			gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
		}
		else
		{
			gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", 0, 0);
		}
	}
}
