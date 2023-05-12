using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MusicData : MonoBehaviour
{
    private string _masterName = "MasterVolume";
    private string _musicName = "MusicVolume";
    private string _soundName = "SoundVolume";

    private string _masterSlider = "MasterSliderValie";
    private string _musicSlider = "MusicSliderValie";
    private string _soundSlider = "SoundSliderValie";

    private const string _master = "Master";
    private const string _music = "Music";
    private const string _sound = "Sound";

    public float LoadData(string name)
    {
        float value = 0;
        switch (name)
        {
            case _master:
				if (PlayerPrefs.HasKey(_masterName)) value = PlayerPrefs.GetFloat(_masterName);
				break;
            case _music:
				if (PlayerPrefs.HasKey(_musicName)) value = PlayerPrefs.GetFloat(_musicName);
				break;
            case _sound:
				if (PlayerPrefs.HasKey(_soundName)) value = PlayerPrefs.GetFloat(_soundName);
				break;
            default:
                break;
        }
        return value;
    }
    public void SaveData(float value, string name)
    {
        switch(name)
        {
            case _master:
				PlayerPrefs.SetFloat(_masterName, value);
				break;
            case _music:
				PlayerPrefs.SetFloat(_musicName, value);
				break;
            case _sound:
				PlayerPrefs.SetFloat(_soundName, value);
				break;
        }
    }

	public void LoadDataSlider(GameObject slider, string name)
	{
		switch (name)
		{
			case _master:
				if (PlayerPrefs.HasKey(_masterSlider)) slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat(_masterSlider);
				break;
			case _music:
				if (PlayerPrefs.HasKey(_musicSlider)) slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat(_musicSlider);
				break;
			case _sound:
				if (PlayerPrefs.HasKey(_soundSlider)) slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat(_soundSlider);
				break;
		}
	}
	public void SaveDataSlider(GameObject slider, string name)
    {
        switch (name)
        {
            case _master:
                PlayerPrefs.SetFloat(_masterSlider, slider.GetComponent<Slider>().value);
				break;
            case _music:
				PlayerPrefs.SetFloat(_musicSlider, slider.GetComponent<Slider>().value);
				break;
            case _sound:
				PlayerPrefs.SetFloat(_soundSlider, slider.GetComponent<Slider>().value);
				break;
        }
    }
}
