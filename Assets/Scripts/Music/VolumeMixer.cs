using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;

    [SerializeField] private GameObject masterSlider;
    [SerializeField] private GameObject musicSlider;
    [SerializeField] private GameObject effectsSlider;

	private const string masterName = "Master";
	private const string musicName = "Music";
	private const string effectsName = "Effects";
    private const string volumeName = "Volume";

	private void Start()
	{
        LoadData();
	}

	public void ChangeMasterVolume(float volume)
    {
        mixer.audioMixer.SetFloat(masterName + volumeName, Mathf.Lerp(-80, 0, volume));
    }
    public void ChangeMusicVolume(float volume)
    {
        mixer.audioMixer.SetFloat(musicName + volumeName, Mathf.Lerp(-80, 0, volume));
    }
    public void ChangeEffectsVolume(float volume)
    {
        mixer.audioMixer.SetFloat(effectsName + volumeName, Mathf.Lerp(-80, 0, volume));
    }

	public void LoadData()
	{
		LoadVolumeData();
		LoadSlidersData();
	}
	public void SaveData()
	{
		SaveVolumeData();
		SaveSlidersData();
	}
	private void LoadVolumeData()
	{
		MusicData data = new MusicData();

		float master = data.LoadDataMixer(masterName);
		float music = data.LoadDataMixer(musicName);
		float effects = data.LoadDataMixer(effectsName);

		SetVolumeData(master, masterName);
		SetVolumeData(music, musicName);
		SetVolumeData(effects, effectsName);
	}
	private void LoadSlidersData()
	{
		MusicData data = new MusicData();

		float master = data.LoadDataSlider(masterName);
		float music = data.LoadDataSlider(musicName);
		float effects = data.LoadDataSlider(effectsName);

		SetSlidersData(master, masterName);
		SetSlidersData(music, musicName);
		SetSlidersData(effects, effectsName);
	}
	private void SetVolumeData(float value, string name)
	{
		switch (name)
		{
			case masterName:
				mixer.audioMixer.SetFloat(masterName + volumeName, value);
				break;
			case musicName:
				mixer.audioMixer.SetFloat(musicName + volumeName, value);
				break;
			case effectsName:
				mixer.audioMixer.SetFloat(effectsName + volumeName, value);
				break;
		}
	}
	private void SetSlidersData(float value, string name)
	{
		switch (name)
		{
			case masterName:
				masterSlider.GetComponent<Slider>().value = value;
				break;
			case musicName:
				musicSlider.GetComponent<Slider>().value = value;
				break;
			case effectsName:
				effectsSlider.GetComponent<Slider>().value = value;
				break;
		}
	}
	private void SaveVolumeData()
	{
		float master;
		float music;
		float effects;

		MusicData data = new MusicData();

		mixer.audioMixer.GetFloat(masterName + volumeName, out master);
		mixer.audioMixer.GetFloat(musicName + volumeName, out music);
		mixer.audioMixer.GetFloat(effectsName + volumeName, out effects);

		data.SaveDataMixer(master, masterName);
		data.SaveDataMixer(music, musicName);
		data.SaveDataMixer(effects, effectsName);
	} 
    private void SaveSlidersData()
    {
        float master = masterSlider.GetComponent<Slider>().value;
        float music = musicSlider.GetComponent<Slider>().value;
        float effects = effectsSlider.GetComponent<Slider>().value;

        MusicData data = new MusicData();

		data.SaveDataSlider(master, masterName);
		data.SaveDataSlider(music, musicName);
		data.SaveDataSlider(effects, effectsName);
	}
}
