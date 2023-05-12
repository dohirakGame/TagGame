using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;

    [SerializeField] private GameObject masterSlider;
    [SerializeField] private GameObject musicSlider;
    [SerializeField] private GameObject soundSlider;

	private const string masterName = "Master";
	private const string musicName = "Music";
	private const string soundName = "Sound";
    private const string volumeName = "Volume";

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
        mixer.audioMixer.SetFloat(soundName + volumeName, Mathf.Lerp(-80, 0, volume));
    }

    public void LoadVolumeData()
    {
        MusicData data = new MusicData();

        float master = data.LoadData(masterName);
        float music = data.LoadData(musicName);
        float sound = data.LoadData(soundName);

        SetVolumeData(master, masterName);
        SetVolumeData(music, musicName);
        SetVolumeData(sound, soundName);
    }

    public void SetVolumeData(float value, string name)
    {
		switch (name)
        {
            case masterName:
                mixer.audioMixer.SetFloat(masterName + volumeName, value);
                break;
            case musicName:
				mixer.audioMixer.SetFloat(musicName + volumeName, value);
                break;
            case soundName:
                mixer.audioMixer.SetFloat(soundName + volumeName, value);
                break;
            default:
                break;
        }
    }

    public void LoadSlidersData()
    {
        MusicData data = new MusicData();

        data.LoadDataSlider(masterSlider, masterName);
        data.LoadDataSlider(musicSlider, musicName);
        data.LoadDataSlider(soundSlider, soundName);
	}

    public void SaveVolumeData()
    {
        float master;
        float music;
        float sound;

		MusicData data = new MusicData();

		mixer.audioMixer.GetFloat(masterName + volumeName, out master);
		mixer.audioMixer.GetFloat(musicName + volumeName, out music);
		mixer.audioMixer.GetFloat(soundName + volumeName, out sound);

        data.SaveData(master, masterName);
        data.SaveData(music, musicName);
        data.SaveData(sound, soundName);

        data.SaveDataSlider(masterSlider, masterName);
        data.SaveDataSlider(musicSlider, musicName);
        data.SaveDataSlider(soundSlider, soundName);
    }
}
