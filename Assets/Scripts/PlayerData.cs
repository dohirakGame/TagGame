using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public int levelComplete;

    private void Start()
    {
        levelComplete = GetData();
    }

    public int GetData()
    {
       return PlayerPrefs.GetInt("LevelComplete");
    }

    public void SetData(int levelIndex)
    {
        PlayerPrefs.SetInt("LevelComplete",levelIndex);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
