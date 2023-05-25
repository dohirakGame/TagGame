using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandingInMainMenu : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject selectLevel;
    [SerializeField] private GameObject resetButtons;
    [SerializeField] private GameObject resetData;
    [SerializeField] private GameObject saveData;
    [SerializeField] private GameObject masterSlider;
    [SerializeField] private GameObject musicSlider;
    [SerializeField] private GameObject soundSlider;

    [SerializeField] private GameObject[] levels;

    private void Start()
    {
        StartGame();
    }

    private GameObject[] SetLevels()
    {
        return GameObject.FindGameObjectsWithTag("Levels");
    }

    private void SetInteractableLevels(GameObject[] levels)
    {
        for (int i = playerData.levelComplete+1; i < levels.Length; i++)
        {
            levels[i].GetComponent<Button>().interactable = false;
        }
    }

    private void StartGame()
    {
        AudioManager.instance.Play("Background");

		mainMenu.SetActive(true);
		settingsButton.SetActive(true);
		selectLevel.SetActive(false);
		resetData.SetActive(false);
        saveData.SetActive(false);
        masterSlider.SetActive(false);
        musicSlider.SetActive(false);
        soundSlider.SetActive(false);
	}

    public void ShowLevels()
    {
		AudioManager.instance.Play("Click");

		mainMenu.SetActive(false);
        settingsButton.SetActive(false);
        selectLevel.SetActive(true);
        
        levels = SetLevels();
        SetInteractableLevels(levels);
    }

    public void ShowSettings()
    {
		AudioManager.instance.Play("Click");

		mainMenu.SetActive(false);
        settingsButton.SetActive(false);
        resetData.SetActive(true);
        saveData.SetActive(true);
        masterSlider.SetActive(true);
        musicSlider.SetActive(true);
        soundSlider.SetActive(true);
	}

    public void ToBack()
    {
		AudioManager.instance.Play("Click");

		mainMenu.SetActive(true);
        settingsButton.SetActive(true);
        selectLevel.SetActive(false);
        resetData.SetActive(false);
        saveData.SetActive(false);
        masterSlider.SetActive(false);
        musicSlider.SetActive(false);
        soundSlider.SetActive(false);
	}
    
    public void SelectLevel(int sceneNumber)
    {
		AudioManager.instance.Play("Click");

		SceneManager.LoadScene(sceneNumber);
	}

    public void ShowResetButtons()
    {
		AudioManager.instance.Play("Fuse");

		resetButtons.SetActive(true);
	}
    public void HideResetButtons()
    {
		AudioManager.instance.Play("Fizz");

		resetButtons.SetActive(false);
    }
    public void ResetData()
    {
		AudioManager.instance.Play("Fire");

		playerData.ResetData();
    }
}
