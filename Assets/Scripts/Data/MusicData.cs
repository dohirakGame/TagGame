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
    private string _effectsName = "EffectsVolume";

    private string _masterSlider = "MasterSliderValue";
    private string _musicSlider = "MusicSliderValue";
    private string _effectsSlider = "EffectsSliderValue";

    private const string _master = "Master";
    private const string _music = "Music";
    private const string _effects = "Effects";

	public float LoadDataMixer(string name)
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
            case _effects:
				if (PlayerPrefs.HasKey(_effectsName)) value = PlayerPrefs.GetFloat(_effectsName);
				break;
        }
        return value;
    }
    public void SaveDataMixer(float value, string name)
    {
        switch(name)
        {
            case _master:
				PlayerPrefs.SetFloat(_masterName, value);
				break;
            case _music:
				PlayerPrefs.SetFloat(_musicName, value);
				break;
            case _effects:
				PlayerPrefs.SetFloat(_effectsName, value);
				break;
        }
    }

	public float LoadDataSlider(string name)
	{
        float value = 1;
		switch (name)
		{
			case _master:
				if (PlayerPrefs.HasKey(_masterSlider)) value = PlayerPrefs.GetFloat(_masterSlider);
				break;
			case _music:
				if (PlayerPrefs.HasKey(_musicSlider)) value = PlayerPrefs.GetFloat(_musicSlider);
				break;
			case _effects:
				if (PlayerPrefs.HasKey(_effectsSlider)) value = PlayerPrefs.GetFloat(_effectsSlider);
				break;
		}
        return value;
	}
	public void SaveDataSlider(float value, string name)
    {
        switch (name)
        {
            case _master:
                PlayerPrefs.SetFloat(_masterSlider, value);
				break;
            case _music:
				PlayerPrefs.SetFloat(_musicSlider, value);
				break;
            case _effects:
				PlayerPrefs.SetFloat(_effectsSlider, value);
				break;
        }
    }
}
